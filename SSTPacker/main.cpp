#include <iostream>
#include <vector>
#define SDL_MAIN_HANDLED
#include <SDL.h>
#include <SDL_ttf.h>
#include <SDL_image.h>
#include <msclr/marshal.h>
#include "Util.h"

using namespace System;
using namespace msclr::interop;

int main(int argc, char** argv) {
	SDL_Init(SDL_INIT_EVERYTHING);
	IMG_Init(IMG_INIT_PNG);
	TTF_Init();

	if (argc <= 3) {
		Console::WriteLine("SSTPacker image.png(bmp) output.sst compressMode");
		Console::WriteLine("SSTPacker -font words.txt font.ttf(otf) wordSize sstWidth sstHeight output.sst compressMode");
		Console::WriteLine("Compress Mode Support:");
		Console::WriteLine("\tRGBA");
		//Console::WriteLine("\tDXT1");
		//Console::WriteLine("\tDXT3");
		//Console::WriteLine("\tDXT5");
	}
	else {
		SDL_Surface* allImage = nullptr;
		std::vector<SDL_Rect> rects;
		System::Byte compressMode = 0;
		std::string outputPath;
		
		//Load Image
		if (std::string(argv[1]) == "-font")
		{
			outputPath = argv[7];
			compressMode = ParseCompressMode(argv[8]);
			//Font to SST
			auto words = System::IO::File::ReadAllText(marshal_as<String^>(argv[2]))->ToCharArray();
			const char* ttf = (argv[3]);
			int wordSize = atoi(argv[4]);
			int sstW = atoi(argv[5]);
			int sstH = atoi(argv[6]);

			allImage = SDL_CreateRGBSurface(0, sstW, sstH, 32, 0xFF000000, 0x00FF0000, 0x0000FF00, 0x000000FF);
			SDL_Rect allRect = { 0,0,sstW,sstH };
			SDL_FillRect(allImage, &allRect, 0);
			SDL_SetSurfaceBlendMode(allImage, SDL_BLENDMODE_BLEND);

			const auto font = TTF_OpenFont(ttf,wordSize);
			if (font == nullptr) {
				Console::WriteLine("ERROR:Can not open ttf.");
				return -1;
			}

			int x = 0, y = 0, lineHeight = 0;
			for (Int32 i = 0; i < words->Length;++i) {
				//渲染得出当前文字
				wchar_t ch[] = { words[i],'\0' };
				auto rendered = TTF_RenderUNICODE_Blended(font, (Uint16*)ch, { 255,255,255 });

				//如果x超过位置则换行
				if (rendered->w + x >= sstW) {
					x = 0;
					y += lineHeight;
					lineHeight = 0;

					if (y >= sstH) {
						Console::WriteLine("ERROR:SST Size is too small.");
						break;
					}
				}

				//如果字体高度大于当前行高度，则加大行高度
				if (rendered->h > lineHeight) lineHeight = rendered->h;

				SDL_SetSurfaceBlendMode(rendered, SDL_BLENDMODE_BLEND);
				SDL_Rect thisWord = {
					x,y,rendered->w,rendered->h
				};

				x += rendered->w;

				SDL_BlitSurface(rendered, NULL,allImage, &thisWord);
				SDL_FreeSurface(rendered);

				rects.push_back(thisWord);
			}
		}

		else
		{
			//Single Image to SST
			allImage = IMG_Load(argv[1]);
			rects.push_back({
				0,0,allImage->w,allImage->h
			});
			outputPath = argv[2];
			compressMode = ParseCompressMode(argv[3]);
		}

		//Debug Output
		SDL_SaveBMP(allImage, "DEBUG.bmp");

		//Convert allImage To RGBA
		{
			auto c = SDL_ConvertSurfaceFormat(allImage, SDL_PIXELFORMAT_ABGR8888, 0);
			SDL_FreeSurface(allImage);
			allImage = c;
		}

		//Compress Surface To Compressed Buffer
		//TODO:实现多种不同的压缩方式
		array<Byte>^ compressedBuffer;
		{
			//RGBA
			{
				compressedBuffer = gcnew array<Byte>(allImage->h*allImage->pitch);
				pin_ptr<Byte> ptr = &compressedBuffer[0];
				memcpy_s(ptr, allImage->h*allImage->pitch, allImage->pixels, allImage->h*allImage->pitch);
				
			}
		}

		//Output File
		{
			System::IO::FileStream^ outputFile = System::IO::File::Open(marshal_as<String^>(outputPath.c_str()),System::IO::FileMode::Create);
			System::IO::BinaryWriter out(outputFile);

			out.Write(compressMode);
			out.Write(System::UInt16(rects.size()));

			out.Write(System::UInt16(allImage->w));
			out.Write(System::UInt16(allImage->h));

			for (auto& v : rects) {
				out.Write(System::UInt16(v.x));
				out.Write(System::UInt16(v.y));
				out.Write(System::UInt16(v.w));
				out.Write(System::UInt16(v.h));
			}

			out.Write(System::Int32(compressedBuffer->Length));
			out.Write(compressedBuffer);

			out.Close();
			outputFile->Close();
		}

		//Delete Resources
		{
			delete[] compressedBuffer;
			SDL_FreeSurface(allImage);
			TTF_Quit();
			IMG_Quit();
			SDL_Quit();
		}
	}

	return 0;
}
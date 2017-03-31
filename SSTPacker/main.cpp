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
		{
			allImage = IMG_Load(argv[1]);
			rects.push_back({
				0,0,allImage->w,allImage->h
			});
			outputPath = argv[2];
			compressMode = ParseCompressMode(argv[3]);
		}

		//Convert allImage To RGBA
		{
			auto c = SDL_ConvertSurfaceFormat(allImage, SDL_PIXELFORMAT_RGBA8888, 0);
			SDL_FreeSurface(allImage);
			allImage = c;
		}

		//Compress Surface To Compressed Buffer
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
			System::IO::FileStream^ outputFile = System::IO::File::Open(marshal_as<String^>(outputPath.c_str()),System::IO::FileMode::CreateNew);
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
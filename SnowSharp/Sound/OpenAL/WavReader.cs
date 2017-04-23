using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;

namespace SnowSharp.Sound.OpenAL
{
    class WavReader
    {
        public ALFormat Format { get; private set; }
        public int Size { get; private set; }
        public int Frequency { get; private set; }
        System.IO.Stream wavStream;
        Int64 dataBegin;

        public System.IO.BinaryReader GetDataReader()
        {
            var v = new System.IO.BinaryReader(wavStream);
            v.BaseStream.Position = dataBegin;
            return v;
        }

        public WavReader(string path)
        {
            wavStream = FileSystem.OpenFile(path);
            var wav = new System.IO.BinaryReader(wavStream);

            //Load RIFF Header
            {
                byte[] chunkID = wav.ReadBytes(4);
                Int32 chunkSize = wav.ReadInt32();
                byte[] format = wav.ReadBytes(4);
            }

            //Load WAVE Format
            Int32 sampleRate = 0;
            Int16 numChannels = 0;
            Int16 bitsPerSample = 0;
            {
                byte[] subChunkID = wav.ReadBytes(4);
                Int32 subChunkSize = wav.ReadInt32();
                Int16 audioFormat = wav.ReadInt16();
                numChannels = wav.ReadInt16();
                sampleRate = wav.ReadInt32();
                Int32 byteRate = wav.ReadInt32();
                Int16 blockAlign = wav.ReadInt16();
                bitsPerSample = wav.ReadInt16();

                if (subChunkSize > 16)
                    wav.ReadInt16();
            }

            //Load WAVE Data
            Int32 subChunk2Size = 0;
            {
                byte[] subChunk2ID = wav.ReadBytes(4);
                subChunk2Size = wav.ReadInt32();
            }

            dataBegin = wav.BaseStream.Position;

            //Get Information
            {
                Size = subChunk2Size;
                Int32 Frequency = sampleRate;

                if (numChannels == 1)
                {
                    if (bitsPerSample == 8)
                        Format = ALFormat.Mono8;
                    else if (bitsPerSample == 16)
                        Format = ALFormat.Mono16;
                }
                else if (numChannels == 2)
                {
                    if (bitsPerSample == 8)
                        Format = ALFormat.Stereo8;
                    if (bitsPerSample == 16)
                        Format = ALFormat.Stereo16;
                }
            }
        }
    }
}

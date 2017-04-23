using System;
using OpenTK.Audio.OpenAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Sound.OpenAL
{
    class SoundBufferInMemory : ISoundBuffer,IDisposable
    {
        public SoundBufferInMemory()
        {
            bufferID = AL.GenBuffer();
        }
        public void LoadWAV(string path)
        {

            var wr = new WavReader(path);
            var wav = wr.GetDataReader();
            byte[] data = wav.ReadBytes(wr.Size);




            AL.BufferData(bufferID, wr.Format, data, wr.Size, wr.Frequency);
            
        }

        readonly int bufferID;
        public int SoundBufferID => bufferID;

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                SnowSharp.Core.Schedule(() => AL.DeleteBuffer(bufferID));

                disposedValue = true;
            }
        }

         ~SoundBufferInMemory() {
           Dispose(false);
         }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

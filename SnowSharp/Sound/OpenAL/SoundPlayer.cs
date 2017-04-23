using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Audio.OpenAL;
namespace SnowSharp.Sound.OpenAL
{
    class SoundPlayer : Sound.SoundPlayer,IDisposable
    {
        public SoundPlayer()
        {
            sourceID = AL.GenSource();
        }
        public override float Gain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Looping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int QueuedBuffer => throw new NotImplementedException();

        public override int QueueProcessedBuffer => throw new NotImplementedException();

        public override void ClearBuffers()
        {
            throw new NotImplementedException();
        }

        public override void DequeueBuffer(int n)
        {
            throw new NotImplementedException();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Play()
        {
            AL.Source(sourceID, ALSourcef.Gain, 1.0f);
            AL.SourcePlay(sourceID);
        }

        public override void QueueBuffer(ISoundBuffer buffer)
        {
            throw new NotImplementedException();
        }

        public override void Resume()
        {
            throw new NotImplementedException();
        }

        public override void SetBuffer(ISoundBuffer buffer)
        {
            StreamMode = false;
            soundBuffer = buffer;
            AL.Source(sourceID, ALSourcei.Buffer,buffer.SoundBufferID);
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        bool StreamMode { get; set; }
        int sourceID;
        //StaticMode
        ISoundBuffer soundBuffer = null;

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                Core.Schedule(() => AL.DeleteSource(sourceID));

                disposedValue = true;
            }
        }

         ~SoundPlayer() {
           Dispose(false);
         }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenTK.Audio;

namespace SnowSharp.Sound.OpenAL
{
    public class SoundFactory : Sound.SoundFactory
    {
        public override ISoundBuffer LoadFromStream(BinaryReader stream, int size)
        {
            throw new NotImplementedException();
        }

        public override ISoundBuffer LoadWave(string waveFile)
        {
            var b = new SoundBufferInMemory();
            b.LoadWAV(waveFile);
            return b;
        }

        public override Sound.SoundPlayer CreatePlayer()
        {
            return new SoundPlayer();
        }

        public SoundFactory()
        {

            ctx = new AudioContext();
           
            ctx.MakeCurrent();

            var alDevice = OpenTK.Audio.OpenAL.Alc.OpenDevice(null);
            alCtx = OpenTK.Audio.OpenAL.Alc.CreateContext(alDevice,(int[])(null));
            OpenTK.Audio.OpenAL.Alc.MakeContextCurrent(alCtx);
        }

        public AudioContext ctx;
        public OpenTK.ContextHandle alCtx;
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Sound
{

    /// <summary>
    /// 音频工厂
    /// </summary>
    public abstract class SoundFactory
    {

        /// <summary>
        /// 从WAV文件加载音频
        /// </summary>
        /// <param name="waveFile">音频文件名</param>
        /// <returns></returns>
        public abstract ISoundBuffer LoadWave(string waveFile);


        /// <summary>
        /// 从流加载音频
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="size">加载的大小</param>
        /// <returns></returns>
        public abstract ISoundBuffer LoadFromStream(BinaryReader stream, int size);
    }
}

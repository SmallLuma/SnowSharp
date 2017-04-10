using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Sound
{

    /// <summary>
    /// 音频缓存区
    /// </summary>
    public interface ISoundBuffer
    {

        /// <summary>
        /// 音频大小
        /// </summary>
        int Size
        {
            get;
        }
    }
}

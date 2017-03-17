using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 帧缓存
    /// </summary>
    public interface IFrameBuffer
    {

        /// <summary>
        /// FrameBuffer的纹理
        /// </summary>
        ITexture Texture
        {
            get;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 材质
    /// </summary>
    public interface IMateria
    {

        /// <summary>
        /// 纹理
        /// </summary>
        ITexture Texture{
            set;
            get;
        }

        /// <summary>
        /// 混合模式
        /// </summary>
        BlendMode BlendMode
        {
            set;
            get;
        }
    }
}

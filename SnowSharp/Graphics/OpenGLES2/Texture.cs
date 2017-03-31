using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Texture : ITexture
    {
        public virtual TextureWarpMode WarpMode { set => throw new NotImplementedException(); }
    }
}

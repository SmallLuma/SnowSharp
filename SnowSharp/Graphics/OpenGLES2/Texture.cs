using System;
using OpenTK.Graphics.ES20;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Texture : ITexture
    {
        public virtual TextureWarpMode WarpMode {
            set
            {
                switch (value)
                {
                    case TextureWarpMode.Repeat:
                        textureWarpMode = TextureWrapMode.Repeat;
                        break;
                    case TextureWarpMode.Clamp:
                        textureWarpMode = TextureWrapMode.Clamp;
                        break;
                }
            }
        }

        protected TextureWrapMode textureWarpMode = TextureWrapMode.Repeat;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SnowSharp.Graphics.OpenGLES2
{
    class TextureUnited2D : Texture2D, ITextureUnited2D
    {
        public override TextureWarpMode WarpMode { set => throw new NotImplementedException(); }

        public Vector4d GetUnit(uint unitNum)
        {
            throw new NotImplementedException();
        }

        public override void LoadFromFile(string file)
        {
            throw new NotImplementedException();
        }
    }
}

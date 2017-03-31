using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Texture2D : Texture, ITexture2D
    {

        public virtual void LoadFromFile(string file)
        {
            var bin = new BinaryReader(FileSystem.OpenFile(file));

            var sst = new SSTReader(bin);

            BindTexture();
            var texSize = sst.Size;
            GL.TexImage2D(TextureTarget2d.Texture2D, 0, TextureComponentCount.Rgba, (int)texSize.X, (int)texSize.Y,0,PixelFormat.Rgba,PixelType.Byte, sst.Data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        }

        public override void BindTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, TextureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)textureWarpMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)textureWarpMode);
        }

        
    }
}

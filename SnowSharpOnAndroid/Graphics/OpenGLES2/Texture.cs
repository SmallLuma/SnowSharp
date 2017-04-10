using System;
using OpenTK.Graphics.ES20;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.OpenGLES2
{
    abstract class Texture : ITexture,IDisposable
    {
        public Texture()
        {
            textureID = GL.GenTexture();
        }

        public virtual TextureWarpMode WarpMode {
            set
            {
                switch (value)
                {
                    case TextureWarpMode.Repeat:
                        textureWarpMode = TextureWrapMode.Repeat;
                        break;
                    case TextureWarpMode.Clamp:
                        textureWarpMode = TextureWrapMode.ClampToEdge;
                        break;
                }
            }
        }

        public abstract void BindTexture();

        protected int TextureID
        {
            get => textureID;
        }

        protected TextureWrapMode textureWarpMode = TextureWrapMode.Repeat;
        int textureID;

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                Core.Schedule(() => GL.DeleteTexture(textureID));

                disposedValue = true;
            }
        }

         ~Texture() {
           Dispose(false);
         }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

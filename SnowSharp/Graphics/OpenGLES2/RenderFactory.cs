using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Factory;

namespace SnowSharp.Graphics.OpenGLES2
{
    class RenderFactory : Factory.RendererFactory
    {
        public override IFrameBuffer ScreenFrameBuffer => screen;

        public override IShaderLoader CreateShaderLoader()
        {
            return new ShaderLoader();
        }

        public override ITexture2D CreateTexture2D()
        {
            throw new NotImplementedException();
        }

        public override ITexture2D CreateTextureUnited2D()
        {
            throw new NotImplementedException();
        }

        public override Renderer2DFactory GetRenderer2DFactory()
        {
            throw new NotImplementedException();
        }

        private ScreenFrameBuffer screen = new ScreenFrameBuffer();
    }
}

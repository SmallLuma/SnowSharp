using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Factory;

namespace SnowSharp.Graphics.OpenGLES2
{
    sealed class RenderFactory : Factory.RendererFactory
    {
        public override IFrameBuffer ScreenFrameBuffer => screen;

        public override IShaderLoader CreateShaderLoader()
        {
            return new ShaderLoader();
        }

        public override ITexture2D CreateTexture2D()
        {
            return new Texture2D();
        }

        public override ITexture2D CreateTextureUnited2D()
        {
            throw new NotImplementedException();
        }

        public override Renderer2DFactory Renderer2DFactory
        {
            get => r2dFac;
        }

        private readonly ScreenFrameBuffer screen = new ScreenFrameBuffer();
        private readonly Renderer2DFactory r2dFac = new OpenGLES2.Renderer2D.Renderer2DFactory();
    }
}

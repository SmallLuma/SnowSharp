using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Factory;
using SnowSharp.Graphics.Renderer2D;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class Renderer2DFactory : Factory.Renderer2DFactory
    {
        public override IMateria2DLoader CreateMateriaLoader()
        {
            return new Materia2DLoader();
        }

        public override RendererQueue2D CreateRendererQueue()
        {
            throw new NotImplementedException();
        }
    }
}

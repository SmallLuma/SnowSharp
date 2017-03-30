using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Renderer2D;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class DrawCall2D : Graphics.Renderer2D.IDrawCall2D
    {
        public IList<float> Verticles => verticles;

        public IList<float>[] TexCoords {
            get => texCoords;
            set => texCoords = (List<float>[])value;
        }

        public IList<float> Colors => colors;

        public IMateria2D Materia { set => mat = value; }

        public IShaderParameter ShaderParameter { get => shaderParam; set => shaderParam = value; }

        public DrawCallType Type { set => type = value; }

        public DrawCall2D(int texCoordSize)
        {
            texCoords = new List<float>[texCoordSize];
        }

        List<float> verticles = new List<float>(), colors = new List<float>();
        List<float>[] texCoords;
        IMateria2D mat;
        IShaderParameter shaderParam;
        DrawCallType type;
    }
}

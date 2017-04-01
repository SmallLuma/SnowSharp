using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using System.Text;
using SnowSharp.Graphics.Renderer2D;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class DrawCall2D : Graphics.Renderer2D.IDrawCall2D
    {
        public IList<Vector2> Verticles => verticles;

        public IList<Vector2>[] TexCoords {
            get => texCoords;
            set => texCoords = (List<Vector2>[])value;
        }

        public IList<Color4> Colors => colors;

        public IMateria2D Materia { set => mat = value; get => mat; }

        public IShaderParameter ShaderParameter { get => shaderParam; set => shaderParam = value; }

        public DrawCallType Type { set => type = value; get => type; }

        public DrawCall2D(int texCoordSize)
        {
            texCoords = new List<Vector2>[texCoordSize];
        }

        List<Vector2> verticles = new List<Vector2>();
        List<Color4> colors = new List<Color4>();
        List<Vector2>[] texCoords;
        IMateria2D mat;
        IShaderParameter shaderParam;
        DrawCallType type;
    }
}

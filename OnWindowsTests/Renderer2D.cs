using System;
using SnowSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnWindows.Tests
{
    [TestClass]
    public class Renderer2D
    {
        [TestMethod]
        public void LoadMateria()
        {
            var wnd = GameWindow.PrepTestWindow();



            var r2d = Core.RendererFactory.GetRenderer2DFactory();

            var shaderLoader = Core.RendererFactory.CreateShaderLoader();
            shaderLoader.VertexShaderSource(@"
#version 110
attribute vec4 SS_Vertex;
uniform mat4 SS_Ortho;
attribute vec4 SS_Color;
varying vec4 color;
void main(){
    color = SS_Color;
    gl_Position = SS_Ortho * SS_Vertex;
}"
            );

            shaderLoader.FragmentShaderSource(@"
#version 110
varying vec4 color;
void main(){
    gl_FragColor = color;
}
");

            var mat2Dloader = r2d.CreateMateriaLoader();
            mat2Dloader.BlendMode = SnowSharp.Graphics.BlendMode.Normal;
            mat2Dloader.TexCoordSize = 0;
            mat2Dloader.Shader = shaderLoader.LoadShader();

            var mat2D = mat2Dloader.LoadMateria();

        }
    }
}

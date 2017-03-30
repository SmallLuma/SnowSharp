using System;
using SnowSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnWindows.Tests
{
    [TestClass]
    public class BasicRenderer
    {

        [TestMethod]
        public void ShaderCompile()
        {
            var v = OnWindows.GameWindow.PrepTestWindow();
            var loader = Core.RendererFactory.CreateShaderLoader();

            loader.VertexShaderSource(@"

#version 110

void main(){
    gl_Position = vec4(1.0,1.0,1.0,1.0);
}"
            );

            loader.FragmentShaderSource(@"
#version 110
void main(){
    gl_FragColor = vec4(1.0f,1.0,1.0,1.0);
}"
            );

            var shader = loader.LoadShader();
        }
    }

}

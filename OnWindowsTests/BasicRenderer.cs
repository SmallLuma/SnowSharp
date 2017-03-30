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
//precision highp float;
void main(){
    gl_Position = vec4(1.0,1.0,1.0,1.0);
}"
            );

            loader.FragmentShaderSource(@"
#version 110
//precision highp float;
uniform sampler2D texture;
uniform vec4 a;
void main(){
    gl_FragColor = texture2D(texture,a.xy);
}"
            );

            loader.SetStaticUniform("texture");
            var shader = loader.LoadShader();
            shader.SetStaticUniform("texture", 0);
            var param = shader.CreateShaderParameter();

            param.SetUniform(shader.GetLocation("a"), new OpenTK.Vector4(1, 2, 3, 4));
        }
    }

}

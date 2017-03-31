using System;
using System.Threading;
using SnowSharp;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnWindows.Tests
{
    public class DrawCallFlusher:GameObject
    {
        public DrawCallFlusher(SnowSharp.Graphics.Renderer2D.IRendererQueue2D rq2d)
        {
            rq = rq2d;
        }

        public List<SnowSharp.Graphics.Renderer2D.IDrawCall2D> DrawCalls
        {
            get => drawCalls;
        }

        public override void OnDraw()
        {
            base.OnDraw();
            foreach (var i in drawCalls)
                rq.PushDrawCall(i);
            rq.Flush();
        }

        public override bool Died
        {
            get => false;
        }

        List<SnowSharp.Graphics.Renderer2D.IDrawCall2D> drawCalls = new List<SnowSharp.Graphics.Renderer2D.IDrawCall2D>();
        SnowSharp.Graphics.Renderer2D.IRendererQueue2D rq;
    }

    [TestClass]
    public class Renderer2D
    {
        [TestMethod]
        public void FirstTriangle()
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
            var drawCall = mat2D.CreateDrawCall();

            drawCall.Verticles.Add(new OpenTK.Vector2(0,-0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(1.0f,0,0,1.0f));

            drawCall.Verticles.Add(new OpenTK.Vector2(0.5f, 0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(0, 1.0f, 0 ,1.0f));

            drawCall.Verticles.Add(new OpenTK.Vector2(0.5f, -0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(0, 0.0f, 0.5f, 1.0f));

            drawCall.Type = SnowSharp.Graphics.Renderer2D.DrawCallType.Triangles;

            var rq = r2d.CreateRendererQueue();
            rq.Target = Core.RendererFactory.ScreenFrameBuffer;
            rq.PushDrawCall(drawCall);
            rq.Flush();

            var flusher = new DrawCallFlusher(rq);
            flusher.DrawCalls.Add(drawCall);
            Core.Objects.Add(flusher);
            Core.Objects.Add(new SnowSharp.GameObjects.Task(() => SnowSharp.Core.Exit(), 300));

            Core.RequestRedraw(50);
            wnd.Run();
        }
    }
}

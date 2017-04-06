using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Platform;
using OpenTK.Platform.Android;
using Android.Views;
using Android.Content;
using Android.Util;
using SnowSharp;

namespace OnAndroid
{
    class GLView1 : AndroidGameView
    {

        class Triangle : GameObject
        {
            public Triangle(SnowSharp.Graphics.Renderer2D.IRendererQueue2D rq,SnowSharp.Graphics.Renderer2D.IDrawCall2D dc)
            {
                renderQueue = rq;
                drawCall = dc;
            }
            public override void OnDraw()
            {
                base.OnDraw();

                renderQueue.PushDrawCall(drawCall);
                renderQueue.Flush();
            }

            public override void OnUpdate()
            {
                base.OnUpdate();
                Core.RequestRedraw(10);
            }

            SnowSharp.Graphics.Renderer2D.IRendererQueue2D renderQueue;
            SnowSharp.Graphics.Renderer2D.IDrawCall2D drawCall;
        }

        public GLView1(Context context) : base(context)
        {
            /*var gm = new OpenTK.Graphics.GraphicsMode(32, 24, 8, 4);
            GraphicsContext = new GraphicsContext(gm, base.WindowInfo,2,0,GraphicsContextFlags.Default);
            GraphicsContext.MakeCurrent(base.WindowInfo);
            GraphicsContext.LoadAll();*/
        }

        // This gets called when the drawing surface is ready
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Core.Init(new Core.CoreParamater()
            {
                exitAct = () => Close(),
                swapAct = () => SwapBuffers()
            }
            );

            var matLoader = Core.RendererFactory.Renderer2DFactory.CreateMateriaLoader();
            matLoader.BlendMode = SnowSharp.Graphics.BlendMode.Addtive;
            matLoader.TexCoordSize = 0;

            var shaderLoader = Core.RendererFactory.CreateShaderLoader();
            shaderLoader.VertexShaderSource(@"
attribute vec4 SS_Vertex;
uniform mat4 SS_Ortho;
attribute vec4 SS_Color;
varying vec4 color;
void main(){
    color = SS_Color;
    gl_Position = SS_Ortho * SS_Vertex;
}
");

            shaderLoader.FragmentShaderSource(@"
varying vec4 color;
void main(){
    gl_FragColor = color;
}
");
            matLoader.Shader = shaderLoader.LoadShader();
            var mat = matLoader.LoadMateria();

            var drawCall = mat.CreateDrawCall();

            drawCall.Verticles.Add(new OpenTK.Vector2(0, -0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(1.0f, 0, 0, 1.0f));
            //drawCall.TexCoords[0].Add(new OpenTK.Vector2(0, 0));

            drawCall.Verticles.Add(new OpenTK.Vector2(0.5f, 0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(0, 1.0f, 0, 1.0f));
            //drawCall.TexCoords[0].Add(new OpenTK.Vector2(0, 1));

            drawCall.Verticles.Add(new OpenTK.Vector2(0.5f, -0.5f));
            drawCall.Colors.Add(new OpenTK.Graphics.Color4(0, 0.0f, 0.5f, 1.0f));
            //drawCall.TexCoords[0].Add(new OpenTK.Vector2(1, 1));

            drawCall.Type = SnowSharp.Graphics.Renderer2D.DrawCallType.Triangles;

            var rq = Core.RendererFactory.Renderer2DFactory.CreateRendererQueue();
            rq.Target = Core.RendererFactory.ScreenFrameBuffer;
            rq.Ortho = new Box2()
            {
                Left = -2.0f,
                Right = 2.0f,
                Top = -2.0f,
                Bottom = 2.0f
            };

            Core.Objects.Add(new Triangle(rq, drawCall));

            Run();
        }

        // This method is called everytime the context needs
        // to be recreated. Use it to set any egl-specific settings
        // prior to context creation
        //
        // In this particular case, we demonstrate how to set
        // the graphics mode and fallback in case the device doesn't
        // support the defaults
        protected override void CreateFrameBuffer()
        {
            // the default GraphicsMode that is set consists of (16, 16, 0, 0, 2, false)
            try
            {
                Log.Verbose("GLCube", "Loading with default settings");

                // if you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose("GLCube", "{0}", ex);
            }

            // this is a graphics setting that sets everything to the lowest mode possible so
            // the device returns a reliable graphics setting.
            try
            {
                Log.Verbose("GLCube", "Loading with custom Android settings (low mode)");
                GraphicsMode = new AndroidGraphicsMode(0, 0, 0, 0, 0, false);

                // if you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose("GLCube", "{0}", ex);
            }
            throw new Exception("Can't load egl, aborting");
        }

        // This gets called on each frame render
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            Core.OnDraw();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            Core.OnUpdate();
        }

    }
}

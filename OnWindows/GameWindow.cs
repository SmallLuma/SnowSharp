using OpenTK;
using System.Threading;

namespace OnWindows
{
    public class GameWindow:OpenTK.GameWindow
    {
        public GameWindow(int width, int height, string title, GameWindowFlags options):
            base(width, height,OpenTK.Graphics.GraphicsMode.Default,title,options)
        {
            SnowSharp.Core.CoreParamater param;
            param.exitAct = () => Exit();
            param.swapAct = () => SwapBuffers();
            param.render2DFactory = null;
            SnowSharp.Core.Init(param);
            timer.Start();
            this.VSync = VSyncMode.Adaptive;
        }

        public new void Run()
        {
            base.Run();
            
            timer.Start();
        }
        
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            SnowSharp.Core.OnDraw();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            SnowSharp.Core.OnUpdate();

            if (timer.ElapsedMilliseconds > 1000)
            {
                timer.Restart();
                Title = "FPS:" + SnowSharp.Core.FramesPerSecond + " LPS:" + SnowSharp.Core.UpdatesPerSecond;
            }
            
        }

        public static GameWindow PrepTestWindow()
        {
            return new GameWindow(1280, 720, "Hello Snow#", GameWindowFlags.FixedWindow);
        }

        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    }
}

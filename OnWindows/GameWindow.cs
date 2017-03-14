using OpenTK;

namespace OnWindows
{
    public class GameWindow:OpenTK.GameWindow
    {
        public GameWindow(int width, int height, OpenTK.Graphics.GraphicsMode mode, string title, GameWindowFlags options):
            base(width, height, mode, title, options)
        {
            SnowSharp.Core.Init(()=>Exit(),() => SwapBuffers());
        }

        public new void Run()
        {
            Run(60, 60);
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
        }

        public static GameWindow PrepTestWindow()
        {
            return new GameWindow(1280, 720, new OpenTK.Graphics.GraphicsMode(), "Hello Snow#", GameWindowFlags.FixedWindow);
        }
    }
}

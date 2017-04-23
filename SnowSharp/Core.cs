using OpenTK.Graphics.ES11;
using SnowSharp.GameObjects;
using System;

namespace SnowSharp
{
    public static class Core
    {

        /// <summary>
        /// 引擎参数
        /// </summary>
        public struct CoreParamater {

            /// <summary>
            /// 用于退出引擎的动作
            /// </summary>
            public Action exitAct;


            /// <summary>
            /// 用于刷新屏幕的动作
            /// </summary>
            public Action swapAct;
        }


        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="init">引擎参数</param>
        public static void Init(CoreParamater init)
        {
            rootGameObject.AlwaysAlive = true;
            param = init;
            timer.Start();
        }


        /// <summary>
        /// 每次更新逻辑时执行
        /// </summary>
        public static void OnUpdate()
        {
            rootGameObject.OnUpdate();
            updates++;
            engineThreadSchedule.Do();
        }


        /// <summary>
        /// 每次需要绘图时执行
        /// </summary>
        public static void OnDraw()
        {
            if (redrawFrames > 0)
            {
                redrawFrames--;
                renderState.ClearScreen();

                rootGameObject.OnDraw();

                param.swapAct();
            }

            frames++;
            if (timer.ElapsedMilliseconds > 1000)
            {
                framePerSecond = frames;
                updatePerSecond = updates;
                frames = 0;
                updates = 0;
                timer.Restart();
            }
        }


        /// <summary>
        /// 每秒帧数
        /// </summary>
        public static uint FramesPerSecond
        {
            get => framePerSecond;

        }


        /// <summary>
        /// 退出
        /// </summary>
        public static void Exit()
        {
            engineThreadSchedule.Do();
            param.exitAct();
        }


        /// <summary>
        /// 每秒更新数
        /// </summary>
        public static uint UpdatesPerSecond
        {
            get => updatePerSecond;
        }


        /// <summary>
        /// 请求重绘制
        /// </summary>
        /// <param name="frames">请求的帧数</param>
        public static void RequestRedraw(int frames)
        {
            redrawFrames = redrawFrames < frames ? frames : redrawFrames;
        }


        /// <summary>
        /// 游戏物体根节点
        /// 在此处获取根节点以添加和删除游戏物体
        /// </summary>
        public static GameObjectList Objects
        {
            get => rootGameObject;

        }



        /// <summary>
        /// 从其他线程委托一个计划到主线程
        /// 对OpenGL资源的回收必须委托到此处
        /// </summary>
        /// <param name="act">计划</param>
        public static void Schedule(Action act)
        {
            engineThreadSchedule.Add(act);
        }


        /// <summary>
        /// 获取渲染工厂
        /// </summary>
        public static Graphics.Factory.RendererFactory RendererFactory
        {
            get => renderState.RenderFactory;
        }
        
        /// <summary>
        /// 获取声音工厂
        /// </summary>
        /*public static Sound.SoundFactory SoundFactory
        {
            get => sound;
        }*/

        /// <summary>
        /// 获取渲染状态
        /// </summary>
        internal static Graphics.IRendererState RenderState
        {
            get => renderState;
        }

        #region private

        static uint frames = 0;
        static uint updates = 0;
        static uint framePerSecond = 0;
        static uint updatePerSecond = 0;
        static System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        static Graphics.IRendererState renderState = new Graphics.OpenGLES2.RendererState();

        static Util.Schedule engineThreadSchedule = new Util.Schedule();
        static int redrawFrames = 2;



        static GameObjectList rootGameObject = new GameObjectList();

        static CoreParamater param;
       // static Sound.SoundFactory sound = new Sound.OpenAL.SoundFactory();

        #endregion
    }
}

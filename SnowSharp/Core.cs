using OpenTK.Graphics.ES11;
using SnowSharp.GameObjects;
using System;

namespace SnowSharp
{
    public static class Core
    {


        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="exitAct">要求传入用于退出游戏的操作</param>
        /// <param name="swapAct">要求传入用来交换屏幕帧缓存的操作</param>
        public static void Init(Action exitAct,Action swapAct)
        {
            rootGameObject.AlwaysAlive = true;
            exiter = exitAct;
            swapper = swapAct;
        }

        /// <summary>
        /// 每次更新逻辑时执行
        /// </summary>
        public static void OnUpdate()
        {
            rootGameObject.OnUpdate();
        }


        /// <summary>
        /// 每次需要绘图时执行
        /// </summary>
        public static void OnDraw()
        {
            if (redrawFrames > 0)
            {
                redrawFrames--;
                GL.ClearColor(0, 0, 0, 1);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                rootGameObject.OnDraw();

                swapper();
            }
        }


        /// <summary>
        /// 请求重绘制
        /// </summary>
        /// <param name="frames">请求的帧数</param>
        public static void RequestRedraw(int frames)
        {
            redrawFrames = redrawFrames < frames ? frames : redrawFrames;
        }
        static int redrawFrames = 2;


        /// <summary>
        /// 游戏物体根节点
        /// 在此处获取根节点以添加和删除游戏物体
        /// </summary>
        public static GameObjectList Objects
        {
            get
            {
                return rootGameObject;
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        public static void Exit()
        {
            exiter();
        }

        static Action swapper;

        static GameObjectList rootGameObject = new GameObjectList();

        static Action exiter;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.ES11;

namespace SnowSharp
{
    public static class Core
    {
        public static void OnUpdate()
        {
            logics.OnUpdate();
        }

        public static void OnDraw()
        {
            if (redrawFrames > 0)
            {
                redrawFrames--;
                GL.ClearColor(0, 0, 0, 1);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                swapper();
            }
        }

        
        /// <summary>
        /// 请求刷新
        /// 如果需要刷新屏幕，需要在此处填入需要刷新多少帧，用于刷新屏幕。
        /// 仅在请求刷新屏幕时才会刷新
        /// </summary>
        /// <param name="frames">请求的帧数</param>
        public static void RequestRedraw(int frames)
        {
            redrawFrames = redrawFrames < frames ? frames : redrawFrames;
        }
        private static int redrawFrames;

        
        /// <summary>
        /// 这是个刷新器，你需要传入一个Action，它用于做Swap动作，由引擎来负责Swap。
        /// </summary>
        public static Action Swapper
        {
            set
            {
                swapper = value;
            }
            get
            {
                return swapper;
            }
        }

        public static LogicList Logics
        {
            get
            {
                return logics;
            }

            set
            {
                logics = value;
            }
        }

        /// <summary>
        /// 设置退出器，应该由引擎的所在环境提供
        /// </summary>
        public static Action Exiter
        {
            get
            {
                return exiter;
            }

            set
            {
                exiter = value;
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        public static void Exit()
        {
            Exiter();
        }

        private static Action swapper;

        private static LogicList logics = new LogicList();

        private static Action exiter;

    }
}

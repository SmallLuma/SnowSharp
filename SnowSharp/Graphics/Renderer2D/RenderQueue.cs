using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 渲染队列
    /// </summary>
    public class RenderQueue
    {

        /// <summary>
        /// 渲染 队列帧
        /// </summary>
        public struct QueueFrame
        {

            /// <summary>
            /// DrawCall
            /// </summary>
            public IDrawCall drawCall;


            /// <summary>
            /// 材质
            /// </summary>
            public IMateria materia;


            /// <summary>
            /// 是否可以和另外一个队列帧合并
            /// </summary>
            /// <param name="other">另一个队列帧</param>
            /// <returns>是否可合并</returns>
            internal bool Appendable(QueueFrame other)
            {
                return materia == other.materia && drawCall.Type == other.drawCall.Type;
            }

            /// <summary>
            /// 和另一个队列帧合并
            /// </summary>
            /// <param name="other">另一个队列帧</param>
            internal void Append(QueueFrame other)
            {
                drawCall.Append(other.drawCall);
            }
        }


        /// <summary>
        /// 添加一个DrawCall
        /// </summary>
        /// <param name="queueFrame">渲染队列帧</param>
        public void PushDrawCall(QueueFrame queueFrame)
        {
            if (queueFrames.Count > 0) {
                if (queueFrames.Last().Appendable(queueFrame)){
                    queueFrames.Last().Append(queueFrame);
                    return;
                }
            }

            queueFrames.Enqueue(queueFrame);
        }


        /// <summary>
        /// 立即渲染
        /// </summary>
        public void Flush()
        {
            var state = Core.Render2D.GetDrawState();
            state.CurrentFrameBuffer = target;
            while(queueFrames.Count > 0)
            {
                var f = queueFrames.Dequeue();
                state.CurrentMateria = f.materia;
                state.Draw(f.drawCall);
            }

            state.CurrentMateria = null;
            state.CurrentFrameBuffer = null;
        }


        /// <summary>
        /// 渲染到的目标帧缓存
        /// </summary>
        public IFrameBuffer Target
        {
            set
            {
                target = value;
            }
        }

        Queue<QueueFrame> queueFrames = new Queue<QueueFrame>();
        IFrameBuffer target;
    }
}

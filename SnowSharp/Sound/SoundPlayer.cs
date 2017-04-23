using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SnowSharp.Sound
{

    /// <summary>
    /// 音频播放器
    /// </summary>
    public abstract class SoundPlayer
    {

        /// <summary>
        /// 增益
        /// </summary>
        public abstract float Gain
        {
            set;
            get;
        }

        /// <summary>
        /// 是否正在循环
        /// </summary>
        public abstract bool Looping
        {
            set;
            get;
        }


        /// <summary>
        /// 已经入队的Buffer数
        /// </summary>
        public abstract int QueuedBuffer
        {
            get;
        }


        /// <summary>
        /// 已经处理过的Buffer数量
        /// </summary>
        public abstract int QueueProcessedBuffer
        {
            get;
        }

        /// <summary>
        /// 在播放队列中添加Buffer
        /// 使用流式播放，将会取消SetBuffer的内容。
        /// </summary>
        /// <param name="buffer">要加入的Buffer</param>
        public abstract void QueueBuffer(ISoundBuffer buffer);


        /// <summary>
        /// 从队列中弹出音频
        /// </summary>
        /// <param name="n">弹出数量</param>
        public abstract void DequeueBuffer(int n);


        /// <summary>
        /// 清空队列
        /// </summary>
        public abstract void ClearBuffers();



        /// <summary>
        /// 设置要播放的Buffer
        /// 使用静态播放，将会清空队列内容。
        /// </summary>
        /// <param name="buffer">Buffer</param>
        public abstract void SetBuffer(ISoundBuffer buffer);


        /// <summary>
        /// 播放
        /// </summary>
        public abstract void Play();


        /// <summary>
        /// 停止
        /// </summary>
        public abstract void Stop();


        /// <summary>
        /// 暂停
        /// </summary>
        public abstract void Pause();


        /// <summary>
        /// 继续
        /// </summary>
        public abstract void Resume();
    }
}

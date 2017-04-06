using System.Collections.Generic;

namespace SnowSharp.Sound.Simple.SimpleBGM
{

    /// <summary>
    /// BGM播放器
    /// </summary>
    public abstract class IBGMPlayer:GameObject
    {

        /// <summary>
        /// BGM音轨
        /// </summary>
        public abstract IList<IBGMTrack> Tracks
        {
            get;
        }


        /// <summary>
        /// 播放
        /// </summary>
        public abstract void Play();


        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="funcLine">淡化使用的曲线</param>
        /// <param name="fadeFrames">淡化时间</param>
        public abstract void Pause(Math.Funcs.FuncLine funcLine = null,int fadeFrames = 0);


        /// <summary>
        /// 从暂停中恢复
        /// </summary>
        /// <param name="funcLine">淡化使用的曲线</param>
        /// <param name="fadeFrames">淡化时间</param>
        public abstract void Resume(Math.Funcs.FuncLine funcLine = null, int fadeFrames = 0);


        /// <summary>
        /// 停止声音
        /// </summary>
        /// <param name="funcLine">淡化使用的曲线</param>
        /// <param name="fadeFrames">淡化时间</param>
        public abstract void Stop(Math.Funcs.FuncLine funcLine = null, int fadeFrames = 0);

        /// <summary>
        /// 创建BGM轨道
        /// </summary>
        /// <returns>轨道</returns>
        public abstract IBGMTrack CreateBGMTrack();
    }
}

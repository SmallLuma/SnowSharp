namespace SnowSharp.Sound.Simple.SimpleBGM
{

    /// <summary>
    /// BGM音轨
    /// </summary>
    public interface IBGMTrack
    {

        /// <summary>
        /// BGM头段音频
        /// </summary>
        ISoundData HeadData
        {
            get;
            set;
        }


        /// <summary>
        /// BGM循环段音频
        /// </summary>
        ISoundData LoopData
        {
            get;
            set;
        }


        /// <summary>
        /// 声相
        /// </summary>
        double Pan
        {
            get;
            set;
        }


        /// <summary>
        /// 音量
        /// </summary>
        double Volume
        {
            set;
            get;
        }


        /// <summary>
        /// 淡化音量
        /// </summary>
        /// <param name="fadeLine">淡化使用的曲线</param>
        /// <param name="time">淡化需要的帧数</param>
        /// <param name="volume">淡化后的音量</param>
        void FadeVolume(Math.Funcs.FuncLine fadeLine, int time, double volume);

    }
}

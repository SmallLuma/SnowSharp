namespace SnowSharp.Sound.Simple
{

    /// <summary>
    /// 简单音效播放器
    /// </summary>
    public interface ISimpleSoundEffect
    {

        /// <summary>
        /// 从数据播放音效
        /// </summary>
        /// <param name="data">音频数据</param>
        /// <param name="pan">声相</param>
        /// <param name="volume">音量</param>
        void Play(ISoundData data, double pan, double volume);
    }
}

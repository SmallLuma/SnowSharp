namespace SnowSharp.Sound.Simple
{

    /// <summary>
    /// 声音工厂
    /// </summary>
    public abstract class SimpleSoundFactory
    {

        /// <summary>
        /// 获取音效播放器
        /// </summary>
        public abstract ISimpleSoundEffect SoundEffect
        {
            get;
        }

        /// <summary>
        /// 创建BGM播放器
        /// </summary>
        /// <returns>创建后的BGM播放器</returns>
        public abstract SimpleBGM.IBGMPlayer CreateBGMPlayer();


        /// <summary>
        /// 加载声音数据
        /// </summary>
        /// <param name="wavFile">声音文件</param>
        /// <returns>声音数据</returns>
        public abstract ISoundData LoadSoundData(string sbmFile);
    }
}

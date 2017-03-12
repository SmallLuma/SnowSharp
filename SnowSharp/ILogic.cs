namespace SnowSharp
{

    /// <summary>
    /// 逻辑
    /// 纯粹的逻辑
    /// </summary>
    public interface ILogic
    {

        /// <summary>
        /// 每帧执行一次
        /// </summary>
        void OnUpdate();


        /// <summary>
        /// 逻辑是否已经死亡
        /// </summary>
        bool Died
        {
            get;
        }
    }
}

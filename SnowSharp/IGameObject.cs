namespace SnowSharp
{

    /// <summary>
    /// 游戏物体
    /// </summary>
    public interface IGameObject
    {

        /// <summary>
        /// 要求绘制的时候执行
        /// </summary>
        void OnDraw();

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

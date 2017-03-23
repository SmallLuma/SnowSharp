namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 绘制状态集
    /// </summary>
    interface IDrawState
    {

        /// <summary>
        /// 当前材质
        /// </summary>
        IMateria CurrentMateria
        {
            set;
        }

        /// <summary>
        /// 当然帧缓存
        /// </summary>
        IFrameBuffer CurrentFrameBuffer
        {
            set;
        }

        /// <summary>
        /// 绘制DrawCall
        /// </summary>
        /// <param name="drawCall">要绘制的DrawCall</param>
        void Draw(IDrawCall drawCall);

        /// <summary>
        /// 清空当前帧缓存
        /// </summary>
        void Clear();
    }
}

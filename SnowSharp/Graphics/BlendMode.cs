namespace SnowSharp.Graphics
{
    /// <summary>
    /// 纹理混合模式
    /// </summary>
    public enum BlendMode
    {

        /// <summary>
        /// 禁止混合
        /// </summary>
        Disabled,

        /// <summary>
        /// 普通Alpha混合
        /// </summary>
        Normal,

        /// <summary>
        /// 加法混合
        /// </summary>
        Addtive,


        /// <summary>
        /// 乘法混合
        /// </summary>
        Multiply,


        /// <summary>
        /// 二倍乘法混合
        /// </summary>
        Multiply2X,


        /// <summary>
        /// 变暗
        /// </summary>
        Darken,


        /// <summary>
        /// 变亮
        /// </summary>
        Lighten,


        /// <summary>
        /// 滤色
        /// </summary>
        Screen,


        /// <summary>
        /// 线形减淡
        /// </summary>
        LinearDodge
    }
}

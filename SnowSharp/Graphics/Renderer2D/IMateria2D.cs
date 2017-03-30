namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 2D材质
    /// </summary>
    public interface IMateria2D
    {

        /// <summary>
        /// 创建DrawCall
        /// </summary>
        /// <returns>DrawCall对象</returns>
        IDrawCall2D CreateDrawCall();
    }
}

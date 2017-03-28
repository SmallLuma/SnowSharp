namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 2D材质
    /// </summary>
    public interface IMateria2D
    {

        /// <summary>
        /// 着色器参数表
        /// </summary>
        IShaderParameter ShaderParameter
        {
            set;
            get;
        }
    }
}

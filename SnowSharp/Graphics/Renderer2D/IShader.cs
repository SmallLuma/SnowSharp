namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 着色器
    /// </summary>
    public interface IShader
    {

        /// <summary>
        /// 加载着色器
        /// </summary>
        /// <param name="vertPath">顶点着色器路径</param>
        /// <param name="fragPath">片元着色器路径</param>
        void LoadShader(string vertPath, string fragPath);

    }
}

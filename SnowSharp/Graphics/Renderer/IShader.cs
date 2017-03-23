namespace SnowSharp.Graphics.Renderer
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


        /// <summary>
        /// 获取着色器参数的访问器
        /// </summary>
        /// <param name="uniformName">参数名称</param>
        /// <returns>访问器</returns>
        int GetParamLocation(string uniformName);

    }
}

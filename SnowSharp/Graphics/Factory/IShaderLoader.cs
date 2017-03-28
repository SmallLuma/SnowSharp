namespace SnowSharp.Graphics.Factory
{

    /// <summary>
    /// 着色器加载器
    /// </summary>
    public interface IShaderLoader
    {

        /// <summary>
        /// 写入顶点着色器代码
        /// </summary>
        /// <param name="vertexShaderCode">顶点着色器代码</param>
        void VertexShaderSource(string vertexShaderCode);


        /// <summary>
        /// 从文件加载顶点着色器代码
        /// </summary>
        /// <param name="path">文件路径</param>
        void LoadVertexShaderSourceFile(string path);


        /// <summary>
        /// 写入片元着色器代码
        /// </summary>
        /// <param name="fragShaderCode">片元着色器代码</param>
        void FragmentShaderSource(string fragShaderCode);


        /// <summary>
        /// 从文件加载片段着色器代码
        /// </summary>
        /// <param name="path">文件路径</param>
        void LoadFragmentShaderSourceFile(string path);

        /// <summary>
        /// 获取着色器对象
        /// </summary>
        /// <returns>着色器对象</returns>
        IShader LoadShader();
    }
}

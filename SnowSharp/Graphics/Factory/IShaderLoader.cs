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
        /// 把一个变量设置为Shader全局相关的变量
        /// </summary>
        /// <param name="uniformName">变量名称</param>
        void SetStaticUniform(string uniformName);


        /// <summary>
        /// 重设该对象
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取着色器对象
        /// </summary>
        /// <returns>着色器对象</returns>
        IShader LoadShader();
    }
}

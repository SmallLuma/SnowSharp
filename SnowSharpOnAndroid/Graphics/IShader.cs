using OpenTK;

namespace SnowSharp.Graphics
{

    /// <summary>
    /// 着色器
    /// </summary>
    public interface IShader
    {

        /// <summary>
        /// 创建着色器参数表
        /// </summary>
        /// <returns>着色器参数表对象</returns>
        IShaderParameter CreateShaderParameter();


        /// <summary>
        /// 获取uniform变量访问器
        /// </summary>
        /// <param name="uniformName">变量名字</param>
        /// <returns>访问器</returns>
        int GetLocation(string uniformName);


        /// <summary>
        /// 设置静态Uniform
        /// </summary>
        /// <param name="uniformName">变量名</param>
        /// <param name="value">值</param>
        void SetStaticUniform(string uniformName, int value);

        /// <summary>
        /// 设置静态Uniform
        /// </summary>
        /// <param name="uniformName">变量名</param>
        /// <param name="value">值</param>
        void SetStaticUniform(string uniformName, Matrix4 value);
    }
}

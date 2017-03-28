using OpenTK;

namespace SnowSharp.Graphics
{

    /// <summary>
    /// 着色器参数
    /// 该参数表不包含任何关于采样器的内容
    /// </summary>
    public interface IShaderParameter
    {
        void SetUniform(uint loc, float f);
        void SetUniform(uint loc, Vector2 v);
        void SetUniform(uint loc, Vector3 v);
        void SetUniform(uint loc, Vector4 v);
    }
}

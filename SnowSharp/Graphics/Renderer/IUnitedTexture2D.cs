using OpenTK;

namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 含有多个图像的2D合并纹理
    /// </summary>
    public interface IUnitedTexture2D
    {

        /// <summary>
        /// 获取第i个剪裁框
        /// </summary>
        /// <param name="i">索引</param>
        /// <returns>剪裁框位置</returns>
        Vector4d GetClipRect(int i);
    }
}

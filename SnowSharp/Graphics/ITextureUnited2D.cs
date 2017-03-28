using OpenTK;

namespace SnowSharp.Graphics
{

    /// <summary>
    /// 划分区域的2D纹理
    /// </summary>
    public interface ITextureUnited2D:ITexture2D
    {

        /// <summary>
        /// 纹理区域
        /// </summary>
        /// <param name="unitNum">区域编号</param>
        /// <returns>区域剪裁框</returns>
        Vector4d GetUnit(uint unitNum);
    }
}

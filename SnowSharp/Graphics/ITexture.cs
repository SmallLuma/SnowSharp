namespace SnowSharp.Graphics
{

    /// <summary>
    /// 纹理越界采样方式
    /// </summary>
    public enum TextureWarpMode
    {
        Clamp,
        Repeat
    }


    /// <summary>
    /// 纹理
    /// </summary>
    public interface ITexture
    {

        /// <summary>
        /// 越界采样方式
        /// </summary>
        TextureWarpMode WarpMode
        {
            set;
        }
    }
}

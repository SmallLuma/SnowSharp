using OpenTK;

namespace SnowSharp.Graphics.Renderer2D
{


    /// <summary>
    /// 纹理越界采样模式
    /// </summary>
    public enum WarpMode
    {

        /// <summary>
        /// GL_WARP
        /// </summary>
        Warp,


        /// <summary>
        /// GL_CLAMP
        /// </summary>
        Clamp
    }

    /// <summary>
    /// 纹理
    /// </summary>
    public interface ITexture
    {

        /// <summary>
        /// 越界采样模式
        /// </summary>
        WarpMode WarpMode
        {
            set;
        }
    }
}

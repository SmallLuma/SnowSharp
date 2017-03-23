using OpenTK;

namespace SnowSharp.Graphics.Renderer
{


    /// <summary>
    /// 纹理越界采样方式
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
        /// 越界采样方式
        /// </summary>
        WarpMode WarpMode
        {
            set;
        }


        /// <summary>
        /// 从文件加载纹理
        /// </summary>
        /// <param name="path">文件路径</param>
        void LoadFromFile(string path);
    }
}

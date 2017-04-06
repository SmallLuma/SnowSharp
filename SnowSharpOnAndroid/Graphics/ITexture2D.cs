namespace SnowSharp.Graphics
{

    /// <summary>
    /// 2D纹理
    /// </summary>
    public interface ITexture2D:ITexture
    {

        /// <summary>
        /// 从文件加载纹理
        /// </summary>
        /// <param name="file">文件名</param>
        void LoadFromFile(string file);
    }
}

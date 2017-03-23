namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 渲染器工厂
    /// </summary>
    public abstract class RendererFactory
    {

        /// <summary>
        /// 创建DrawCall
        /// </summary>
        /// <returns>DrawCall</returns>
        public abstract IDrawCall CreateDrawCall();


        /// <summary>
        /// 获取默认屏幕的FrameBuffer
        /// </summary>
        /// <returns>默认屏幕的FrameBuffer</returns>
        public abstract IFrameBuffer GetDefaultFrameBuffer();


        /// <summary>
        /// 创建材质
        /// </summary>
        /// <returns>新的材质</returns>
        public abstract IMateria CreateMateria();

        /// <summary>
        /// 从文件创建材质
        /// </summary>
        /// <returns>新的材质</returns>
        public abstract IMateria CreateMateriaFromFile(string path);


        /// <summary>
        /// 创建2D纹理
        /// </summary>
        /// <returns>新的纹理</returns>
        public abstract ITexture2D CreateTexture2D();

        /// <summary>
        /// 创建含有剪裁框的纹理
        /// </summary>
        /// <returns>新的纹理</returns>
        public abstract IUnitedTexture2D CreateUnitedTexture2D();


        /// <summary>
        /// 获取绘制状态集
        /// </summary>
        /// <returns>绘制状态集</returns>
        internal abstract IDrawState GetDrawState();

    }
}

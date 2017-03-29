namespace SnowSharp.Graphics.Factory
{

    /// <summary>
    /// 渲染器工厂
    /// </summary>
    public abstract class RendererFactory
    {

        /// <summary>
        /// 获取2D渲染器工厂
        /// </summary>
        /// <returns>2D渲染器工厂对象</returns>
        public abstract Renderer2DFactory GetRenderer2DFactory();


        /// <summary>
        /// 创建着色器加载器
        /// </summary>
        /// <returns>着色器加载器对象</returns>
        public abstract IShaderLoader CreateShaderLoader();



        /// <summary>
        /// 获取屏幕帧缓存
        /// </summary>
        /// <returns>屏幕帧缓存</returns>
        public abstract IFrameBuffer ScreenFrameBuffer
        {
            get;
        }


        /// <summary>
        /// 创建2D纹理
        /// </summary>
        /// <returns>2D纹理对象</returns>
        public abstract ITexture2D CreateTexture2D();



        /// <summary>
        /// 创建分块的2D纹理
        /// </summary>
        /// <returns>分块2D纹理对象</returns>
        public abstract ITexture2D CreateTextureUnited2D();
    }
}

namespace SnowSharp.Graphics.Factory
{

    /// <summary>
    /// 材质加载器
    /// </summary>
    public interface IMateria2DLoader
    {

        /// <summary>
        /// 使用的着色器
        /// </summary>
        IShader Shader
        {
            set;
        }

        /// <summary>
        /// 使用的混合模式
        /// </summary>
        BlendMode BlendMode
        {
            set;
        }


        /// <summary>
        /// 设置纹理
        /// </summary>
        /// <param name="num">纹理编号</param>
        /// <param name="texture">纹理</param>
        void SetTexture(int num, ITexture texture);


        /// <summary>
        /// 贴图坐标个数
        /// </summary>
        int TexCoordSize
        {
            set;
        }

        
        /// <summary>
        /// 从RVS读取材质
        /// </summary>
        /// <param name="materiaInfo">RVS材质信息</param>
        void LoadFromRVS(Util.RVSharp materiaInfo);


        /// <summary>
        /// 获取这个材质
        /// </summary>
        /// <returns>材质对象</returns>
        Renderer2D.IMateria2D LoadMateria();
    }
}

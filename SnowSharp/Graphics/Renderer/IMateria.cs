using System.Collections.Generic;

namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 材质
    /// </summary>
    public interface IMateria
    {


        /// <summary>
        /// 设置纹理
        /// </summary>
        /// <param name="index">纹理编号</param>
        /// <param name="tex">纹理</param>
        void SetTexture(int index, ITexture tex);

        /// <summary>
        /// 着色器
        /// </summary>
        IShader Shader
        {
            set;
            get;
        }

        /// <summary>
        /// 着色器参数
        /// </summary>
        ShaderParam ShaderParameter
        {
            get;
            set;
        }

        /// <summary>
        /// 混合模式
        /// </summary>
        BlendMode BlendMode
        {
            set;
            get;
        }

    }
}

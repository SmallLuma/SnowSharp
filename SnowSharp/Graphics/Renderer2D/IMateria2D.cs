namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 2D材质
    /// 
    /// 着色器API:
    ///     uniform mat4 SS_Ortho   坐标系矩阵
    ///     uniform sampler2D SS_Texture[n] 纹理（n为纹理编号）
    ///     attribute vec4 SS_Vertex    顶点
    ///     attribute vec4 SS_Color    颜色
    ///     attribute vec2 SS_TexCoord[n]   贴图坐标（n为贴图坐标编号）
    ///     
    /// </summary>
    public interface IMateria2D
    {

        /// <summary>
        /// 创建DrawCall
        /// </summary>
        /// <returns>DrawCall对象</returns>
        IDrawCall2D CreateDrawCall();
    }
}

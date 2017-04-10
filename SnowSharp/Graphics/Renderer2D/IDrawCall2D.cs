using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// DrawCall类型
    /// </summary>
    public enum DrawCallType
    {
        Points,
        Lines,
        Triangles
    }

    /// <summary>
    /// 2D的DrawCall
    /// </summary>
    public interface IDrawCall2D
    {

        /// <summary>
        /// 顶点列表
        /// </summary>
        IList<Vector2> Verticles
        {
            get;
        }


        /// <summary>
        /// 贴图点列表
        /// </summary>
        IList<Vector2>[] TexCoords
        {
            get;
        }


        /// <summary>
        /// 颜色列表
        /// </summary>
        IList<Color4> Colors
        {
            get;
        }

        /// <summary>
        /// 着色器参数表
        /// </summary>
        IShaderParameter ShaderParameter
        {
            get;
        }

        /// <summary>
        /// DrawCall类型
        /// </summary>
        DrawCallType Type
        {
            set;
        }
    }
}

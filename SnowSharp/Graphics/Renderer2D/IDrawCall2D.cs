using System.Collections.Generic;

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
        IList<float> Verticles
        {
            set;
            get;
        }


        /// <summary>
        /// 贴图点列表
        /// </summary>
        IList<float>[] TexCoords
        {
            set;
            get;
        }


        /// <summary>
        /// 颜色列表
        /// </summary>
        IList<float> Colors
        {
            set;
            get;
        }

        /// <summary>
        /// 材质
        /// </summary>
        IMateria2D Materia
        {
            set;
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

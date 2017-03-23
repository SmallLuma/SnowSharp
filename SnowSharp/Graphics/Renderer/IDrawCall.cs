using System.Collections.Generic;

namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 要绘制的类型
    /// </summary>
    public enum DrawType{
        Points,
        Lines,
        Triangles
    }

    /// <summary>
    /// 绘制调用
    /// </summary>
    public interface IDrawCall
    {

        /// <summary>
        /// 顶点列表
        /// </summary>
        List<float> Verticles
        {
            get;
        }

        /// <summary>
        /// 单个顶点大小
        /// </summary>
        int VertexSize
        {
            set;
        }

        /// <summary>
        /// 纹理贴图
        /// </summary>
        Dictionary<int,List<float>> TexCoords
        {
            get;
        }

        /// <summary>
        /// 纹理贴图大小
        /// </summary>
        Dictionary<int,int> TexCoordSize
        {
            get;
        }

        /// <summary>
        /// 颜色表
        /// </summary>
        List<float> Colors
        {
            get;
        }

        /// <summary>
        /// 绘制类型
        /// </summary>
        DrawType Type
        {
            get;
            set;
        }


        /// <summary>
        /// 将一个DrawCall合并到当前DrawCall上
        /// </summary>
        /// <param name="drawCall">要合并的DrawCall</param>
        void Append(IDrawCall drawCall);
    }
}

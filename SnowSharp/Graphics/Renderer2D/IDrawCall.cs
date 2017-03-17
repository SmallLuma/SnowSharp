using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.Renderer2D
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
        /// 多重纹理贴图
        /// </summary>
        List<float> TexCoords
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

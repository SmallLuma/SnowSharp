using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics
{

    /// <summary>
    /// 渲染器状态
    /// </summary>
    interface IRendererState
    {

        /// <summary>
        /// 设置为2D渲染状态
        /// </summary>
        void SetTo2D();


        /// <summary>
        /// 获取渲染工厂
        /// </summary>
        /// <returns>渲染工厂</returns>
        Factory.RendererFactory RenderFactory
        {
            get;
        }


        /// <summary>
        /// 清空屏幕
        /// </summary>
        void ClearScreen();
    }
}

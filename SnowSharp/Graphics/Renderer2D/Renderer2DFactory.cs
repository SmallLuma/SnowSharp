using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 渲染器工厂
    /// </summary>
    public abstract class Renderer2DFactory
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
        /// 创建FrameBuffer
        /// </summary>
        /// <returns>新的FrameBuffer</returns>
        public abstract IFrameBuffer CreateFrameBuffer();


        /// <summary>
        /// 创建材质
        /// </summary>
        /// <returns>新的材质</returns>
        public abstract IMateria CreateMateria();


        /// <summary>
        /// 创建纹理
        /// </summary>
        /// <returns>新的纹理</returns>
        public abstract ITexture CreateTexture();


        /// <summary>
        /// 获取绘制状态集
        /// </summary>
        /// <returns>绘制状态集</returns>
        internal abstract IDrawState GetDrawState();

    }
}

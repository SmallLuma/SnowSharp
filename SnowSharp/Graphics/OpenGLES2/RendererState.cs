using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Factory;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    class RendererState : IRendererState
    {
        public void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public RendererFactory RenderFactory => renderFactory;

        public void SetTo2D()
        {
            GL.Enable(EnableCap.Blend);
            GL.Disable(EnableCap.DepthTest);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        private OpenGLES2.RenderFactory renderFactory = new OpenGLES2.RenderFactory();

    }
}


/** OpenGL ES 2 2D 状态表 **
 * 
 * 启动的状态：
 * GL_BLEND
 *  
 * 未定义的状态：
 * glBlendMode
 * glUseProgram
 * glBindFrameBuffer
 * 
 * 全部禁用的状态：
 * glActiveTexture
 * glBindBuffer
 * GL_DEPTH_TEST
 *
 * */


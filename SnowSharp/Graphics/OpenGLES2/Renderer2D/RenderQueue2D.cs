using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.ES20;
using SnowSharp.Graphics.Renderer2D;

#pragma warning disable 0618

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    //TODO:此处需要BATCH优化
    sealed class RenderQueue2D : Graphics.Renderer2D.IRendererQueue2D
    {
        public Box2 Ortho {
            set => orthoMatrix = Matrix4.CreateOrthographicOffCenter(value.Left, value.Right, value.Bottom, value.Top, 0, 1);
        }

        public IFrameBuffer Target {
            set => target = value;
        }

        public void Flush()
        {
            Core.RenderState.SetTo2D();
            while (drawCalls.Count > 0)
            {
                var currentDrawCall = drawCalls.Dequeue();
                var currentMateria = (Materia2D)currentDrawCall.Materia;

                currentMateria.Use();



                //Setup shader
                int orthoLoc = currentMateria.Shader2D.GetOrthoUniformLoc();
                if(orthoLoc >= 0)
                     GL.UniformMatrix4(orthoLoc, false, ref orthoMatrix);

                List<Vector2[]> texCoords = new List<Vector2[]>();
                foreach(var i in currentDrawCall.TexCoords)
                {
                    texCoords.Add(i.ToArray());
                }
                currentMateria.Shader2D.SetArrays(currentDrawCall.Verticles.ToArray(), currentDrawCall.Colors.ToArray(), texCoords);

                if (currentDrawCall.ShaderParameter != null)
                  ((ShaderParam)(currentDrawCall.ShaderParameter)).Use();


                //Setup Target
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, target.FrameBufferIndex);


                //Draw
                BeginMode mode = BeginMode.Points;
                switch (currentDrawCall.Type)
                {
                    case DrawCallType.Lines:
                        mode = BeginMode.Lines;
                        break;
                    case DrawCallType.Points:
                        mode = BeginMode.Points;
                        break;
                    case DrawCallType.Triangles:
                        mode = BeginMode.Triangles;
                        break;
                }

                GL.DrawArrays(mode, 0, currentDrawCall.Verticles.Count);

                GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
                currentMateria.Unuse();

            }
        }

        public void PushDrawCall(IDrawCall2D drawCall)
        {
            drawCalls.Enqueue((DrawCall2D)drawCall);
        }

        Matrix4 orthoMatrix = Matrix4.Identity;
        IFrameBuffer target;
        Queue<DrawCall2D> drawCalls = new Queue<DrawCall2D>();
    }
}

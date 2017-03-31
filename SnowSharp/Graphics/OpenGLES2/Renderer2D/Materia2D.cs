using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.ES20;
using SnowSharp.Graphics.Renderer2D;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class Materia2D:Graphics.Renderer2D.IMateria2D
    {
        public Materia2D(Shader shd,ITexture[] tex,int texCoordCount,BlendMode blend)
        {
            shader = new Shader2D(shd, texCoordCount);
            texCoordSize = texCoordCount;
            blendMode = blend;
            texture = tex;
        }

        public void Use()
        {
            shader.Shader.Use();
            if (texture != null)
            {
                for (int i = 0; i < texture.Length; ++i)
                {
                    if (texture[i] != null)
                    {
                        GL.ActiveTexture(TextureUnit.Texture0 + i);

                        //TODO:这里应该改为更通用的Texture，而非Texture2D
                        //GL.BindTexture(TextureTarget.Texture2D, tex[i]);
                    }
                }
            }

            //TODO:实现这里
            switch (blendMode)
            {
                case BlendMode.Disabled:
                    GL.Disable(EnableCap.Blend);
                    break;
                case BlendMode.Normal:
                    break;
                case BlendMode.Addtive:
                    break;
                case BlendMode.Multiply:
                    break;
                case BlendMode.Multiply2X:
                    break;
                case BlendMode.Darken:
                    break;
                case BlendMode.Lighten:
                    break;
                case BlendMode.Screen:
                    break;
                case BlendMode.LinearDodge:
                    break;
            }


        }

        public void Unuse()
        {
            if (blendMode == BlendMode.Disabled)
                GL.Enable(EnableCap.Blend);

            Shader.Unuse();
        }

        public IDrawCall2D CreateDrawCall()
        {
            var drawCall = new DrawCall2D(texCoordSize);
            drawCall.Materia = this;
            drawCall.TexCoords = new List<OpenTK.Vector2>[texCoordSize];
            
            return drawCall;
        }

        public Shader2D Shader2D
        {
            get => shader;
        }

        Shader2D shader;
        ITexture[] texture;
        int texCoordSize;
        BlendMode blendMode;
    }
}

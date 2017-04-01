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

                        ((Texture)texture[i]).BindTexture();
                    }
                }
            }

            switch (blendMode)
            {
                case BlendMode.Disabled:
                    GL.Disable(EnableCap.Blend);
                    break;
                case BlendMode.Blend:
                    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                    break;
                case BlendMode.Addtive:
                    GL.BlendFunc(BlendingFactorSrc.OneMinusDstColor, BlendingFactorDest.One);
                    break;
                case BlendMode.Multiply:
                    GL.BlendFunc(BlendingFactorSrc.DstColor, BlendingFactorDest.Zero);
                    break;
                case BlendMode.Multiply2X:
                    GL.BlendFunc(BlendingFactorSrc.DstColor, BlendingFactorDest.SrcColor);
                    break;
                case BlendMode.Screen:
                    GL.BlendFunc(BlendingFactorSrc.OneMinusDstColor, BlendingFactorDest.One);
                    break;
                case BlendMode.LinearDodge:
                    GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.One);
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
            for (int i = 0; i < texCoordSize; ++i)
                drawCall.TexCoords[i] = new List<OpenTK.Vector2>();


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowSharp.Graphics.Renderer2D;
using SnowSharp.Util;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class Materia2DLoader : Factory.IMateria2DLoader
    {
        public IShader Shader { set => shader = (Shader)value; }

        public BlendMode BlendMode { set => blendMode = value; }

        public void LoadFromRVS(RVSharp materiaInfo)
        {
            throw new NotImplementedException();
        }

        public IMateria2D LoadMateria()
        {
            ITexture[] texs = null;
            if (textures.Count != 0)
            {
                texs = new ITexture[textures.Keys.Max()];

                for (int i = 0; i < texs.Length; ++i)
                {
                    if (textures.TryGetValue(i, out texs[i]))
                    {
                        shader.SetStaticUniform("SS_Texture_" + i, i);
                    }
                }
            }

            return new Materia2D(shader, texs, texCoordSize, blendMode);
        }

        public void SetTexture(int num, ITexture texture)
        {
            textures[num] = texture;
        }

        public int TexCoordSize
        {
            set => texCoordSize = value;
        }

        int texCoordSize;
        Shader shader;
        BlendMode blendMode;
        Dictionary<int, ITexture> textures = new Dictionary<int, ITexture>();
    }
}

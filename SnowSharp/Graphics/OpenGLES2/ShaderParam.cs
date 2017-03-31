using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.ES20;
using OpenTK;

namespace SnowSharp.Graphics.OpenGLES2
{
    class ShaderParam : IShaderParameter
    {
        public ShaderParam(int uniformSize,int[] staticUniforms)
        {
            uniforms = new ShaderUniform[uniformSize];

            for(int i = 0;i < uniforms.Length;i++)
                uniforms[i].type = ShaderUniform.Type.Float;

            foreach (var i in staticUniforms)
                uniforms[i].type = ShaderUniform.Type.StaticUniform;
        }

        public void SetUniform(int loc, float f)
        {
#if DEBUG
            if (uniforms[loc].type == ShaderUniform.Type.StaticUniform)
                throw new Exception("Location " + loc + " is a static uniform.");
#endif
            uniforms[loc].f = f;
            uniforms[loc].type = ShaderUniform.Type.Float;
        }

        public void SetUniform(int loc, Vector2 v)
        {
#if DEBUG
            if (uniforms[loc].type == ShaderUniform.Type.StaticUniform)
                throw new Exception("Location " + loc + " is a static uniform.");
#endif
            uniforms[loc].v2 = v;
            uniforms[loc].type = ShaderUniform.Type.Vector2;
        }

        public void SetUniform(int loc, Vector3 v)
        {
#if DEBUG
            if (uniforms[loc].type == ShaderUniform.Type.StaticUniform)
                throw new Exception("Location " + loc + " is a static uniform.");
#endif
            uniforms[loc].v3 = v;
            uniforms[loc].type = ShaderUniform.Type.Vector3;
        }

        public void SetUniform(int loc, Vector4 v)
        {
#if DEBUG
            if (uniforms[loc].type == ShaderUniform.Type.StaticUniform)
                throw new Exception("Location " + loc + " is a static uniform.");
#endif
            uniforms[loc].v4 = v;
            uniforms[loc].type = ShaderUniform.Type.Vector4;
        }

        public void Use()
        {
            for(int i = 0;i < uniforms.Length; ++i)
            {
                switch (uniforms[i].type)
                {
                    case ShaderUniform.Type.StaticUniform:
                        break;
                    case ShaderUniform.Type.Float:
                        GL.Uniform1(i, uniforms[i].f);
                        break;
                    case ShaderUniform.Type.Vector2:
                        GL.Uniform2(i, uniforms[i].v2);
                        break;
                    case ShaderUniform.Type.Vector3:
                        GL.Uniform3(i, uniforms[i].v3);
                        break;
                    case ShaderUniform.Type.Vector4:
                        GL.Uniform4(i, uniforms[i].v4);
                        break;
                }
            }
        }

        struct ShaderUniform{
            public enum Type
            {
                StaticUniform,
                Float,
                Vector2,
                Vector3,
                Vector4
            }
            public Type type;
            public float f;
            public Vector2 v2;
            public Vector3 v3;
            public Vector4 v4;
            
        }

        ShaderUniform[] uniforms;
    }
}

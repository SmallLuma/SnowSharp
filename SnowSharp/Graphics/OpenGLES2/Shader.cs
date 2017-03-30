using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Shader:IShader
    {
        public Shader(int index,string[] staticUniformNames)
        {
            shaderIndex = index;
            staticUniforms = new int[staticUniformNames.Length];

            for(int i = 0;i < staticUniformNames.Length;++i)
            {
                staticUniforms[i] = GetLocation(staticUniformNames[i]);
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(shaderIndex);
        }

        public IShaderParameter CreateShaderParameter()
        {
            int[] uniformSize = new int[1];
            GL.GetProgram(shaderIndex, GetProgramParameterName.ActiveUniformMaxLength,uniformSize);
            return new ShaderParam(uniformSize[0], staticUniforms);
        }

        public int GetLocation(string uniformName)
        {
            return GL.GetUniformLocation(shaderIndex, uniformName);
        }

        public int GetAndEnableAttriLocation(string attribution)
        {
            int attr = GL.GetAttribLocation(shaderIndex,attribution);
            GL.EnableVertexAttribArray(attr);
            return attr;
        }

        public void SetStaticUniform(string uniformName, int value)
        {
            Use();
            GL.Uniform1(GetLocation(uniformName), value);
            Unuse();
        }

        public void SetStaticUniform(string uniformName,Matrix4 value)
        {
            Use();
            GL.UniformMatrix4(GetLocation(uniformName),false, ref value);
            Unuse();
        }

        public void SetAttrib(int attrLoc,IntPtr ptr,int size)
        {
            GL.VertexAttribPointer(attrLoc, size, VertexAttribPointerType.Float, false, 0, ptr);
        }

        public void Use()
        {
            GL.UseProgram(shaderIndex);
        }

        static public void Unuse()
        {
            GL.UseProgram(0);
        }

        private readonly int shaderIndex;
        private readonly int[] staticUniforms;
    }
}

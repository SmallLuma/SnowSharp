using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Shader:IShader
    {
        public Shader(int index)
        {
            shaderIndex = index;
        }

        ~Shader()
        {
            GL.DeleteProgram(shaderIndex);
        }

        public IShaderParameter CreateShaderParameter()
        {
            throw new NotImplementedException();
        }

        public int GetLocation(string uniformName)
        {
            return GL.GetUniformLocation(shaderIndex, uniformName);
        }

        private int shaderIndex;
    }
}

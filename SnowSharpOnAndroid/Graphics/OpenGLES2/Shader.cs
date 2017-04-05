using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    sealed class Shader:IShader,IDisposable
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
            GL.UseProgram(shaderIndex);
            int attr = GL.GetAttribLocation(shaderIndex,attribution);
            GL.EnableVertexAttribArray(attr);
            GL.UseProgram(0);
            return attr;
        }

        public void SetStaticUniform(string uniformName, int value)
        {
            Use();
            int loc = GetLocation(uniformName);
            if (loc >= 0)
              GL.Uniform1(loc, value);
            Unuse();
        }

        public void SetStaticUniform(string uniformName,Matrix4 value)
        {
            Use();
            GL.UniformMatrix4(GetLocation(uniformName),false, ref value);
            Unuse();
        }

        public void SetAttrib<T>(int attrLoc,T[] ptr,int size)
            where T:struct
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

        private int shaderIndex;
        private readonly int[] staticUniforms;

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                if (shaderIndex != 0)
                    Core.Schedule(() => GL.DeleteProgram(shaderIndex));
                shaderIndex = 0;

                disposedValue = true;
            }
        }

         ~Shader() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
           Dispose(false);
        }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);


        }
        #endregion
    }
}

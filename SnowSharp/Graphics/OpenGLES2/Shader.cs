using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace SnowSharp.Graphics.OpenGLES2
{
    class Shader:IShader,IDisposable
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
            GL.Uniform1(GetLocation(uniformName), value);
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                if (shaderIndex != 0)
                    Core.Schedule(() => GL.DeleteProgram(shaderIndex));
                shaderIndex = 0;

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
         ~Shader() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
           Dispose(false);
        }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);


        }
        #endregion
    }
}

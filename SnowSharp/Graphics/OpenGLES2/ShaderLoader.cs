﻿using System;
using System.Collections.Generic;
using OpenTK.Graphics.ES20;
using System.Linq;
using System.IO;

namespace SnowSharp.Graphics.OpenGLES2
{
    class ShaderLoader : Factory.IShaderLoader,IDisposable
    {
        public void FragmentShaderSource(string fragShaderCode)
            => AddShader(ShaderType.FragmentShader,fragShaderCode);
        

        public void LoadFragmentShaderSourceFile(string path)
            => FragmentShaderSource(new StreamReader(FileSystem.OpenFile(path)).ReadToEnd());

        public IShader LoadShader()
        {
            int shaderIndex = GL.CreateProgram();
            GL.AttachShader(shaderIndex, frag);
            GL.AttachShader(shaderIndex, vert);
            GL.LinkProgram(shaderIndex);

#if DEBUG
            int[] status = new int[1];
            GL.GetProgram(shaderIndex, GetProgramParameterName.LinkStatus, status);
            if (status[0] == (int)OpenTK.Graphics.ES20.Boolean.False)
            {
                throw new Exception("Shader Program Link Error:" + GL.GetProgramInfoLog(shaderIndex));
            }
#endif

            return new Shader(shaderIndex,staticUniforms.ToArray());
        }

        public void LoadVertexShaderSourceFile(string path)
            => VertexShaderSource(new StreamReader(FileSystem.OpenFile(path)).ReadToEnd());

        public void VertexShaderSource(string vertexShaderCode)
           => AddShader(ShaderType.VertexShader, vertexShaderCode);

        public void SetStaticUniform(string staticUniform)
        {
            staticUniforms.Add(staticUniform);
        }


        public void Clear()
        {
            if (vert != 0)
                Core.Schedule(() => GL.DeleteShader(vert));

            if(frag != 0)
                Core.Schedule(() => GL.DeleteShader(frag));

            vert = 0;
            frag = 0;
        }

        private void AddShader(ShaderType type,string code)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, code);
            GL.CompileShader(shader);

#if DEBUG
            int[] info = new int[1];
            GL.GetShader(shader, ShaderParameter.CompileStatus,info);
            if(info[0] == (int)OpenTK.Graphics.ES20.Boolean.False)
            {
                throw new Exception("Shader Compile Error:" + GL.GetShaderInfoLog(shader));
            }
#endif
            switch (type)
            {
                case ShaderType.VertexShader:
                    if (vert != 0) GL.DeleteShader(vert);
                    vert = shader;
                    break;
                case ShaderType.FragmentShader:
                    if (frag != 0) GL.DeleteShader(frag);
                    frag = shader;
                    break;
            }
        }
        
        private int vert, frag; //已加载的Shader组件
        private List<string> staticUniforms = new List<string>(); //已加入的Sampler名字

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
                Clear();
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
         ~ShaderLoader() {
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

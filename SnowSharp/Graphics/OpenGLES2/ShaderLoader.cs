using System;
using System.Collections.Generic;
using OpenTK.Graphics.ES20;
using System.Linq;
using System.IO;

namespace SnowSharp.Graphics.OpenGLES2
{
    class ShaderLoader : Factory.IShaderLoader,IDisposable
    {
        //TODO:加入ES2环境下的精度标志自动兼容ES2环境
        const string shaderHead = @"
#version 110

";

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
            GL.ShaderSource(shader, shaderHead + code);
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

                }

                Clear();
                disposedValue = true;
            }
        }

         ~ShaderLoader() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
           Dispose(false);
         }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}

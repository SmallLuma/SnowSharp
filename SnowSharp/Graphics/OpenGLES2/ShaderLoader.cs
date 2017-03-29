using System;
using System.Collections.Generic;
using OpenTK.Graphics.ES20;
using System.Linq;
using System.IO;

namespace SnowSharp.Graphics.OpenGLES2
{
    class ShaderLoader : Factory.IShaderLoader
    {
        public void FragmentShaderSource(string fragShaderCode)
            => addShader(ShaderType.FragmentShader,fragShaderCode);
        

        public void LoadFragmentShaderSourceFile(string path)
            => FragmentShaderSource(new StreamReader(FileSystem.OpenFile(path)).ReadToEnd());

        public IShader LoadShader()
        {
            int shaderIndex = GL.CreateProgram();
            foreach (var i in shaders)
                GL.AttachShader(shaderIndex, i);
            GL.LinkProgram(shaderIndex);

#if DEBUG
            int[] status = new int[1];
            GL.GetProgram(shaderIndex, GetProgramParameterName.LinkStatus, status);
            if (status[0] == (int)OpenTK.Graphics.ES20.Boolean.False)
            {
                throw new Exception("Shader Program Link Error:" + GL.GetProgramInfoLog(shaderIndex));
            }
#endif
            clearShaders();

            return new Shader(shaderIndex);
        }

        public void LoadVertexShaderSourceFile(string path)
            => VertexShaderSource(new StreamReader(FileSystem.OpenFile(path)).ReadToEnd());

        public void VertexShaderSource(string vertexShaderCode)
           => addShader(ShaderType.VertexShader, vertexShaderCode);

        ~ShaderLoader()
        { 
            clearShaders();
        }

        private void clearShaders()
        {
            foreach(var i in shaders)
            {
                GL.DeleteShader(i);
            }
            shaders.Clear();
        }

        private void addShader(ShaderType type,string code)
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
            shaders.Add(shader);
        }

        private List<int> shaders = new List<int>(); //已加载的Shader组件
    }
}

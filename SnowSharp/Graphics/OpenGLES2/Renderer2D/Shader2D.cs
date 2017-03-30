using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    class Shader2D
    {
        public Shader2D(Shader shd,int texCoordSize)
        {
            shader = shd;

            verticlesLoc = shader.GetAndEnableAttriLocation("SS_Vertex");
            colorsLoc = shader.GetAndEnableAttriLocation("SS_Color");

            texCoordsLoc = new int[texCoordSize];
            for (int i = 0; i < texCoordSize; ++i) {
                texCoordsLoc[i] = shader.GetAndEnableAttriLocation("SS_TexCoord" + i);
            }

            matrixOrtho = shader.GetLocation("SS_Ortho");
        }

        public void SetArrays(float[] verticles,float[] colors,float[][] texCoords)
        {
            IntPtr ptr = new IntPtr();

            Marshal.StructureToPtr(verticles, ptr,true);
            shader.SetAttrib(verticlesLoc,ptr,verticles.Length*sizeof(float));

            Marshal.StructureToPtr(colors, ptr, true);
            shader.SetAttrib(colorsLoc, ptr, colors.Length * sizeof(float));

            for(int i = 0;i < texCoords.Length; ++i)
            {
                Marshal.StructureToPtr(texCoords[i], ptr, true);
                shader.SetAttrib(texCoordsLoc[i], ptr, texCoords[i].Length * sizeof(float));
            }
        }

        public int GetOrthoUniformLoc()
        {
            return matrixOrtho;
        }

        public Shader Shader
        {
            get => shader;
        }

        int verticlesLoc;
        int colorsLoc;
        int[] texCoordsLoc;
        Shader shader;

        int matrixOrtho;
    }
}

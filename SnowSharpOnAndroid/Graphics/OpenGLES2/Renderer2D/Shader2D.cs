using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SnowSharp.Graphics.OpenGLES2.Renderer2D
{
    sealed class Shader2D
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

        public void SetArrays(Vector2[] verticles,OpenTK.Graphics.Color4[] colors,IList<Vector2[]> texCoords)
        {
            if(verticlesLoc >= 0)
                shader.SetAttrib(verticlesLoc,verticles,2);

            if (colorsLoc >= 0)
                shader.SetAttrib(colorsLoc, colors, 4);

            for(int i = 0;i < texCoords.Count; ++i)
            {
                if(texCoordsLoc[i] >= 0)
                    shader.SetAttrib(texCoordsLoc[i], texCoords[i],2);
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

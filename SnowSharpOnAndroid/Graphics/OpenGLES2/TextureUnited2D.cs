using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenTK;

namespace SnowSharp.Graphics.OpenGLES2
{
    class TextureUnited2D : Texture2D, ITextureUnited2D
    {
        public override TextureWarpMode WarpMode { set => throw new NotImplementedException(); }

        public override void LoadFromFile(string file)
        {
            var bin = new BinaryReader(FileSystem.OpenFile(file));

            var sst = new SSTReader(bin);
            LoadFromSST(sst);

            units = sst.Rects;
        }

        public Box2 GetUnit(int unitNum)
        {
            return units[unitNum];
        }

        private IList<Box2> units;
    }
}

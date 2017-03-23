using OpenTK;
using System;
using System.Collections.Generic;

namespace SnowSharp.Graphics.Renderer
{

    /// <summary>
    /// 着色器参数
    /// </summary>
    public class ShaderParam
    {

        /// <summary>
        /// double参数
        /// </summary>
        public Dictionary<int, double> Doubles { get => doubles; }


        /// <summary>
        /// Vector2d参数
        /// </summary>
        public Dictionary<int, Vector2d> Vector2ds { get => vector2ds; }


        /// <summary>
        /// Vector4d参数
        /// </summary>
        public Dictionary<int, Vector4d> Vector4ds { get => vector4ds; }

        #region private

        Dictionary<int, double> doubles = new Dictionary<int, double>();
        Dictionary<int, Vector2d> vector2ds = new Dictionary<int, Vector2d>();
        Dictionary<int, Vector4d> vector4ds = new Dictionary<int, Vector4d>();

        #endregion
    }
}

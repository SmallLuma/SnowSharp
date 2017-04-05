using System;
using OpenTK;

namespace SnowSharp.Math
{
    /// <summary>
    /// 存放各种数据类型的插值器
    /// </summary>
    public static class Mixers
    {

        /// <summary>
        /// 插值器
        /// </summary>
        /// <typeparam name="T">被插值类型</typeparam>
        /// <param name="begin">起始值</param>
        /// <param name="end">终结值</param>
        /// <param name="per">插值比例</param>
        /// <returns>插值</returns>
        public delegate T Mixer<T>(T begin, T end, float per);

        /// <summary>
        /// double类型的插值器
        /// </summary>
        public static readonly Mixer<float> FloatMixer = (begin, end, per) => (end - begin) * per + begin;


        /// <summary>
        /// Vector2d型操作数
        /// </summary>
        public static readonly Mixer<Vector2> Vector2Mixer = (begin, end, per) => (end - begin) * per + begin;

        public static readonly Mixer<Box2> Box2Mixer = (begin, end, per) =>
           {
               Box2 ret;
               ret.Left = FloatMixer(begin.Left, end.Left, per);
               ret.Right = FloatMixer(begin.Right, end.Right, per);
               ret.Top = FloatMixer(begin.Top, end.Top, per);
               ret.Bottom = FloatMixer(begin.Bottom, end.Bottom, per);
               return ret;
           };
    }


    /// <summary>
    /// 存放各种类型的曲线函数
    /// </summary>
    public static class Funcs
    {

        /// <summary>
        /// 变化曲线
        /// </summary>
        /// <param name="x">自变量</param>
        /// <returns>因变量</returns>
        public delegate float FuncLine(float x);

        /// <summary>
        /// 正比例曲线
        /// </summary>
        public static readonly FuncLine Line = x => x;


        /// <summary>
        /// 二次曲线
        /// </summary>
        public static readonly FuncLine Twice = p => -p * p + 2 * p;


        /// <summary>
        /// 球面曲线
        /// </summary>
        public static readonly FuncLine Circle = x => (float)System.Math.Sqrt(1 - (x - 1) * (x - 1));


        /// <summary>
        /// 正弦曲线
        /// </summary>
        public static readonly FuncLine Sin = x => (float)System.Math.Sin(System.Math.PI / 2 * x);
    }
}

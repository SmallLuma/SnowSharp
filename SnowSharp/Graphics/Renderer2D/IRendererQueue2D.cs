using OpenTK;

namespace SnowSharp.Graphics.Renderer2D
{

    /// <summary>
    /// 2D渲染队列
    /// </summary>
    public interface IRendererQueue2D
    {

        /// <summary>
        /// 添加DrawCall
        /// </summary>
        /// <param name="drawCall"></param>
        void PushDrawCall(IDrawCall2D drawCall);

        
        /// <summary>
        /// 设置坐标系
        /// xy意义分别为宽、高
        /// </summary>
        Vector2 Ortho
        {
            set;
        }

        /// <summary>
        /// 绘制目标
        /// </summary>
        IFrameBuffer Target
        {
            set;
        }


        /// <summary>
        /// 立即渲染
        /// </summary>
        void Flush();
    }
}

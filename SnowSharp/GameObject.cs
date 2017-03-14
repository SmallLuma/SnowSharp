using System;
using SnowSharp.GameObjects;
namespace SnowSharp
{

    /// <summary>
    /// 游戏物体
    /// </summary>
    public class GameObject
    {

        /// <summary>
        /// 要求绘制的时候执行
        /// </summary>
        public virtual void OnDraw()
        {

        }

        /// <summary>
        /// 每帧执行一次
        /// </summary>
        public virtual void OnUpdate()
        {

        }


        /// <summary>
        /// 逻辑是否已经死亡
        /// </summary>
        public virtual bool Died
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// 用于访问父结点
        /// </summary>
        public GameObjectList Parent
        {
            internal set
            {
                parent.Target = value;
            }
            get
            {
                return (GameObjectList)parent.Target;
            }
        }


        /// <summary>
        /// 从父节点上卸载自身
        /// </summary>
        public void RemoveSelfFromParent()
        {
            if (parent.IsAlive)
            {
                var glst = (GameObjectList)parent.Target;
                glst.Remove(this);
            }
        }

        WeakReference parent = new WeakReference(null);
    }
}

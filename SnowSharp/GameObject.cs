﻿using SnowSharp.GameObjects;
using System;
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
            get => true;
        }


        /// <summary>
        /// 用于访问父结点
        /// </summary>
        public IGameObjectParent Parent
        {
            internal set => parent.Target = value;
            get => (IGameObjectParent)parent.Target;
        }

        #region private

        WeakReference parent = new WeakReference(null);

        #endregion
    }
}

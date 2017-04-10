﻿using System;
using System.Collections.Generic;

namespace SnowSharp.GameObjects
{

    /// <summary>
    /// 游戏物体表
    /// 用于存储一组游戏物体
    /// </summary>
    public class GameObjectList:GameObject,IGameObjectParent
    {

        /// <summary>
        /// 添加一个物体到物体列表
        /// </summary>
        /// <param name="gameObject">物体</param>
        public virtual void Add(GameObject gameObject)
        {
            gameObjectList.Add(gameObject);

#if DEBUG
            if (gameObject.Parent != null) throw new Exception("此游戏物体已经在其他物体列表中存在。");
#endif
            gameObject.Parent = this;
        }


        /// <summary>
        /// 从游戏物体列表中删除已有物体
        /// </summary>
        /// <param name="gameObject"></param>
        public virtual void Remove(GameObject gameObject)
        {
            if (gameObject == this)
            {
                gameObjectList.Remove(gameObject);
                gameObject.Parent = null;
            }
        }


        /// <summary>
        /// 从游戏物体列删除谓词定义成立的物体
        /// </summary>
        public virtual void Remove(Predicate<GameObject> func)
        {
            var del = gameObjectList.FindAll(func);
            foreach (var i in del)
                Remove(i);
        } 



        /// <summary>
        /// 该物体列表是否永生
        /// 如果不永生则在列表内物体全部死亡后死亡
        /// 默认不永生
        /// </summary>
        public bool AlwaysAlive
        {
            get => alwaysAlive;
            set => alwaysAlive = value;
        }


        #region override

        public override bool Died
        {
            get
            {
                 return alwaysAlive ? false : gameObjectList.Count <= 0;
            }
        }

        public override void OnDraw()
        {
            foreach (var i in gameObjectList)
                i.OnDraw();
        }

        public override void OnUpdate()
        {
            foreach (var i in gameObjectList)
                i.OnUpdate();
            gameObjectList.RemoveAll(x => x.Died);
        }

        public virtual T Get<T>()
    where T : GameObject
        {
            foreach (var i in gameObjectList)
            {
                if (i is T)
                    return (T)i;
            }

            throw new Exception("未能找到指定类型的物体。");
        }

        public virtual GameObject Get(Predicate<GameObject> func)
        {
            return gameObjectList.Find(func);
        }

        public virtual IList<GameObject> GetAll(Predicate<GameObject> func)
        {
            return gameObjectList.FindAll(func);
        }

        public virtual IEnumerator<GameObject> GetEnumerator()
        {
            return gameObjectList.GetEnumerator();
        }
        #endregion

        #region private

        protected List<GameObject> gameObjectList = new List<GameObject>();
        bool alwaysAlive = false;

        #endregion
    }
}

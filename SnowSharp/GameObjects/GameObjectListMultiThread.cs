using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnowSharp.GameObjects
{
    //TODO:某些操作可能不安全，应该把GameObjectList的继承取消，然后改为Bag.
    /// <summary>
    /// 多线程的GameObject
    /// 注意:不要用来挂载需要同级/父级访问均为非线程安全
    /// </summary>
    public class GameObjectListMultiThread : GameObject, IGameObjectParent
    {

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="gameObject"></param>
        public void Add(GameObject gameObject)
        {
            cb.Add(gameObject);
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
        public T Get<T>() where T : GameObject
        {
            foreach(var i in cb)
            {
                if (i is T) return (T)i;
            }

            throw new Exception("未找到类型为 " + typeof(T).FullName + "的对象。");
        }

        public override bool Died
        {
            get
            {
                return alwaysAlive ? false : cb.IsEmpty;
            }
        }

        public GameObject Get(Predicate<GameObject> func)
        {
            foreach(var i in cb)
            {
                if (func(i)) return i;
            }

            throw new Exception("未找到满足条件的对象。");
        }

        public IList<GameObject> GetAll(Predicate<GameObject> func)
        {
            return cb.ToList();
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return cb.GetEnumerator();
        }

        public override void OnDraw()
        {
            foreach (var i in cb)
                i.OnDraw();
        }

        public override void OnUpdate()
        {
            System.Threading.Tasks.Parallel.ForEach(cb, x => x.OnUpdate());
            cb.TakeWhile((obj, b) => obj.Died);
            //TODO:删除Died成立的物体
        }

        #endregion

        #region private

        private ConcurrentBag<GameObject> cb = new ConcurrentBag<GameObject>();

        bool alwaysAlive = false;

        #endregion
    }
}

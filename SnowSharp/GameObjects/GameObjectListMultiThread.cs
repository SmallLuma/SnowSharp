using System;
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
    public class GameObjectListMultiThread:GameObjectList,IGameObjectParent
    {
#region override
        public override void OnUpdate()
        {
            lock (gameObjectList)
            {
                gameObjectList.RemoveAll(x => x.Died);
                System.Threading.Tasks.Parallel.ForEach(gameObjectList, UpdateObject);
            }
        }

        public override void OnDraw()
        {
            lock (gameObjectList)
            {
                foreach (var i in gameObjectList)
                {
                   i.OnDraw();
                }
            }
        }

        public override void Add(GameObject gameObject)
        {
            lock (gameObjectList)
            {
                base.Add(gameObject);
            }
        }

        public override T Get<T>()
        {
            lock (gameObjectList)
            {
                return base.Get<T>();
            }
        }

        public override GameObject Get(Predicate<GameObject> func)
        {
            lock (gameObjectList)
            {
                return gameObjectList.Find(func);
            }
        }

        public override IList<GameObject> GetAll(Predicate<GameObject> func)
        {
            lock (gameObjectList)
            {
                return gameObjectList.FindAll(func);
            }
        }

        public override void Remove(GameObject gameObject)
        {
            lock (gameObject)
            {
                base.Remove(gameObject);
            }
        }

        public override void Remove(Predicate<GameObject> func)
        {
            lock (gameObjectList)
            {
                Remove(func);
            }
        }


        public override IEnumerator<GameObject> GetEnumerator()
        {
            lock (gameObjectList)
            {
                return gameObjectList.GetEnumerator();
            }
        }

        public override bool Died
        {
            get
            {
                if (AlwaysAlive) return false;
                else
                {
                    lock (gameObjectList)
                    {
                        return gameObjectList.Count <= 0;
                    }
                }
            }
        }

        private static void UpdateObject(GameObject g)
        {
            lock (g)
            {
                g.OnUpdate();
            }
        }
#endregion
    }
}

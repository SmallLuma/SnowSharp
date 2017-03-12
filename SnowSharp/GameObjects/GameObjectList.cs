using System.Collections.Generic;

namespace SnowSharp.GameObjects
{

    /// <summary>
    /// 游戏物体表
    /// 用于存储一组游戏物体
    /// </summary>
    public class GameObjectList:List<IGameObject>,IGameObject
    {
        public bool Died
        {
            get
            {
                return Count <= 0;
            }
        }

        public virtual void OnDraw()
        {
            foreach(var i in this)
                i.OnDraw();
        }

        public virtual void OnUpdate()
        {
            foreach (var i in this)
                i.OnUpdate();
            RemoveAll(x => x.Died);
        }
    }
}

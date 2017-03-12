using System.Collections.Generic;

namespace SnowSharp
{

    /// <summary>
    /// 逻辑表
    /// 用于存放和自动更新逻辑
    /// 其本身也作为逻辑存放
    /// </summary>
    public class LogicList:List<ILogic>,ILogic
    {
        public void OnUpdate()
        {
            foreach(var logic in this)
            {
                logic.OnUpdate();
            }

            RemoveAll(logic => logic.Died);
        }

        public bool Died
        {
            get
            {
                return Count <= 0;
            }
        }
    }
}

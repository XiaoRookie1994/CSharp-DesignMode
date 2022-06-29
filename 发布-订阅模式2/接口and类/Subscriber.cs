using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 发布_订阅模式.接口and类
{
    public class Subscriber   /////设计订阅者S。S类中使用了ISubscribe来与S.P进行解耦
    {
        private string _subscriberName;

        public Subscriber(string subscriberName)
        {
            this._subscriberName = subscriberName;
        }

        public ISubscribe AddSubscribe { set { value.SubscribeEvent += Show; } }
        public ISubscribe RemoveSubscribe { set { value.SubscribeEvent -= Show; } }

        private void Show(string str)
        {
            Console.WriteLine(string.Format("我是{0}，我收到订阅的消息是:{1}", _subscriberName, str));
        }
    }
}

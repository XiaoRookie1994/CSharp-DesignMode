using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 发布_订阅模式.接口and类
{
    public class Publisher : IPublish    /////发布者P，继承IPublish来对S.P发布消息通知
    {
        private string _publisherName;

        public Publisher(string publisherName)
        {
            this._publisherName = publisherName;
        }

        private event PublishHandle PublishEvent;
        event PublishHandle IPublish.PublishEvent
        {
            add { PublishEvent += value; }
            remove { PublishEvent -= value; }
        }

        public void Notify(string str)
        {
            if (PublishEvent != null)
                //Console.WriteLine("我是{0},我发布{1}消息", _publisherName, str);
                PublishEvent.Invoke(string.Format("我是{0},我发布{1}消息", _publisherName, str));
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 发布_订阅模式.接口and类
{
    public class SubPubComponet : ISubscribe, IPublish   ////定义订阅器 订阅器要实现双向解耦，就一定要继承上面两个接口
    {
        private string _subName;              ////定义订阅器 名称
        public SubPubComponet(string subName)   ////构造器
        {
            this._subName = subName;
            PublishEvent += new PublishHandle(Notify);        /////添加发布事件
        }

        #region ISubscribe Members          ///定义订阅接口成员

        event SubscribeHandle subscribeEvent;
        event SubscribeHandle ISubscribe.SubscribeEvent
        {
            add { subscribeEvent += value; }           ///注册
            remove { subscribeEvent -= value; }       ///退订
        }
        #endregion

        #region IPublish Members          ///定义发布接口成员
        public PublishHandle PublishEvent;
        event PublishHandle IPublish.PublishEvent
        {
            add { PublishEvent += value; }               ///注册
            remove { PublishEvent -= value; }            ///退订
        }
        #endregion

        public void Notify(string str)
        {
            if (subscribeEvent != null)
                subscribeEvent.Invoke(string.Format("消息来源{0}:消息内容:{1}", _subName, str));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 发布_订阅模式.接口and类
{
    //定义订阅事件
    public delegate void SubscribeHandle(string str);
    //定义订阅接口
    public interface ISubscribe
    {
        event SubscribeHandle SubscribeEvent;
    }
    //定义发布事件
    public delegate void PublishHandle(string str);
    //定义发布接口
    public interface IPublish
    {
        event PublishHandle PublishEvent;           ////定义 发布事件
        void Notify(string str);                    ////定义 内容
    }

}

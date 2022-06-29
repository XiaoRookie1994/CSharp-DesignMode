using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 发布_订阅模式.接口and类;

namespace 发布_订阅模式
{
    /////来源：http://blog.csdn.net/tjvictor/article/details/5223309
    /////为了实现P与S.P, S与S.P之间的解耦，我们需要定义两个接口文件
    /////P:Publish 发布者   S:Subscri 订阅者  S.P：SubPubComponet 订阅器 
    class Program
    {
        static void Main(string[] args)
        {
            #region TJVictor.DesignPattern.SubscribePublish
            //新建两个订阅器
            SubPubComponet subPubComponet1 = new SubPubComponet("订阅器1");
            SubPubComponet subPubComponet2 = new SubPubComponet("订阅器2");
            SubPubComponet subPubComponet3 = new SubPubComponet("订阅器3");
            //新建两个发布者
            IPublish publisher1 = new Publisher("TJVictor1");
            IPublish publisher2 = new Publisher("TJVictor2");
            //与订阅器关联
            publisher1.PublishEvent += subPubComponet1.PublishEvent;
            publisher1.PublishEvent += subPubComponet2.PublishEvent;
            publisher2.PublishEvent += subPubComponet2.PublishEvent;
            publisher2.PublishEvent += subPubComponet3.PublishEvent;
            //新建两个订阅者
            Subscriber s1 = new Subscriber("订阅人1");
            Subscriber s2 = new Subscriber("订阅人2");
            //进行订阅
            s1.AddSubscribe = subPubComponet1;
            s1.AddSubscribe = subPubComponet2;
            s2.AddSubscribe = subPubComponet2;
            s2.AddSubscribe = subPubComponet3;
            //发布者发布消息
            publisher1.Notify("博客1");
            //publisher2.Notify("博客2");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));
            //s1取消对订阅器2的订阅
            s1.RemoveSubscribe = subPubComponet2;
            //发布者发布新消息
            publisher1.Notify("博客3");
            publisher2.Notify("博客4");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));
            #endregion

            #region Console.ReadLine();
            Console.ReadLine();
            #endregion
        }
    }
}

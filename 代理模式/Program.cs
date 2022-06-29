using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.BuyProduct();
            Console.Read();
        }
    }
    // 抽象主题角色
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    /// <summary>
    /// 客户
    /// </summary>
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个IPhone和一台苹果电脑");
        }
    }

    /// <summary>
    /// 代理人
    /// </summary>
    public class Friend : Person
    {
        // 引用真实主题实例  
        RealBuyPerson realSubject;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问客户");
            if (realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }
            /// 整理代购清单
            this.PreBuyProduct();
            /// 调用客户需求 进行代购     
            realSubject.BuyProduct();
            /// 代购后分类
            this.PostBuyProduct();
        }

        // 代理角色执行的一些操作
        public void PreBuyProduct()
        {
            // 可能不知一个朋友叫这位朋友带东西，首先这位出国的朋友要对每一位朋友要带的东西列一个清单等
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }
        // 买完东西之后，代理角色需要针对每位朋友需要的对买来的东西进行分类
        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}

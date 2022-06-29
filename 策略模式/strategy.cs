using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    class strategy
    {
        price s { get; set; }
        public strategy(price type)
        {
            s = type;
        }
      
        public double getResult(double num)
        {
            return s.shouqian(num);
        }
    }
    public abstract class price
    {
        public double _price;
        public abstract double shouqian(double money);
    }
    public class zhengchang : price
    {
        public override double shouqian(double money)
        {
            return money;
        }
    }
    public class zhekou : price
    {
        public double reat { get; set; }
        public zhekou(double _reat)
        {
            reat = _reat;
        }
        public override double shouqian(double money)
        {
            return money * reat;
        }
    }
}

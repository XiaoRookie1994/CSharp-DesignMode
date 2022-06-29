using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 抽象工厂
{
    class HWMCar : Car
    {
      
        public override string Price()
        {
            throw new NotImplementedException();
        }   
    }
    class BYDCar : Car
    {
        public override string Price()
        {
            throw new NotImplementedException();
        }
    }
    class HWM100 : HWMCar
    {
        public override string Price()
        {
            return ("型号：" + Name + "  制造；" + ManuFacturer + "  售价：150W");
        }
    }
    class HWM150 : HWMCar
    {
        public HWM150()
        {
            this.Name = "HWM150";
        }
        public override string Price()
        {
           return("型号：" +Name +"  制造；"+ManuFacturer+"  售价：150W");
        }
    }
    class BYD020 : BYDCar
    {
        public BYD020()
        {
            this.Name = "BYD020";
        }
        public override string Price()
        {
            return ("型号：" + Name + "  制造；" + ManuFacturer + "  售价：150W");
        }
    }

}

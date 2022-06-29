using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
namespace 抽象工厂
{
     abstract  class AbstractFactory
    {
         static string assemblyName = "抽象工厂";
         static string MType = ConfigurationManager.AppSettings["Factory"];
        /// <summary>
        /// 制造实体汽车
        /// </summary>
        /// <returns>实体汽车</returns>
        abstract public Car CreateCar();

    }
}

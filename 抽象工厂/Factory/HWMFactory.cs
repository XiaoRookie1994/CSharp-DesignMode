using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂
{
    /// <summary>
    /// 创建实体工厂
    /// </summary>
    class  MyFactory
    {
        private static string assemblyName = "抽象工厂";
        private static string MType = ConfigurationManager.AppSettings["Factory"];
        /// <summary>
        /// 制造实体工厂
        /// </summary>
        /// <returns>实体工厂</returns>
        public static AbstractFactory CreateFactory()
        {
            string className = assemblyName + "." + MType;
            AbstractFactory iFactory = (AbstractFactory)Assembly.Load(assemblyName).CreateInstance(className);
            return iFactory;
        }
    }
    /// <summary>
    /// 实体工厂HWMFactory ---->创建实体产品
    /// </summary>
    class HWMFactory :AbstractFactory
    {
        private static string assemblyName = "抽象工厂";
        private static string MType = ConfigurationManager.AppSettings["Type"];
        /// <summary>
        /// 制造汽车
        /// </summary>
        /// <returns>实体汽车</returns>
        public override Car CreateCar()
        {
            string className = assemblyName + "." + MType;
            Car icar = (Car)Assembly.Load(assemblyName).CreateInstance(className);
            icar.ManuFacturer = "HWMFactory";
            return icar;
        }

    }
    /// <summary>
    /// 实体工厂BYDFactory  ---->创建实体产品
    /// </summary>
    class BYDFactory : AbstractFactory
    {
        private static string assemblyName = "抽象工厂";
        private static string MType = ConfigurationManager.AppSettings["Type"];
        /// <summary>
        /// 制造汽车
        /// </summary>
        /// <returns>实体汽车</returns>
        public override Car CreateCar()
        {

            string className = assemblyName + "." + MType;
            Car icar = (Car)Assembly.Load(assemblyName).CreateInstance(className);
            icar.ManuFacturer = "BYDFactory";
            return icar;
        }

    }
}

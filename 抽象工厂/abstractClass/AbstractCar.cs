using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂
{
    abstract class Car
    {
        /// <summary>
        /// 价格
        /// </summary>
        abstract public string Price();
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        public string ManuFacturer { get; set; }
    }
}

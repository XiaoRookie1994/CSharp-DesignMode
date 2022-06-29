using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 孙悟空 原型
            MonkeyKingPrototype prototypeMonkeyKing = new ConcretePrototype("MonkeyKing");

            // 变一个
            MonkeyKingPrototype cloneMonkeyKing = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);

            // 变两个
            MonkeyKingPrototype cloneMonkeyKing2 = prototypeMonkeyKing.Clone() as ConcretePrototype;
            cloneMonkeyKing2.weapon.name = "ss";
            Console.WriteLine("Cloned1:\t" + prototypeMonkeyKing.weapon.name);
            cloneMonkeyKing.weapon.name = "sss";
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.weapon.name);
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.weapon.name);
            Console.ReadLine();
        }
    }

    [Serializable]
    public class weapon
    {
        public string name { get; set; }
    }
    [Serializable]
    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }
        public weapon weapon = new weapon();
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
            weapon.name = Id;
        }

        // 克隆方法，即孙大圣说“变”
        public abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
     [Serializable]
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        /// 
        public override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            //return (MonkeyKingPrototype)this.MemberwiseClone();
            //MonkeyKingPrototype re = new ConcretePrototype(this.Id);
            //re.weapon = new weapon();
            //re.weapon.name = this.weapon.name;

            BinaryFormatter bf = new BinaryFormatter();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bf.Serialize(ms, this); //复制到流中
            ms.Position = 0;
            return (MonkeyKingPrototype)(bf.Deserialize(ms));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 外观模式
{
    class Program
    {

  // 客户端只依赖与外观类，从而将客户端与子系统的依赖解耦了，
  // 如果子系统发生改变，此时客户端的代码(Main)并不需要去改变。
  // 外观模式的实现核心主要是——由外观类去保存各个子系统的引用，
  // 实现由一个统一的外观类去包装多个子系统类，然而客户端只需要引用这个外观类，
  // 然后由外观类来调用各个子系统中的方法。然而这样的实现方式非常类似适配器模式，
  // 然而外观模式与适配器模式不同的是：适配器模式是将一个对象包装起来以改变其接口，
  // 而外观是将一群对象 ”包装“起来以简化其接口。它们的意图是不一样的，
  // 适配器是将接口转换为不同接口，而外观模式是提供一个统一的接口来简化接口
        private static RegistrationFacade facade = new RegistrationFacade();
        static void Main(string[] args)
        {
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }
    // 外观类
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;
        /// <summary>
        /// 注册外观
        /// </summary>
        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }
        /// <summary>
        /// 注册课程
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统

    /// <summary>
    /// 课程注册类
    /// </summary>
    public class RegisterCourse
    {
        /// <summary>
        /// 检查可用
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    /// <summary>
    /// 通知学生
    /// </summary>
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
}

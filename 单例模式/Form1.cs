using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace 单例模式
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton.Instance.ToString();
        }
    }
    public class Singleton

    {
        private Singleton()
        {
        }
        private static Singleton _Instance = null;
        private static readonly object lockObj = new object();
        public static Singleton Instance
        {
            get
            {
                //双重锁定，防止多线程时重复实例化
                if (_Instance == null)
                {
                    lock (lockObj)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new Singleton();
                            Debug.Write("Instance = new Singleton");
                        }
                    }
                }
                return _Instance;
            }
        }
    }
}

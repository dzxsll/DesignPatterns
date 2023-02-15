using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Singleton
    {
        //目的：确保程序中只使用一个该实例。
        //比如数据库连接管理类，一个类里面包含着一个连接池，管理程序的所有数据库连接。

        //私有化构造函数,不管什么情况下，都要私有化。
        private Singleton() { }

        #region 单线程

        //静态变量保存类的实例
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        #endregion

        #region 多线程

        //volatile修饰符保证了该变量每次都会被重新读取，而不是从寄存器中取出备份作为该变量的值。
        private static volatile Singleton instanceInMuiltThread;

        //线程锁
        private static readonly object locker = new object();

        //多线程下的单例
        public static Singleton GetInstanceInMuiltThread()
        {
            //逻辑上的第一个运行到此的线程会加锁
            //第二个运行到此处的线程，因为检测到锁而挂起，等待点一个线程解锁
            //lock内语句运行完后，会进行解锁。
            //保证只有一个线程在运行。
            lock (locker)
            {
                if (instanceInMuiltThread == null)
                {
                    instanceInMuiltThread = new Singleton();
                }
            }

            return instance;
        }

        #endregion

        #region C#特性下的单例

        //使用C#的特性来实现单例模式
        //核心是使用静态构造器
        public static readonly Singleton instanceInCSharp = new Singleton();

        //上面的句等同于以下语句

        public static readonly Singleton instance_InCSharp;

        //这是静态构造器，静态构造器只会被调用一次。
        //https://www.cnblogs.com/MrZivChu/p/BaseKnowledge_staticConstructor.html
        static Singleton()
        {
            instance_InCSharp = new Singleton();
        }

        #endregion
    }
}

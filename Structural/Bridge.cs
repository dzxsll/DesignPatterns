using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //桥接模式：为了应对多维度的属性组合，而产生的抽象和实现的模式。
    //比如：圆球和正方体，红色和蓝色，两两组合就会有四种类型，如果在代码中，如果一种属性的种类越多，那么类就越庞大。

    class Bridge
    {
        public Bridge()
        {
            //声明具体的实现,放入到实现的基类中
            PlatformImplementor platform = new SqlServer2005UnixImplementor();

            //以基类的形式进行依赖注入
            DataBase SqlServer2005= new DataBase(platform);

            //再用接口调用具体的实现
            SqlServer2005.Create();
        }
    }

    //首先对抽象和实现做解释：
    //抽象是指高层，高级的一些操作。
    //实现是指底层，更加靠近实际的一些操作。

    //抽象负责规定要做什么,即目标
    //实现负责具体要做什么,即行为
    //同时,这里的"实现"是抽象的,它有自己的实现

    //如何使用？在抽象中组合"实现"的接口

    //教材中的数据和平台的桥接:

    //抽象
    public class DataBase
    {
        //通过组合方式引用平台接口，此处就是桥梁，该类型相当于Implementor类型
        protected PlatformImplementor _implementor;

        //通过构造器依赖注入，初始化平台实现
        public DataBase(PlatformImplementor implementor)
        {
            _implementor = implementor;
        }

        //创建数据库--该操作相当于Abstraction类型的Operation方法,即目标，要做什么。
        public virtual void Create()
        {
            _implementor.Process();
        }
    }

    //"实现"
    public abstract class PlatformImplementor
    {
        //该方法就相当于Implementor类型的OperationImpl方法
        //这个方法可能会有不同的实现。
        public abstract void Process();
    }

    //"实现"的具体实现
    public sealed class SqlServer2005UnixImplementor : PlatformImplementor
    {
        public override void Process()
        {
            Console.WriteLine("SqlServer2005针对Unix的具体实现");
        }
    }

    public sealed class SqlServer2000UnixImplementor : PlatformImplementor
    {
        public override void Process()
        {
            Console.WriteLine("SqlServer2000针对Unix的具体实现");
        }
    }
}

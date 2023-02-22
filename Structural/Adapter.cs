using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //适配器,顾名思义就是让两个不相配的东西,能够连接在一起工作
    //那么转换就是核心的思想
    //专业说法：将一个类的接口转换成客户希望的另一个接口。Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。
    class Adapter
    {
    }

    //角色：
    //既然是适配,那肯定要有适配和被适配的对象
    //同时适配的目的是为了给调用的人服务的
    //所以有以下三个角色：
    //目标者(Target)：需要适配的角色
    //适配器(adapte)：对Adaptee的接口与Target接口进行适配.
    //          注意：这里适配的是接口.话句话说，适配就是，在A的接口实现里，使用B的接口实现。这就实现了一个接口的转换，是实现的核心思路。
    //被适配者(Adaptee)：定义一个已经存在并已经使用的接口，这个接口需要适配。

    //实现方式：
    //1.组合方式：最常用的方式。

    //目标者(Target)：需要适配的角色
    public class TwoHoleTarget
    {
        public virtual void Request()
        {
            Console.WriteLine("两孔的充电器可以用");
        }
    }

    //适配器(adapte)
    //核心：在A的接口实现里，使用B的接口实现
    //获得A的接口有两种方式，一种是继承(class)，那么方法要是能够被复写的虚方法。一种是实现(interface)
    //使用B的接口是采用组合的方式
    public class TwoToThreeAdapte : TwoHoleTarget
    {
        //这里可以直接声明被适配者

        public ThreeHoleAdaptee adaptee = new ThreeHoleAdaptee();

        //也可以采用依赖注入的方式
        public TwoToThreeAdapte(ThreeHoleAdaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public override void Request()
        {
            //数据的适配，或者其他的适配
            adaptee.SpecificRequest();
        }
    }

    //被适配者(Adaptee)
    public class ThreeHoleAdaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是3个孔的插头也可以使用了");
        }
    }

    //2.继承方式：一般出现在编程语言中。
    //一个继承，一个实现，调用的思路还是一致的。仿照上面修改就可以了

    //总结：适配器方式充分体现了"面向接口编程"的指导原则，再重复一次：在A的接口实现里，使用B的接口实现，用A的名字做B或者更多的事情。
}

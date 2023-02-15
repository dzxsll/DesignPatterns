using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    //原型模式，应对实例化相同类型的对象需求。
    //比如导航树的修改,需要在备份上进行修改,保留原来的导航树,防止修改错误后,需要耗时再重生成一次导航树.
    class Prototype
    {

    }
    
    //原型类（Prototype）：原型类，声明一个Clone自身的接口；   
    public abstract class MyPrototype
    {
        public abstract MyPrototype Clone();
    }

    //具体原型类（ConcretePrototype）：实现一个Clone自身的操作。
    public class MyConcretePrototype : MyPrototype
    {
        public override MyPrototype Clone()
        {
            return (MyConcretePrototype)this.MemberwiseClone();
        }
    }

    //一般是和工厂方法模式一起出现，通过clone的方法创建一个对象，然后由工厂方法提供给调用者。

    //.NET中已经实现了该模式的抽象接口,即ICloneable接口。同时也有很多的类实现该接口,可以直接使用Clone()方法。
}

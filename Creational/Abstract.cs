using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    class Abstract
    {
        //抽象工厂与工厂模式是一致的。
        //区别在于，抽象的产品更多，具体的产品也更多
        //具体工厂在实现的时候，不仅仅生产一种产品，而是多个产品。
    }

    /// <summary>
    /// 抽象工厂类，提供创建不同类型房子的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了房顶、地板、窗户和房门创建接口
        public abstract Roof CreateRoof();
        public abstract Floor CreateFloor();
        public abstract Window CreateWindow();
        public abstract Door CreateDoor();
    }

    //要现实具体的工厂

    //要实现具体的产品
}

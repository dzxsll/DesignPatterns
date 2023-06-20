using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //装饰器模式:简单的说就是"套娃",通过一层一层往里套,来增加额外的行为。
    //解决的问题：主体类的在多方向上的功能扩展问题,即多种类型的功能组合所产生出的大量子类。
    //比如通知功能，短信，推特，脸书，不同的类型所调用的API不一样，如果组合排列,C31,C32,C33,就总共产生7种子类，这显然不合适。    

    class Decorator
    {
        public Decorator()
        {
            House myhouse = new MyLittleHouse();

            House securityHouse = new HouseSecurityDecorator(myhouse);

            securityHouse.Renovation();

            House securityAndFloowHeatHouse = new HouseFloowHeatDecorator(securityHouse);

            securityAndFloowHeatHouse.Renovation();
        }
    }

    //该模式是通过套娃的方式,解决这个组合问题,关键是怎么套娃?
    //套娃方法：通过继承和组合的方式来进行。
    //解释：装饰器通过继承要套娃的源，来保证具有相同的接口。同时通过组合的方式，保留被装饰者所具有的功能。
    //组合是保证,多次套娃,保留了每一次套娃所具有的功能。
    //继承是要保证了每次装饰后，接口的一致。显然，套娃一次后，接口改变了，这是不合理的，好比房子装了窗户，房子却没有开门的功能了。


    //面对抽象编程,具体的实现要下放倒子类之中

    //抽象数据源类
    public abstract class House
    {
        public abstract void Renovation();
    }

    //抽象装饰类
    public abstract class DecorationStrategy : House //这里的继承是关键，保证接口的一致
    {
        //这里的组合也是关键,保证被包装的类,原来的功能还可以被使用。
        protected House _house;

        //依赖注入
        protected DecorationStrategy(House house)
        {
            _house = house;
        }

        //这个复写接口的方法就是保留原有功能的方式
        //在继承的子类中,继续复写这个方法,来添加新的功能。
        public override void Renovation()
        {
            if (_house != null)
            {
                _house.Renovation();
            }
        }
    }

    //具体的数据源类
    public sealed class MyLittleHouse : House
    {
        public override void Renovation()
        {
            Console.WriteLine("装修MyLittleHouse的房子");
        }
    }

    //具体装饰类
    public sealed class HouseSecurityDecorator : DecorationStrategy
    {
        public HouseSecurityDecorator(House house) : base(house) { }

        public override void Renovation()
        {
            base.Renovation();
            Console.WriteLine("增加安全系统");
        }
    }

    public sealed class HouseFloowHeatDecorator : DecorationStrategy
    {
        public HouseFloowHeatDecorator(House house) : base(house)
        {
        }
        public override void Renovation()
        {
            base.Renovation();
            Console.WriteLine("增加地热系统");
        }

    }
}

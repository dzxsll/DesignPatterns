using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    //因对组装的各个部分变化复杂，创建流程是相对稳定的状况
    //意图(更专业)：将一个复杂对象的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
    class Builder
    {
        public Builder()
        {
            WuLingBuilder wuLingBuilder = new WuLingBuilder();
            Director director = new Director();

            director.Construct(wuLingBuilder);
            var wulingCar = wuLingBuilder.GetCar();            
        }
    }

    //需要的角色

    //因为组装的各个部分，变化复杂，但是逻辑上都是指创建该部分，所以用抽象去表示，即创建一个抽象建造者角色（Builder）
    //比如，8缸和16缸的引擎创建流程差异巨大，但是对于创建流程来说，都是创建引擎。
    internal abstract class CarBuilder
    {
        public abstract void CreateEngine();
        public abstract void CreateShell();
        public abstract void CreateWheel();

        public abstract Car GetCar();
    }

    //接下来是创建的流程，该流程相对稳定，使用另一个类来表示，称为Director
    internal class Director
    {
        //此处使用依赖注入,以实现在相同流程下，可以创建不同的部件，来进行组合。
        public void Construct(CarBuilder builder)
        {
            builder.CreateEngine();
            builder.CreateShell();
            builder.CreateWheel();
        }
    }

    //问：能不能把创建的流程实现，放入到抽象创建者中？
    //答：如果以虚方法的方式写入，子类各自实现创建流程，这是违反了本模式的意图，也会容易违反里氏替换原则，是不可以的。
    //    如果以方法的方式写入，子类无法修改，那么调用创建函数的时候，是调用到父类里的函数，是可以的。

    //组装好的产品类
    //产品类重要实现组装的流程，因为创建的流程已经通过指导者固定，抽象创建者和具体创建者来实现。最后的创建完的组装，这是产品类要负责的东西。
    //注意：如果组装车辆的责任划分到构造器中，那么构造器的职责就包括了创建和组装，两个责任，违反了单一职责原则。这里还是坚持二者是分开的责任，参照现实的流水线，生产是生产，组装是组装。
    internal class Car
    {
        List<string> parts = new List<string>();

        public void AddPart(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("开始组装汽车....");
            foreach (var part in parts)
            {
                Console.WriteLine($"组装{part}完成");
            }
            Console.WriteLine("全部组装完成");
        }
    }

    //具体的创建类
    internal class WuLingBuilder : CarBuilder
    {
        Car wuLingCar = new Car();
        public override void CreateEngine()
        {
            wuLingCar.AddPart("五菱引擎");
        }

        public override void CreateShell()
        {
            wuLingCar.AddPart("五菱车架");
        }

        public override void CreateWheel()
        {
            wuLingCar.AddPart("五菱轮胎");
        }

        public override Car GetCar()
        {
            wuLingCar.Show();
            return wuLingCar;
        }
    }

}

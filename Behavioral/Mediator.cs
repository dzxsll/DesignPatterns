using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //中介者模式，类似MVC结构，其中的C就是中介者
    //核心就是只通过中介者类进行交流,让耦合路径全都指向中介者,而非杂乱无章的互相直连
    //现实中可以类比塔台和飞机
    class Mediator
    {


    }

    //面向抽象开发
    //因为是中介者,所以被中介的双方,都应该知道中介者的接口,这样双方才可以通过中介者交流,其次中介者如何让双方交流,也并非提前可知.所以这里的中介应该是一种交流能力,选择一个类作为拥有该能力的中介者
    public interface IMediator
    {
        void Notify(object sender);
    }

    //一个具体的中介者,包含着需要中介的各种对象
    public class Concretemediator : IMediator
    {
        private ComponentA componentA;
        private ComponentB componentB;
        private ComponentC componentC;

        public void Notify(object sender)
        {
            //这里就可以把abc....N之间的直接耦合解开,可能不止三个对象            

            //根据送来的对象来执行语句
            if (sender is ComponentA)
            {
                //这里a就和bc解耦,之和中介者进行耦合
                componentB.DoSomething();
                componentC.DoSomething();
            }
        }
    }

    //被中介的对象
    public class ComponentA : IMediator
    {
        public IMediator theMediator;

        public void Notify(object sender)
        {
            theMediator.Notify(sender);
        }
    }

    public class ComponentB : IMediator
    {
        public IMediator theMediator;

        public void DoSomething()
        {
        }


        public void Notify(object sender)
        {
            theMediator.Notify(sender);
        }
    }

    public class ComponentC : IMediator
    {
        public IMediator theMediator;

        public void DoSomething()
        {
        }

        public void Notify(object sender)
        {
            theMediator.Notify(sender);
        }
    }
}

using System;

namespace DesignPatterns.Behavioral
{
    //Also known as: Action(行动), Transaction(交易模式)
    //解耦同一功能，不同入口的前后台。比如一个保存功能，从菜单栏点击，还是使用快捷键触发，都会使用一段相同的代码。就会有冗余。
    //只是入口不一样，做的事情一样，干嘛不统一起来呢？就有了命令模式
    internal class TheCommand
    {
        public void ShowTheParten()
        {
            //创建真正做事的对象(最底层)
            MyEditer editer = new MyEditer();

            //创建命令
            CopyCommand copyCommand = new CopyCommand(editer);

            //创建调用者
            Invoker invoker = new Invoker(copyCommand);

            //发号施令
            invoker.ExecuteCommand();

            //构造的顺序从上倒下,但是调用的逻辑顺序是从下到上的.
        }
    }

    //既然是命令，那就一定有发出者，接收者，同时还要有命令本身。
    //命令本身有很多种，通过面向抽象开发，又要符合里氏替换原则，所以将命令分为抽象和具体实现。

    //发起者（可以是类，也可以是方法，只要能执行命令即可）
    public class Invoker
    {
        private Command _command;

        public Invoker(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command != null)
                _command.Execute();//执行命令，这是重点
        }
    }

    //接收者
    public class MyEditer
    {
        public void CopyContext()
        {
            Console.WriteLine("已经拷贝内容");
        }
    }

    //抽象命令
    public abstract class Command
    {
        //接收者
        public MyEditer editer;

        public Command(MyEditer editer)
        {
            this.editer = editer;
        }

        //执行
        public abstract void Execute();
    }

    //具体命令
    public class CopyCommand : Command
    {
        public CopyCommand(MyEditer editer) : base(editer)
        {
        }

        public override void Execute()
        {
            var content = editer.ToString();
            Console.WriteLine($"编辑器内容已复制");
        }
    }
}
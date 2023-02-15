using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    class Factory
    {
        //目的：为不同子类的创建，提供单一的入口

        //此处运用的面向对象设计原则：
        //1.封装变化
        //2.面向抽象编程
        //3.多组合，少继承
        //当新增子类，工厂类里就发生了变化，所以要封装工程类，同时面对抽象编程，要把变化的工厂类抽象，把具体的变化更改下移到子工厂类之中。

        public void CreatePhoneByFactory()
        {
            PhoneFactory phoneFactory;
            Phone myPhone;

            //优点：创建的方式完全一样，只是具体的创建工厂变换了而已。
            //缺点：每增加一个子类，就要新增一个工厂。

            phoneFactory = new IphoneFactory();
            myPhone = phoneFactory.CreateOne();
            myPhone.Call("1111");

            phoneFactory = new XiaoMiphoneFactory();
            myPhone = phoneFactory.CreateOne();
            myPhone.Call("2222");
        }

    }

    //既然是不同的子类，那么就一定要有一个基类。比如手机
    public interface Phone
    {
        public bool Call(string phoneNumber);

        public bool Text(string phoneNumber);

    }


    //这是特定实现的子类
    public class Iphone : Phone
    {
        public string appid { get; set; }

        public bool Call(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Text(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }

    //这是特定实现的子类
    public class XiaoMiphone : Phone
    {
        public string MiAccount { get; set; }

        public bool Call(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Text(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }

    //这里要区分抽象和接口的概念，抽象表明的是一个"是不是"的关系，而接口表明的是一个"有没有"的关系。
    //所以在这个例子里：
    //  不同品牌的手机应该具有通信的功能。这里的Phone不应该指电话，而是指具有通信的能力。不同的子类会有自己不同的属性(比如处理器)，但是应该具有相同的能力。
    //  不同品牌的工厂应该是一种特别工厂。

    //为了提供单一的入口，那么就要使用一个基类工厂，保证创建的方式是一致的
    public abstract class PhoneFactory
    {
        public abstract Phone CreateOne();
    }

    //这是特定的工厂
    public class IphoneFactory : PhoneFactory
    {
        public override Phone CreateOne()
        {
            return new Iphone();
        }
    }

    //这是特定的工厂
    public class XiaoMiphoneFactory : PhoneFactory
    {
        public override Phone CreateOne()
        {
            return new XiaoMiphone();
        }
    }
}

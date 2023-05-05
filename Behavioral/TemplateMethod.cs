using System;

namespace DesignPatterns.Behavioral
{
    //模板方法：稳定结构下的算法中，子步骤可以灵活变化。
    //比如吃自己做的饺子这个过程，做皮，做馅，做熟饺子。
    //  皮，我可以做厚的，做薄的。
    //  馅，可以做不同味道的。
    //  熟，可以是蒸的，也可以是煮的。
    //但是上面这个流程是固定的。
    internal class TemplateMethod
    {
        public TemplateMethod()
        {
            TheWayOfMakingDumpling myWay = new MyWay();

            myWay.MakingDumpling();

            TheWayOfMakingDumpling mothersWay = new MothersWay();

            mothersWay.MakingDumpling();
        }
        
    }

    //抽象类角色，定义算法的骨架。
    public abstract class TheWayOfMakingDumpling
    {
        public void MakingDumpling()
        {
            MakingDough();

            MakingFilling();

            CookDumpling();
        }

        public abstract void MakingDough();

        public abstract void MakingFilling();

        public abstract void CookDumpling();
    }

    //我自己做饺子的办法
    public class MyWay : TheWayOfMakingDumpling
    {
        public override void MakingDough()
        {
            Console.WriteLine("做薄皮的");
        }

        public override void MakingFilling()
        {
            Console.WriteLine("做纯肉的");
        }

        public override void CookDumpling()
        {
            Console.WriteLine("要蒸的");
        }
    }

    //我妈做饺子的办法
    public class MothersWay : TheWayOfMakingDumpling
    {
        public override void MakingDough()
        {
            Console.WriteLine("做厚皮的");
        }

        public override void MakingFilling()
        {
            Console.WriteLine("做韭菜肉的");
        }

        public override void CookDumpling()
        {
            Console.WriteLine("要水煮的");
        }
    }
}
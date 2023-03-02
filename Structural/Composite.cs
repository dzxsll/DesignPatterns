using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //组合模式:树形结构,以及统一简单类型和复杂类型的接口
    class Composite
    {
        public Composite()
        {
            IGraphic dotA = new Dot();
            IGraphic dotB = new Dot();
            CompoundGraphic area = new CompoundGraphic();

            Console.WriteLine("简单类调用Draw接口");
            dotA.Draw();
            dotB.Draw();

            Console.WriteLine("复杂类调用Draw接口");
            area.Add(dotA);
            area.Add(dotB);
            
            IGraphic dotC = new Dot();
            IGraphic dotD = new Dot();
            //在组合中添加一个组合
            CompoundGraphic areaInArea = new CompoundGraphic();
            areaInArea.Add(dotC);
            areaInArea.Add(dotD);

            area.Add(areaInArea);

            //即使是复杂的对象,接口的操作和简单的对象是一致的
            area.Draw();
        }
    }

    //首先创立一个统一的接口
    public interface IGraphic
    {
        void Move(int x, int y);
        void Draw();
    }

    //树叶:没有子成员的最基础的类,实现了接口.
    public class Dot : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("画了个点.");
        }

        public void Move(int x, int y)
        {
            Console.WriteLine($"x移动了{x}距离,y移动了{y}距离");
        }
    }

    //树枝:存储了一些子成员,除了增删的操作,其他的操作都是由每一个子成员来负责
    public class CompoundGraphic : IGraphic
    {
        public List<IGraphic> children = new List<IGraphic>();

        public void Add(IGraphic child)
        {
            children.Add(child);
        }

        public void Remove(IGraphic child)
        {
            children.Remove(child);
        }

        public void Draw()
        {
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public void Move(int x, int y)
        {
            foreach (var child in children)
            {
                child.Move(x, y);
            }
        }
    }

}

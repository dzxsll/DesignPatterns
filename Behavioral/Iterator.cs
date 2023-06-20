using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //迭代器模式
    //常用集合类就是该模式,白话说就是一个一个返回的模式。
    class IteratorPattern
    {
    }

    //依然是面向抽象的主原则,分四个角色

    //抽象迭代器
    public interface Iterator
    {
        bool MoveNext();

        object GetCurrent();

        void Next();

        void Reset();
    }

    //抽象聚合类
    public interface ITroopQueue
    {
        Iterator GetIterator();
    }

    //具体迭代器
    public class ConcreteIterator : Iterator
    {
        private ConcreteTroopQueue _list;
        private int _index;

        public ConcreteIterator(ConcreteTroopQueue list)
        {
            _list = list;
            _index = 0;
        }

        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }

        }
    }


    //具体聚合类
    public class ConcreteTroopQueue : ITroopQueue
    {
        private string[] collection;

        public ConcreteTroopQueue()
        {
            collection = new string[] { "黄飞鸿", "方世玉", "洪熙官", "严咏春" };
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public string GetElement(int index)
        {
            return collection[index];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //避免大量的相同的对象创建，给内存带来难以承受的开销
    //核心是复用，复用一些本质的属性(通常不变化)，组合一些外在总是变化的属性。
    //白话说就是，不要重复创建相同的对象，一些重复的属性就独立出来。

    class Flyweight
    {

    }

    //享元单元(Flyweight),里面装一些重复的属性，本质性的东西
    class TreeType
    {
        public string name;
        public string color;
        public string texture;

        public TreeType(string name, string color, string texture)
        {
            this.name = name;
            this.color = color;
            this.texture = texture;
        }

        public void Draw(object canvas, int x, int y)
        {
            //draw Tree in canvas with x , y
        }
    }

    //享元工厂,负责存储享元，以及提供已经创建过的享元，即复用享元。
    class TreetypeFactory
    {
        //存储已经创建的对象
        public static HashSet<TreeType> treeTypes = new HashSet<TreeType>();

        //如果已经创建过的对象就直接从队列中直接取出。
        public static TreeType GetTreeType(string name, string color, string texture)
        {
            var tmpType = treeTypes.Where(i => i.name.Equals(name) && i.color.Equals(color) && i.texture.Equals(texture)).FirstOrDefault();
            if (tmpType != null)
                return tmpType;

            var newType = new TreeType(name, color, texture);
            treeTypes.Add(newType);
            return newType;
        }
    }

    //使用享元的类    
    class Tree
    {
        //通过组合的方式，把本质的，不容易变化的属性独立出来，可以独立创建，可以复用。       
        public int x, y;
        public TreeType type;

        public Tree(int x, int y, TreeType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void Draw(string canvas)
        {
            type.Draw(canvas, x, y);
        }
    }

    class Forest
    {
        public List<Tree> trees = new List<Tree>();

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            var type = TreetypeFactory.GetTreeType(name, color, texture);

            var tree = new Tree(x, y, type);

            trees.Add(tree);
        }

        public void Draw(string canvas)
        {
            foreach (var tree in trees)
            {
                tree.Draw(canvas);
            }
        }
    }
}

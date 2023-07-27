using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //定义了一对多的依赖关系,一个对象改变，通知所有依赖于它的对象。
    //原先别称为"发布订阅模式",但是"发布订阅模式"已经发展为独立的设计模式了，与观察者模式的差别在于多了一个中间的消息管理类，参见同文件夹内的PubSub.cs

    class Observer
    {
        //把构造函数拟定成调用者
        public Observer()
        {
            //先创建一个被观察者


            EventManager eventManager = new EventManager();

            //创建一个观察者 

            SpecialListener specialListener = new SpecialListener();

            SpecialListener specialListenerAnother = new SpecialListener();


            eventManager.Subscribe("eventOne", specialListener);

            eventManager.Subscribe("eventOne", specialListenerAnother);

            eventManager.Notify("eventOne", new object());
        }
    }

    //先面对抽象编程,再具体实现,先用自然语言描述,再实现代码

    //一个被观察者,一群观察者,被观察者中存储着观察者，一旦发生变动就通知观察者

    //被观察者要有订阅和取消订阅，还有通知的能力
    public class EventManager
    {
        //保存观察者的队列
        private Dictionary<string, List<IEventListener>> listeners;

        public EventManager()
        {
            listeners = new Dictionary<string, List<IEventListener>>();
        }

        //把观察者添加到队列中
        public void Subscribe(string eventName, IEventListener listener)
        {
            if (listeners.TryGetValue(eventName, out List<IEventListener> eventListerners))
            {
                if (!eventListerners.Contains(listener))
                {
                    eventListerners.Add(listener);
                }
            }
        }

        //把观察者从队列中移除
        public void Unsubscribe(string eventName, IEventListener listener)
        {
            if (listeners.TryGetValue(eventName, out List<IEventListener> eventListerners))
            {
                if (!eventListerners.Contains(listener))
                {
                    eventListerners.Remove(listener);
                }
            }
        }

        public void Notify(string eventName, object data)
        {
            if (listeners.TryGetValue(eventName, out List<IEventListener> eventListerners))
            {
                foreach (var item in eventListerners)
                {
                    item.Update(data);
                }
            }
        }

    }

    //观察者需要有被通知的能力
    public interface IEventListener
    {
        public void Update(object data);
    }

    //观察者,具体的观察者有很多,每一个观察者都应该实现接口，然后根据不同的事件给出不同的处理方式。
    public class SpecialListener : IEventListener
    {
        private object updateData;

        public void Update(object data)
        {
            updateData = data;
            Console.WriteLine("更新啦更新啦");
        }
    }
}

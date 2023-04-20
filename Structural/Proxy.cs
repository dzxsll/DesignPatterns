using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //代理模式：类比一个控制器，接受所有的请求，进行过滤和验证，把允许的请求发送给真正处理请求的类，或者缓存请求，合理调度。
    class Proxy
    {
        public void init()
        {
            //首先要有一个真正的服务
            var realService = new ThirdPartyYouTubeClass();

            //然后有一个代理
            var proxyService = new CachedYouTubeClass(realService);

            //一个使用代理的类
            var manager = new YouTubeManager(proxyService);

            manager.reactOnUserInput();
        }
    }

    //首先，还是从面向抽象这个思想开始，确定服务的接口
    public interface ThirdPartyYouTubeLib
    {
        public List<object> ListVideos();
        public object GetVideoInfo(string id);
        public bool DownVideo(string id);
    }

    //服务接口的实现
    public class ThirdPartyYouTubeClass : ThirdPartyYouTubeLib
    {
        public bool DownVideo(string id)
        {
            throw new NotImplementedException();
        }

        public object GetVideoInfo(string id)
        {
            throw new NotImplementedException();
        }

        public List<object> ListVideos()
        {
            throw new NotImplementedException();
        }
    }

    //首先，代理必须要实现服务的接口，因为代理对外要表现得和实际得服务一样，内部有自己得处理。
    //其次，代理还要组合一个真正的服务,并给同名的接口实现
    public class CachedYouTubeClass : ThirdPartyYouTubeLib
    {
        public ThirdPartyYouTubeLib service;
        public bool NeedReset = false;
        public List<object> videoCache = new List<object>();
        public List<object> listCache = new List<object>();

        public CachedYouTubeClass(ThirdPartyYouTubeLib service)
        {
            this.service = service;
        }

        public bool DownVideo(string id)
        {
            throw new NotImplementedException();
        }

        public object GetVideoInfo(string id)
        {
            if (videoCache == null || NeedReset)
                videoCache = new List<object>() { service.GetVideoInfo(id) };
            return videoCache;
        }

        public List<object> ListVideos()
        {
            if (listCache == null || NeedReset)
                service.ListVideos();

            return listCache;
        }
    }

    //调用方
    public class YouTubeManager
    {
        public ThirdPartyYouTubeLib service;

        public YouTubeManager(ThirdPartyYouTubeLib service)
        {
            this.service = service;
        }

        public void renderVideoPage(string id)
        {
            var info = service.GetVideoInfo(id);
        }

        public void renderListPanel()
        {
            var info = service.ListVideos();
        }

        public void reactOnUserInput()
        {
            renderListPanel();
            renderVideoPage("id");
        }
    }
}

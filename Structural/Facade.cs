using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //外观模式：就是封装的意思,增加一个外观类,耦合转移到外观类中,
    class Facade
    {

    }

    class Client
    {
        //无外观模式瞎的耦合情况
        public void buy()
        {
            AuthoriationSystemA authoriationSystemA = new AuthoriationSystemA();
            SecuritySystemB securitySystemB = new SecuritySystemB();
            NetBankSystemC netBankSystemC = new NetBankSystemC();

            authoriationSystemA.MethodA();
            securitySystemB.MethodB();
            netBankSystemC.MethodC();

            Console.WriteLine("我已经成功购买了！");

        }

        //使用外观模式的耦合情况
        public void buyInFacade()
        {
            SystemFacaed facaed = new SystemFacaed();

            facaed.buy();
        }
    }

    // 身份认证子系统A
    public class AuthoriationSystemA
    {
        public void MethodA()
        {
            Console.WriteLine("执行身份认证");
        }
    }

    // 系统安全子系统B
    public class SecuritySystemB
    {
        public void MethodB()
        {
            Console.WriteLine("执行系统安全检查");
        }
    }

    // 网银安全子系统C
    public class NetBankSystemC
    {
        public void MethodC()
        {
            Console.WriteLine("执行网银安全检测");
        }
    }

    public class SystemFacaed
    {
        private AuthoriationSystemA authoriationSystemA = new AuthoriationSystemA();
        private SecuritySystemB securitySystemB = new SecuritySystemB();
        private NetBankSystemC netBankSystemC = new NetBankSystemC();

        public SystemFacaed()
        {

        }

        public void buy()
        {
            authoriationSystemA.MethodA();
            securitySystemB.MethodB();
            netBankSystemC.MethodC();

            Console.WriteLine("我已经成功购买了！");
        }
    }
}

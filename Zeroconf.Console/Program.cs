using System;
using Zeroconf;

namespace Zeroconf.Console
{
    class MyListener : IListener
    {
        public void RemoveService(Zeroconf zc, string type, string name)
        {
            System.Console.WriteLine("Service {0} removed", name);
        }

        public void AddService(Zeroconf zc, string type, string name)
        {
            ServiceInfo info = zc.GetServiceInfo(type.ToString(), name);
            System.Console.WriteLine("Service {0} added, info: {1}", name, info);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string serviceName = "_xboxcol._tcp.local.";

            System.Console.WriteLine("Zeroconf Sample Application");
            Zeroconf zeroconf = new Zeroconf();
            MyListener listener = new MyListener();
            ServiceBrowser browser = new ServiceBrowser(zeroconf, serviceName,
                                                        listener: listener);

            System.Console.WriteLine("Press ESC to stop application");
            bool run = true;
            while(run)
            {
                if (System.Console.ReadKey().Key == ConsoleKey.Escape)
                    run = false;
            }

            System.Console.WriteLine("Bye!");
            zeroconf.Close();
        }
    }
}

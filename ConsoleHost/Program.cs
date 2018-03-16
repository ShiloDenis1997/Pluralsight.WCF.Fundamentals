using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary;

namespace ConsoleHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost host = new ServiceHost(typeof(EvalService));

            //ServiceMetadataBehavior behavior = new ServiceMetadataBehavior
            //{
            //    HttpGetEnabled = true,
            //    HttpGetUrl = new Uri("http://localhost:8080/evals/meta")
            //};
            //host.Description.Behaviors.Add(behavior);

            //host.AddServiceEndpoint(typeof(IEvalService),
            //    new BasicHttpBinding(),
            //    "http://localhost:8080/evals/basic");
            //host.AddServiceEndpoint(typeof(IEvalService),
            //    new WSHttpBinding(),
            //    "http://localhost:8080/evals/ws");
            //host.AddServiceEndpoint(typeof(IEvalService),
            //    new NetTcpBinding(),
            //    "net.tcp://localhost:8082/evals");

            //WebServiceHost host = new WebServiceHost(
            //    typeof(EvalService), new Uri("http://localhost:8080"));

            ServiceHost host = new ServiceHost(typeof(RestEvalService));

            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadKey(true);
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine($"{host.Description.ServiceType} is up and running with these endpoints:");
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine(endpoint.Address);
            }
        }
    }
}

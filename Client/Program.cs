using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using Client.EvalServiceReference;
using Client.RestEvalService;
using EvalServiceLibrary;
using IEvalService = Client.EvalServiceReference.IEvalService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkViaGeneratedProxy();
            //WorkViaChannelFactory();
            RestEvalServiceClient client = 
                new RestEvalServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/evalservice"));
            //client.Endpoint.Behaviors.Add(new WebHttpBehavior());
            Console.WriteLine(client.GetAllEvals());
        }

        static void WorkViaGeneratedProxy()
        {
            Console.WriteLine("Retrieving endpoints vis MEX...");
            ServiceEndpointCollection endpoints = 
                MetadataResolver.Resolve(typeof(IEvalService),
                    new EndpointAddress("http://localhost:8080/evals/mex"));
            Console.WriteLine("Endpoints retrieved");

            foreach (var endpoint in endpoints)
            {
                Console.WriteLine(endpoint.Address.Uri);
                var client = new EvalServiceClient(endpoint.Binding, endpoint.Address);
                try
                {
                    WorkWithService(client);
                    client.Close();
                }
                catch (FaultException fe)
                {
                    Console.WriteLine($"Fault exception: {fe.GetType()}");
                    client.Abort();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine($"Communication exception: {ce.GetType()}");
                    client.Abort();
                }
                catch (TimeoutException te)
                {
                    Console.WriteLine($"Timeout exception: {te.GetType()}");
                    client.Abort();
                }
            }
        }

        static void WorkViaChannelFactory()
        {
            ChannelFactory<IEvalServiceChannel> channelFactory
                = new ChannelFactory<IEvalServiceChannel>("BasicHttpBinding_IEvalService");

            var channel = channelFactory.CreateChannel();
            WorkWithService(channel);
            channel.Close();
        }

        static void WorkWithService(IEvalService service)
        {
            service.SubmitEval(new Eval("Denis")
            {
                Comments = "Hello",
                Timesent = DateTime.Now
            });

            Console.WriteLine("Right before Call");
            var evals = service.GetEvals();
            Console.WriteLine("Right after Call");
            foreach (var eval in evals)
            {
                Console.WriteLine(eval);
                Console.WriteLine();
            }
        }
    }
}

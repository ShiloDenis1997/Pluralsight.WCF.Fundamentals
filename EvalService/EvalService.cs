using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    [ServiceContract]
    public interface IEvalService
    {
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "evals", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void SubmitEval(Eval eval);
        [WebGet(UriTemplate = "evals", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Eval> GetEvals();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        private readonly List<Eval> _evals = new List<Eval>();

        public void SubmitEval(Eval eval)
        {
            if (eval.Submitter.Equals("Throw", StringComparison.OrdinalIgnoreCase))
            {
                throw new FaultException("Error with SubmitEval");
            }
            _evals.Add(eval);
        }

        public List<Eval> GetEvals()
        {
            //System.Threading.Thread.Sleep(5000);
            return _evals;
        }
    }
}

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
    public interface IRestEvalService
    {
        //[WebInvoke(RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "evals")]
        [OperationContract]
        Eval SubmitEval(Eval eval);

        //[WebGet(ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "evals?id={id}")]
        [OperationContract]
        Eval GetEval(string id);

        //[WebGet(ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "evals")]
        [OperationContract]
        List<Eval> GetAllEvals();

        //[WebGet(ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "evals?submitter={submitter}")]
        [OperationContract]
        List<Eval> GetEvalsBySubmitter(string submitter);

        //[WebInvoke(Method = "DELETE",
        //    UriTemplate = "evals?id={id}")]
        [OperationContract]
        void RemoveEval(string id);
    }

    public class RestEvalService : IRestEvalService
    {
        private readonly List<Eval> _evals = new List<Eval>();
        private int _evalCount;

        public Eval SubmitEval(Eval eval)
        {
            eval.Id = (++_evalCount).ToString();
            _evals.Add(eval);
            return eval;
        }

        public Eval GetEval(string id)
        {
            return _evals.FirstOrDefault(
                e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Eval> GetAllEvals()
        {
            return _evals;
        }

        public List<Eval> GetEvalsBySubmitter(string submitter)
        {
            return _evals.Where(
                e => e.Submitter.Equals(submitter, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void RemoveEval(string id)
        {
            var eval = GetEval(id);
            if (eval != null)
            {
                _evals.Remove(eval);
            }
        }
    }
}

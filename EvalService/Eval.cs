using System;
using System.Runtime.Serialization;

namespace EvalServiceLibrary
{
    [DataContract]
    public class Eval
    {
        public Eval()
        {
            Submitter = "Denis";
        }

        public Eval(string submitter)
        {
            Submitter = submitter;
        }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Submitter { get; set; }
        [DataMember]
        public DateTime Timesent { get; set; }
        [DataMember]
        public string Comments { get; set; }

        public override string ToString()
        {
            return $"{Comments}\n{Submitter}\n{Timesent}";
        }
    }
}
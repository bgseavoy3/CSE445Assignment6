using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AnalyzeInput", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AnalysisResult AnalyzeInput(string input);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class AnalysisResult
    {
        [DataMember]
        public string Diagnosis { get; set; }
        [DataMember]

        public string Urgency { get; set; }
        [DataMember]

        public string Severity { get; set; }
        [DataMember]

        public string[] Symptoms { get; set; }
        [DataMember]

        public int SymptomCount { get; set; }
    }

}

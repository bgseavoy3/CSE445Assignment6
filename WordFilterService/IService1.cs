using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WordFilterService
{
    [ServiceContract]
    public interface IWordFilterService
    {
        [OperationContract]
        string WordFilter(string input);
    }
}

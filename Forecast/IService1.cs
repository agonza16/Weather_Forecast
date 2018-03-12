using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace Forecast
{
    
    [ServiceContract]
    public interface IService1
    {
        /* The purpose of this function is to return the five day forceast of a given zipcode
         * from today's date, an array[] will be returned. array[0-4] will contain the maximums
         * and array[5-9] will contain the minimums
         * 
         * input: string zipcode
         * 
         * output: array 
         * 
         */ 
        [OperationContract]
        string[] Weather5day(string zipcode);


    }


    
}

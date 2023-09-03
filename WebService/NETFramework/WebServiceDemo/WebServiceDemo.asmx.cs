using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

// Ref: https://www.c-sharpcorner.com/UploadFile/00a8b7/web-service/

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for WebServiceDemo
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/", Name = "WebSvcDemo", Description = "A Demo WebService")]
    [WebService(Namespace = "http://some-domain.com/WebServiceDemo", Name = "WebSvcDemo", Description = "A Demo WebService Example")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]  // used to allow overloading SumOfNums
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceDemo : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //public int SumOfNums(int First, int Second)
        //{
        //    return First + Second;
        //}
        
        //[WebMethod(MessageName = "SumOfFloats")]
        //public float SumOfNums(float First, float Second)
        //{
        //    return First + Second;
        //}

        // Takes 2 int values & returns their summation
        [WebMethod]
        public int SumOfNums(int First, int Second)
        {
            return First + Second;
        }

        // Takes a stringified JSON object & returns an object of SumClass
        [WebMethod(MessageName = "GetSumThroughObject")]
        public SumClass SumOfNums(string JsonStr)
        {
            var ObjSerializer = new JavaScriptSerializer();
            var ObjSumClass = ObjSerializer.Deserialize<SumClass>(JsonStr);
            return new SumClass().GetSumClass(ObjSumClass.First, ObjSumClass.Second);
        }
    }

    // Normal class, an instance of which will be returned by service
    public class SumClass
    {
        public int First, Second, Sum;

        public SumClass GetSumClass(int Num1, int Num2)
        {
            var ObjSum = new SumClass
            {
                Sum = Num1 + Num2,
            };
            return ObjSum;
        }
    }
}

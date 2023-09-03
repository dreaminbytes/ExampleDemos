using ServiceConsumer.WebServiceReference;

using System;
using System.Linq;
using System.Web.Script.Serialization;

namespace ServiceConsumer
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void AddNumber(object Sender, EventArgs E)
        {
            int Num1, Num2;
            int.TryParse(txtFirstNum.Value, out Num1);
            int.TryParse(txtSecondNum.Value, out Num2);
            // creating object of MyService proxy class
            var ObjMyServiceProxy = new WebSvcDemoSoapClient();

            // Invoke service method through service proxy
            divSum.InnerHtml = ObjMyServiceProxy.SumOfNums(Num1, Num2).ToString();

            var ObjSumClass = new SumClass { First = Num1, Second = Num2 };
            var ObjSerializer = new JavaScriptSerializer();
            var JsonStr = ObjSerializer.Serialize(ObjSumClass);
            //Error - no access to name 'GetSumThroughObject'
            //divSumThroughJson.InnerHtml = ObjMyServiceProxy.GetSumThroughObject(JsonStr).Sum.ToString();
            divSumThroughJson.InnerHtml = ObjMyServiceProxy.SumOfNums1(JsonStr).Sum.ToString();
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;

namespace SharpReportWeb.WebService
{
    /// <summary>
    /// SampleRateService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class SampleRateService : System.Web.Services.WebService
    {

        [WebMethod(Description = "获取汇率的服务样例，参数currencyID为币种ID")]
        public List<ExchangeRateInfo> GetRateList(string currencyID)
        {
            if (currencyID == string.Empty)
            {
                return new ExchangeRate().GetList() as List<ExchangeRateInfo>;
            }
            return new ExchangeRate().GetList(currencyID) as List<ExchangeRateInfo>;
        }
    }
}

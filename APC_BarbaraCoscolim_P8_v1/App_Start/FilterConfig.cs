using System.Web;
using System.Web.Mvc;

namespace APC_BarbaraCoscolim_P8_v1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

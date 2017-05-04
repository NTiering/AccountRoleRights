namespace App.Mvc
{
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new Filters.SetSectionsFilter());
            GlobalFilters.Filters.Add(new Filters.SetSelectItemFilter());
        }
    }
}

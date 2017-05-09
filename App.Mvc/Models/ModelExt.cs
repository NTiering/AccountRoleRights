namespace App.Mvc.Models
{
    using App_Start;
    using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Ninject;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public static class ModelExt
    {

        /// <summary>
        /// Represents a single Account instance as a select list item 
        /// </summary>
        public static SelectListItem ToSelectListItem(this IAccountDataModel model,IAccountDataModel selected = null)
        {
            if (model == null)
            {
                return new SelectListItem();
            }
            else
            {
                return new SelectListItem
                {
                    Text = string.Format("[{0}] {1}", model.Id,model.AccountValidFrom.ToString()), // change how the Account appear in drop downs here
                    Value = model.Id.ToString(),
                    Selected = (selected  != null && selected.Id == model.Id)
                };
            }
        }

        /// <summary>
        /// Represents a collection Account instance as select list items
        /// </summary>
        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<IAccountDataModel> models, IAccountDataModel selected = null)
        {
            if (models == null)
            {
                return Enumerable.Empty<SelectListItem>();
            }
            else
            {
                var rtn = new List<SelectListItem>();
                rtn.Add(new SelectListItem{ Text = "Select ....." , Value = "-1" });
                rtn.AddRange(models.Select(x => x.ToSelectListItem(selected)).OrderBy(x => x.Text));
                return rtn;
            }
        }
        
        /// <summary>
        /// Represents a single Role instance as a select list item 
        /// </summary>
        public static SelectListItem ToSelectListItem(this IRoleDataModel model,IRoleDataModel selected = null)
        {
            if (model == null)
            {
                return new SelectListItem();
            }
            else
            {
                return new SelectListItem
                {
                    Text = string.Format("[{0}] {1}", model.Id,model.IsAssignable.ToString()), // change how the Role appear in drop downs here
                    Value = model.Id.ToString(),
                    Selected = (selected  != null && selected.Id == model.Id)
                };
            }
        }

        /// <summary>
        /// Represents a collection Role instance as select list items
        /// </summary>
        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<IRoleDataModel> models, IRoleDataModel selected = null)
        {
            if (models == null)
            {
                return Enumerable.Empty<SelectListItem>();
            }
            else
            {
                var rtn = new List<SelectListItem>();
                rtn.Add(new SelectListItem{ Text = "Select ....." , Value = "-1" });
                rtn.AddRange(models.Select(x => x.ToSelectListItem(selected)).OrderBy(x => x.Text));
                return rtn;
            }
        }
        
        /// <summary>
        /// Represents a single Right instance as a select list item 
        /// </summary>
        public static SelectListItem ToSelectListItem(this IRightDataModel model,IRightDataModel selected = null)
        {
            if (model == null)
            {
                return new SelectListItem();
            }
            else
            {
                return new SelectListItem
                {
                    Text = string.Format("[{0}] {1}", model.Id,model.IsAssignable.ToString()), // change how the Right appear in drop downs here
                    Value = model.Id.ToString(),
                    Selected = (selected  != null && selected.Id == model.Id)
                };
            }
        }

        /// <summary>
        /// Represents a collection Right instance as select list items
        /// </summary>
        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<IRightDataModel> models, IRightDataModel selected = null)
        {
            if (models == null)
            {
                return Enumerable.Empty<SelectListItem>();
            }
            else
            {
                var rtn = new List<SelectListItem>();
                rtn.Add(new SelectListItem{ Text = "Select ....." , Value = "-1" });
                rtn.AddRange(models.Select(x => x.ToSelectListItem(selected)).OrderBy(x => x.Text));
                return rtn;
            }
        }
        

    }
}
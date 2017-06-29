namespace App.Dal
{
	using Contracts;
    using System.Collections.Generic;
    using Contracts.Search;
    using Search;
    using Contracts.DataModels;
    using EntityDataModels;
    using System.Linq;

	class SearchDal : ISearchDal
	{

		/// <summary>
		/// Returns search results for CustomerSearch search 
		/// </summary>
		public ICustomerSearchResponse GetCustomerSearch(ICustomerSearchRequest request, IModelContext context = null)
		{
			// var ctx = new AppContext();
            // todo : use ctx to build a results sets of ICustomerSearchDataModel objects (its implemeted as a CustomerSearchEntityDataModel() )
            var results = new List<ICustomerSearchDataModel>();
            results.Add(new CustomerSearchEntityDataModel());

            // build results object and return
            var rtn = new CustomerSearchResponseDataModel
            {
                 Results = results.AsQueryable(),
                 TotalRecordCount = results.Count()
            };

            return rtn;
		}
		/// <summary>
		/// Returns search results for CustomerUsernameSearch search 
		/// </summary>
		public ICustomerUsernameSearchResponse GetCustomerUsernameSearch(ICustomerUsernameSearchRequest request, IModelContext context = null)
		{
			// var ctx = new AppContext();
            // todo : use ctx to build a results sets of ICustomerUsernameSearchDataModel objects (its implemeted as a CustomerUsernameSearchEntityDataModel() )
            var results = new List<ICustomerUsernameSearchDataModel>();
            results.Add(new CustomerUsernameSearchEntityDataModel());

            // build results object and return
            var rtn = new CustomerUsernameSearchResponseDataModel
            {
                 Results = results.AsQueryable(),
                 TotalRecordCount = results.Count()
            };

            return rtn;
		}		  
	}
}
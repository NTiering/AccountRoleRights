namespace App.Services
{
	using Contracts;
    using System.Collections.Generic;
    using Contracts.Search;

	class SearchService : ISearchService
	{
		private ISearchDal searchDal ;

		public SearchService(ISearchDal searchDal)
		{
			this.searchDal = searchDal ; 
		}

		/// <summary>
        /// Returns search results for CustomerSearch search 
		/// </summary>		
		public ICustomerSearchResponse GetCustomerSearch(ICustomerSearchRequest request, List<IModelError> errors, IModelContext context = null)
		{			
			return searchDal.GetCustomerSearch(request,context);
		}
		 

		/// <summary>
        /// Returns search results for CustomerUsernameSearch search 
		/// </summary>		
		public ICustomerUsernameSearchResponse GetCustomerUsernameSearch(ICustomerUsernameSearchRequest request, List<IModelError> errors, IModelContext context = null)
		{			
			return searchDal.GetCustomerUsernameSearch(request,context);
		}
		 
	}
}
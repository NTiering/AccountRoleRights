namespace App.Services
{
	using Contracts;
    using System.Collections.Generic;
    using Contracts.Search;

	public interface ISearchService
	{

		/// <summary>
        /// Returns search results for CustomerSearch search 
		/// </summary>		
		ICustomerSearchResponse GetCustomerSearch(ICustomerSearchRequest request, List<IModelError> errors, IModelContext context = null); 

		/// <summary>
        /// Returns search results for CustomerUsernameSearch search 
		/// </summary>		
		ICustomerUsernameSearchResponse GetCustomerUsernameSearch(ICustomerUsernameSearchRequest request, List<IModelError> errors, IModelContext context = null); 
	}
}
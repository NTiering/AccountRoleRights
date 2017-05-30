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
		ICustomerSearchResponse GetCustomerSearch(ICustomerSearchContracts request, List<IModelError> errors, IModelContext context = null); 

		/// <summary>
        /// Returns search results for CustomerUsernameSearch search 
		/// </summary>		
		ICustomerUsernameSearchResponse GetCustomerUsernameSearch(ICustomerUsernameSearchContracts request, List<IModelError> errors, IModelContext context = null); 
	}
}
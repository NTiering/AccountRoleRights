namespace App.Contracts
{
	using Contracts;
    using System.Collections.Generic;
    using Contracts.Search;

	public interface ISearchDal
	{

		/// <summary>
		/// Returns search results for CustomerSearch search 
		/// </summary>
		ICustomerSearchResponse GetCustomerSearch(ICustomerSearchContracts request, IModelContext context = null); 

		/// <summary>
		/// Returns search results for CustomerUsernameSearch search 
		/// </summary>
		ICustomerUsernameSearchResponse GetCustomerUsernameSearch(ICustomerUsernameSearchContracts request, IModelContext context = null); 
	}
}
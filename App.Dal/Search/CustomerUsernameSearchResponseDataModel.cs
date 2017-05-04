namespace App.Dal.Search
{
    using Contracts.DataModels;
    using Contracts.Search;
    using System.Linq;

    /// <summary>
    /// A data set for CustomerUsernameSearch 
    ///</summary>
    class CustomerUsernameSearchResponseDataModel : ICustomerUsernameSearchResponse
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IQueryable<ICustomerUsernameSearchDataModel> Results { get; set; }

        /// <summary>
        /// The total record count.
        /// </summary>
        public int TotalRecordCount { get; set; }
    }
}
namespace App.Dal.Search
{
    using Contracts.DataModels;
    using Contracts.Search;
    using System.Linq;

    /// <summary>
    /// A data set for CustomerSearch 
    ///</summary>
    class CustomerSearchResponseDataModel : ICustomerSearchResponse
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IQueryable<ICustomerSearchDataModel> Results { get; set; }

        /// <summary>
        /// The total record count.
        /// </summary>
        public int TotalRecordCount { get; set; }
    }
}
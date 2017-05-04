namespace App.Contracts.Search
{
    using App.Contracts.DataModels;
    using System.Linq;

    /// <summary>
    /// A data set for CustomerSearch 
    ///</summary>
    public interface ICustomerSearchResponse
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        IQueryable<ICustomerSearchDataModel> Results { get; set; }

        /// <summary>
        /// The total record count.
        /// </summary>
        int TotalRecordCount { get; set; }
    }
}
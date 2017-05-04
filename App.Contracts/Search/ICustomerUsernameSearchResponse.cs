namespace App.Contracts.Search
{
    using App.Contracts.DataModels;
    using System.Linq;

    /// <summary>
    /// A data set for CustomerUsernameSearch 
    ///</summary>
    public interface ICustomerUsernameSearchResponse
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        IQueryable<ICustomerUsernameSearchDataModel> Results { get; set; }

        /// <summary>
        /// The total record count.
        /// </summary>
        int TotalRecordCount { get; set; }
    }
}
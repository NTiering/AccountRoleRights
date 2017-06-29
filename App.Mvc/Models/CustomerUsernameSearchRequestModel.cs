namespace App.Mvc.Models
{
    using App.Contracts.Search;

    /// <summary>
    /// Represents a request for a CustomerUsernameSearch data set
    ///</summary>
    class CustomerUsernameSearchRequestModel : ICustomerUsernameSearchRequest
    {

        public int Username { get;set; }
                /// <summary>
        /// Filter result set with string
        /// </summary>
        public string SearchFilter { get; set; }

        /// <summary>
        /// Number of recorde per page.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Number of pages.
        /// </summary>
        public int PageCount { get; }
    }
}
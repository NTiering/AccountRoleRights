namespace App.Mvc.Models
{
    using App.Contracts.Search;

    /// <summary>
    /// Represents a request for a CustomerSearch data set
    ///</summary>
    class CustomerSearchRequestModel : ICustomerSearchRequest
    {

        public int Username { get;set; }
        
        public int  Password { get;set; }
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
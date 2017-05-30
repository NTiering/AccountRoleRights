namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerSearch data set
    ///</summary>
    class CustomerSearchRequestModel : ICustomerSearchContracts
    {

        public int Username { get;set; }
        public int  Password { get;set; }        public string SearchFilter { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
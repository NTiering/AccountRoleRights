namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerUsernameSearch data set
    ///</summary>
    class CustomerUsernameSearchRequestModel : ICustomerUsernameSearchContracts
    {

        public int Username { get;set; }        public string SearchFilter { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
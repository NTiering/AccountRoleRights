namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerSearch data set
    ///</summary>
    public interface ICustomerSearchRequest
    {

        int Username { get;set; }
        int  Password { get;set; }        string SearchFilter { get; set; }
        int PageSize { get; set; }
        int PageCount { get; set; }
    }
}
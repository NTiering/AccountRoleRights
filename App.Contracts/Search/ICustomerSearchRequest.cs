namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerSearch data set
    ///</summary>
    public interface ICustomerSearchRequest
    {

        int Username { get; }
        int  Password { get; }        string SearchFilter { get; }
        int PageSize { get; }
        int PageCount { get; }
    }
}
namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerUsernameSearch data set
    ///</summary>
    public interface ICustomerUsernameSearchRequest
    {

        int Username { get; }        string SearchFilter { get; }
        int PageSize { get; }
        int PageCount { get; }
    }
}
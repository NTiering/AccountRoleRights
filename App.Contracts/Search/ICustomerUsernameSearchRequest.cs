namespace App.Contracts.Search
{
    /// <summary>
    /// Represents a request for a CustomerUsernameSearch data set
    ///</summary>
    public interface ICustomerUsernameSearchContracts
    {

        int Username { get;set; }        string SearchFilter { get; set; }
        int PageSize { get; set; }
        int PageCount { get; set; }
    }
}
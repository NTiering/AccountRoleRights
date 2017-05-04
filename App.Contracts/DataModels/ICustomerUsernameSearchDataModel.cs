namespace App.Contracts.DataModels
{
    /// <summary>
    /// Represents a single CustomerUsernameSearch Search Result
    ///</summary>
    public interface ICustomerUsernameSearchDataModel
    {   
        /// <summary>
        /// The CustomerUsernameSearch parameter
        ///</summary>
        int Username { get;set; }
    }
}
namespace App.Contracts.DataModels
{
    /// <summary>
    /// Represents a single CustomerSearch Search Result
    ///</summary>
    public interface ICustomerSearchDataModel
    {   
        /// <summary>
        /// The CustomerSearch parameter
        ///</summary>
        int Username { get;set; }
        /// <summary>
        /// The CustomerSearch parameter
        ///</summary>
        int  Password { get;set; }
    }
}
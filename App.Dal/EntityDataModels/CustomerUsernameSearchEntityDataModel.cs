namespace App.Dal.EntityDataModels
{
    using Contracts.DataModels;

    /// <summary>
    /// Represents a single CustomerUsernameSearch Search Result
    ///</summary>
    class CustomerUsernameSearchEntityDataModel : ICustomerUsernameSearchDataModel
    {   
        /// <summary>
        /// The CustomerUsernameSearch Username parameter
        ///</summary>
        public int Username { get;set; }
    }
}
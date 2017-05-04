namespace App.Dal.EntityDataModels
{
    using Contracts.DataModels;

    /// <summary>
    /// Represents a single CustomerSearch Search Result
    ///</summary>
    class CustomerSearchEntityDataModel : ICustomerSearchDataModel
    {   
        /// <summary>
        /// The CustomerSearch Username parameter
        ///</summary>
        public int Username { get;set; }
        /// <summary>
        /// The CustomerSearch  Password parameter
        ///</summary>
        public int  Password { get;set; }
    }
}
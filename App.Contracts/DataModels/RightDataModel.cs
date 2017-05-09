namespace App.Contracts.DataModels
{   
    using App.Contracts.Models;
    using System;

    /// <summary>
    /// A single action an end user can perform
    /// </summary>
    public class RightDataModel :  IRightDataModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is unknown to the data access layer (DAL).
        /// </summary>
        public bool IsNew
        {
            get
            {
                return (Id == 0);
            }
        }

        

        /// <summary>
        /// Gets or sets the Name.
        /// (Human readable name)
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Gets or sets the Key.
        /// (Unique string the application can check against)
        /// </summary>
        public string Key { get; set; } 

        /// <summary>
        /// Gets or sets the IsAssignable.
        /// (If true the right can be assigned to a role)
        /// </summary>
        public bool IsAssignable { get; set; } 
    }
}
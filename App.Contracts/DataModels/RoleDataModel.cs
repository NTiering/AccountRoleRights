namespace App.Contracts.DataModels
{   
    using App.Contracts.Models;
	using System;

	/// <summary>
    /// Represents a collection of common rights
    /// </summary>
    public class RoleDataModel :  IRoleDataModel
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
		/// (If true the right can be assigned to an account)
		/// </summary>
		public bool IsAssignable { get; set; } 
    }
}
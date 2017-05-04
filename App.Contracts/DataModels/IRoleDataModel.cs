namespace App.Contracts.DataModels
{   
    using Models;
    using System;

	/// <summary>
    /// Represents a collection of common rights
    /// </summary>
    public interface IRoleDataModel : IDataModel
    {
		

		/// <summary>
        /// Gets or sets the Name.
		/// (Human readable name)
		/// </summary>
		string Name { get; set; } 

		/// <summary>
        /// Gets or sets the Key.
		/// (Unique string the application can check against)
		/// </summary>
		string Key { get; set; } 

		/// <summary>
        /// Gets or sets the IsAssignable.
		/// (If true the right can be assigned to an account)
		/// </summary>
		bool IsAssignable { get; set; } 
    }
}
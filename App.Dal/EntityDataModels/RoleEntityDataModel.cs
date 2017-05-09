namespace App.Dal.EntityDataModels
{   
    using App.Dal;
    using App.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts.DataModels;

    /// <summary>
    /// Represents a collection of common rights
    /// </summary>
    class RoleEntityDataModel : IRoleDataModel
    {
        /// <summary>
        /// Create a new item with default properties (state) 
        /// </summary>
        public RoleEntityDataModel()
        {

        }

        /// <summary>
        /// Create a new item with the properties (state) of an existing IRoleDataModel
        /// </summary>
        public RoleEntityDataModel(IRoleDataModel model)
        {
            // copy state over 
            Name = model.Name ;
                        Key = model.Key ;
                        IsAssignable = model.IsAssignable ;
                    }

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
        /// Primary Id
        /// </summary>
        public int Id { get; set; } 

        

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
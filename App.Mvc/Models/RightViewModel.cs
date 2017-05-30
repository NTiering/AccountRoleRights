namespace App.Mvc.Models
{   
    using Contracts.DataModels;
    using System;
    
    /// <summary>
    /// A single action an end user can perform
    /// </summary>
    public class RightViewModel : IRightDataModel
    {
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
        /// (If true the right can be assigned to a role)
        /// </summary>
        public bool IsAssignable { get; set; } 

        
        /// <summary>
        /// Gets or sets the RightId for RoleRight.
        /// </summary>
        public int RoleRightId { get; set; }          
        


        /// <summary>
        /// Gets or sets the Name.
        /// (Human readable name)
        /// </summary>
        public string NameId { get; set; } 

        /// <summary>
        /// Gets or sets the Key.
        /// (Unique string the application can check against)
        /// </summary>
        public string KeyId { get; set; } 

        /// <summary>
        /// Gets or sets the IsAssignable.
        /// (If true the right can be assigned to a role)
        /// </summary>
        public bool IsAssignableId { get; set; } 

        /// <summary>
        /// Create a new item with default properties (state) 
        /// </summary>
        public RightViewModel()
        {
            // set initial state 
        }
        
        /// <summary>
        /// Create a new item with the properties (state) of an existing IRightDataModel
        /// </summary>
        public void Load(IRightDataModel model)
        {
            if(model == null) return ; 
            // copy state from incomming model
            Id = model.Id ;

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
    }
}
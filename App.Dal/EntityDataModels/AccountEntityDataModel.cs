namespace App.Dal.EntityDataModels
{   
    using App.Dal;
    using App.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts.DataModels;

    /// <summary>
    /// Represents a validated end user
    /// </summary>
    class AccountEntityDataModel : IAccountDataModel
    {
        /// <summary>
        /// Create a new item with default properties (state) 
        /// </summary>
        public AccountEntityDataModel()
        {

        }

        /// <summary>
        /// Create a new item with the properties (state) of an existing IAccountDataModel
        /// </summary>
        public AccountEntityDataModel(IAccountDataModel model)
        {
            // copy state over 
            Username = model.Username ;
                        Password = model.Password ;
                        LastLoggedIn = model.LastLoggedIn.Or(System.Data.SqlTypes.SqlDateTime.MinValue.Value) ;
                        LoginAttempts = model.LoginAttempts ;
                        IsLockedOut = model.IsLockedOut ;
                        AccountValidFrom = model.AccountValidFrom.Or(System.Data.SqlTypes.SqlDateTime.MinValue.Value) ;
                        AccountValidTo = model.AccountValidTo.Or(System.Data.SqlTypes.SqlDateTime.MinValue.Value) ;
                        LoginStartAt = model.LoginStartAt ;
                        LoginUntil = model.LoginUntil ;
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
        /// Gets or sets the Username.
        /// (Unique user Id)
        /// </summary>
        public string Username { get; set; } 

        /// <summary>
        /// Gets or sets the Password.
        /// (One way encrypted password)
        /// </summary>
        public string Password { get; set; } 

        /// <summary>
        /// Gets or sets the LastLoggedIn.
        /// (Last time someone successfully logged in with this account)
        /// </summary>
        public DateTime LastLoggedIn { get; set; } 

        /// <summary>
        /// Gets or sets the LoginAttempts.
        /// (Count of unsuccessful login attempts against this account)
        /// </summary>
        public int LoginAttempts { get; set; } 

        /// <summary>
        /// Gets or sets the IsLockedOut.
        /// (If true this account cannot be used until unlocked)
        /// </summary>
        public bool IsLockedOut { get; set; } 

        /// <summary>
        /// Gets or sets the AccountValidFrom.
        /// (The date the account can be used from)
        /// </summary>
        public DateTime AccountValidFrom { get; set; } 

        /// <summary>
        /// Gets or sets the AccountValidTo.
        /// (The date the account can be used to)
        /// </summary>
        public DateTime AccountValidTo { get; set; } 

        /// <summary>
        /// Gets or sets the LoginStartAt.
        /// (The earliest time login can be validated)
        /// </summary>
        public string LoginStartAt { get; set; } 

        /// <summary>
        /// Gets or sets the LoginUntil.
        /// (The latest time login can be validated)
        /// </summary>
        public string LoginUntil { get; set; } 
    }
}
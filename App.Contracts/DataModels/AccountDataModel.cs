namespace App.Contracts.DataModels
{   
    using App.Contracts.Models;
    using System;

    /// <summary>
    /// Represents a validated end user
    /// </summary>
    public class AccountDataModel :  IAccountDataModel
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
namespace App.Contracts.DataModels
{   
    using Models;
    using System;

    /// <summary>
    /// Represents a validated end user
    /// </summary>
    public interface IAccountDataModel : IDataModel
    {

        /// <summary>
        /// Gets or sets the Username.
        /// (Unique user Id)
        /// </summary>
        string Username { get; set; } 

        /// <summary>
        /// Gets or sets the Password.
        /// (One way encrypted password)
        /// </summary>
        string Password { get; set; } 

        /// <summary>
        /// Gets or sets the LastLoggedIn.
        /// (Last time someone successfully logged in with this account)
        /// </summary>
        DateTime LastLoggedIn { get; set; } 

        /// <summary>
        /// Gets or sets the LoginAttempts.
        /// (Count of unsuccessful login attempts against this account)
        /// </summary>
        int LoginAttempts { get; set; } 

        /// <summary>
        /// Gets or sets the IsLockedOut.
        /// (If true this account cannot be used until unlocked)
        /// </summary>
        bool IsLockedOut { get; set; } 

        /// <summary>
        /// Gets or sets the AccountValidFrom.
        /// (The date the account can be used from)
        /// </summary>
        DateTime AccountValidFrom { get; set; } 

        /// <summary>
        /// Gets or sets the AccountValidTo.
        /// (The date the account can be used to)
        /// </summary>
        DateTime AccountValidTo { get; set; } 

        /// <summary>
        /// Gets or sets the LoginStartAt.
        /// (The earliest time login can be validated)
        /// </summary>
        string LoginStartAt { get; set; } 

        /// <summary>
        /// Gets or sets the LoginUntil.
        /// (The latest time login can be validated)
        /// </summary>
        string LoginUntil { get; set; } 
    }
}
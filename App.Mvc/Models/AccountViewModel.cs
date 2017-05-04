namespace App.Mvc.Models
{   
    using Contracts.DataModels;
    using System;
    
	/// <summary>
    /// Represents a validated end user
    /// </summary>
    public class AccountViewModel : IAccountDataModel
    {
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
        /// Gets or sets the AccountId for AccountRole.
		/// </summary>
		public int AccountRoleId { get; set; }  		


		/// <summary>
        /// Gets or sets the Username.
		/// (Unique user Id)
		/// </summary>
		public string UsernameId { get; set; } 

		/// <summary>
        /// Gets or sets the Password.
		/// (One way encrypted password)
		/// </summary>
		public string PasswordId { get; set; } 

		/// <summary>
        /// Gets or sets the LastLoggedIn.
		/// (Last time someone successfully logged in with this account)
		/// </summary>
		public DateTime LastLoggedInId { get; set; } 

		/// <summary>
        /// Gets or sets the LoginAttempts.
		/// (Count of unsuccessful login attempts against this account)
		/// </summary>
		public int LoginAttemptsId { get; set; } 

		/// <summary>
        /// Gets or sets the IsLockedOut.
		/// (If true this account cannot be used until unlocked)
		/// </summary>
		public bool IsLockedOutId { get; set; } 

		/// <summary>
        /// Gets or sets the AccountValidFrom.
		/// (The date the account can be used from)
		/// </summary>
		public DateTime AccountValidFromId { get; set; } 

		/// <summary>
        /// Gets or sets the AccountValidTo.
		/// (The date the account can be used to)
		/// </summary>
		public DateTime AccountValidToId { get; set; } 

		/// <summary>
		/// Create a new item with default properties (state) 
		/// </summary>
		public AccountViewModel()
        {
			// set initial state 
			LastLoggedIn = DateTime.Now ;
						AccountValidFrom = DateTime.Now ;
						AccountValidTo = DateTime.Now ;
			        }
		
		/// <summary>
		/// Create a new item with the properties (state) of an existing IAccountDataModel
		/// </summary>
        public void Load(IAccountDataModel model)
        {
			if(model == null) return ; 
			// copy state from incomming model
			Id = model.Id ;

			Username = model.Username ;
			Password = model.Password ;
			LastLoggedIn = model.LastLoggedIn ;
			LoginAttempts = model.LoginAttempts ;
			IsLockedOut = model.IsLockedOut ;
			AccountValidFrom = model.AccountValidFrom ;
			AccountValidTo = model.AccountValidTo ;
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
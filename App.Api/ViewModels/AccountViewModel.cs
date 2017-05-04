namespace App.Api.ViewModels
{
	using App.Contracts.DataModels;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Web;

    public static class AccountDataModelExt
    {
        public static AccountViewModel ToViewModel(this IAccountDataModel dataModel)
        {
            var vm = new AccountViewModel
            {
                Id = dataModel.Id 

				,Username = dataModel.Username // (Unique user Id)
				,Password = dataModel.Password // (One way encrypted password)
				,LastLoggedIn = dataModel.LastLoggedIn // (Last time someone successfully logged in with this account)
				,LoginAttempts = dataModel.LoginAttempts // (Count of unsuccessful login attempts against this account)
				,IsLockedOut = dataModel.IsLockedOut // (If true this account cannot be used until unlocked)
				,AccountValidFrom = dataModel.AccountValidFrom // (The date the account can be used from)
				,AccountValidTo = dataModel.AccountValidTo // (The date the account can be used to)
            };

            return vm;
        }
    }

    [DataContract]
    public class AccountViewModel : IAccountDataModel
    { 
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [DataMember]
        public int Id { get; set; }


		/// <summary>
        /// Gets or sets the Username.
		/// (Unique user Id)
		/// </summary>
		[DataMember]
        public string Username { get; set; } 

		/// <summary>
        /// Gets or sets the Password.
		/// (One way encrypted password)
		/// </summary>
		[DataMember]
        public string Password { get; set; } 

		/// <summary>
        /// Gets or sets the LastLoggedIn.
		/// (Last time someone successfully logged in with this account)
		/// </summary>
		[DataMember]
        public DateTime LastLoggedIn { get; set; } 

		/// <summary>
        /// Gets or sets the LoginAttempts.
		/// (Count of unsuccessful login attempts against this account)
		/// </summary>
		[DataMember]
        public int LoginAttempts { get; set; } 

		/// <summary>
        /// Gets or sets the IsLockedOut.
		/// (If true this account cannot be used until unlocked)
		/// </summary>
		[DataMember]
        public bool IsLockedOut { get; set; } 

		/// <summary>
        /// Gets or sets the AccountValidFrom.
		/// (The date the account can be used from)
		/// </summary>
		[DataMember]
        public DateTime AccountValidFrom { get; set; } 

		/// <summary>
        /// Gets or sets the AccountValidTo.
		/// (The date the account can be used to)
		/// </summary>
		[DataMember]
        public DateTime AccountValidTo { get; set; } 

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
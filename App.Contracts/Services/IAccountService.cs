namespace  App.Contracts.Services
{
    using Contracts;
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Service to provvide atomic opertaion for a Account data object
    /// </summary>
    public interface IAccountService : IService<IAccountDataModel>
    {    

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IQueryable<IAccountDataModel> GetAccountRole(int roleId, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        bool TryAddAccountRole(int accountId, int roleId,  List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        bool TryRemoveAccountRole(int accountId, int roleId,  List<IModelError> errors, IModelContext context = null);
        
        

        /// <summary>
        /// Returns true if the model exists and the values supplied matches a hashed version of Password
        /// </summary>
        bool MatchesPassword(int id , string password, List<IModelError> errors, IModelContext context = null);
        
        

    }
}
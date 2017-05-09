namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IAccountDal : IDal<IAccountDataModel>
    {

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IQueryable<IAccountDataModel> GetAccountRole(int roleId, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void AddAccountRole(int accountId, int roleId, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void RemoveAccountRole(int accountId, int roleId, IModelContext context = null);
            

    }
}
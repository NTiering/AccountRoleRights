namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IRoleDal : IDal<IRoleDataModel>
    {
    
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IQueryable<IRoleDataModel> GetAccountRole(int accountId, IModelContext context = null);
        
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void AddAccountRole(int roleId, int accountId, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void RemoveAccountRole(int roleId, int accountId, IModelContext context = null);
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IQueryable<IRoleDataModel> GetRoleRight(int rightId, IModelContext context = null);
        
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void AddRoleRight(int roleId, int rightId, IModelContext context = null);

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        void RemoveRoleRight(int roleId, int rightId, IModelContext context = null);

    }
}
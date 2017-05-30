namespace App.Dal
{
    using Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using Contracts.Dals;
    using DataModels;
    using EntityDataModels;
    
    class RoleDal : IDal<IRoleDataModel>, IRoleDal
    {        
        /// <summary> 
        /// Create a new Role
        /// </summary>
        public void Create(IRoleDataModel item, IModelContext context)
        {            
            var ctx = new AppContext();
            var dataEntity = new RoleEntityDataModel(item);
            ctx.Role.Add(dataEntity);
            ctx.SaveChanges();
            item.Id = dataEntity.Id;    
        }
        
        /// <summary> 
        /// Delete an existing Role
        /// </summary>
        public void Delete(int id, IModelContext context)
        {
            var ctx = new AppContext();
            var itemToRemove = ctx.Role.SingleOrDefault(x => x.Id == id); 

            if (itemToRemove != null)
            {
                ctx.Role.Remove(itemToRemove);
				ctx.AccountRole.RemoveRange(ctx.AccountRole.Where(x => x.RoleId == id)); // Remove any AccountRole relationships 


				ctx.SaveChanges();
            }   
        }
        
        /// <summary> 
        /// Find a single Role
        /// </summary>
        public IRoleDataModel Get(Func<IRoleDataModel, bool> filter, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Role.FirstOrDefault(filter);
             return rtn;
        }
        
        /// <summary> 
        /// Find a single Role
        /// </summary>
        public IRoleDataModel Get(int id, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Role.FirstOrDefault(x=>x.Id == id);
             return rtn;
        }
        
        /// <summary> 
        /// Find zero or more Role
        /// </summary>
        public IQueryable<IRoleDataModel> GetAll(Func<IRoleDataModel, bool> filter, IModelContext context)
        {
            var ctx = new AppContext();
            var rtn = ctx.Role.Where(filter).AsQueryable();
            return rtn;
        }

        /// <summary> 
        /// Update a Role
        /// </summary>
        public void Update(IRoleDataModel item, IModelContext context)
        {
            var ctx = new AppContext();
            var entity = ctx.Role.FirstOrDefault(x=> x.Id == item.Id);
            if (entity == null)
            {
                return;
            }
            ctx.Entry(entity).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }    

		
		#region 'RoleRight'
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		public IQueryable<IRoleDataModel> GetAllRoleByRightForRoleRight(int rightId, IModelContext context)
		{
			var ctx = new AppContext();
            var rtn = ctx.Role.Where(x => x.RoleRightId == rightId);
			return rtn;
		} 

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        public void AddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context)
		{
			var ctx = new AppContext();
            var item = ctx.Role.Find(roleId);
            if (item == null) return;
            item.RoleRightId = rightId;
            ctx.SaveChanges();
		} 

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        public void RemoveRoleFromRightForRoleRight(int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var item = ctx.Role.Find(roleId);
            if (item == null) return;
            item.RoleRightId = -1;
            ctx.SaveChanges();
		} 
		#endregion 
		
		
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public void AddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{
			var ctx = new AppContext();
            var existing = ctx.AccountRole.Any(x=> x.RoleId == roleId && x.AccountId == accountId);
            if (existing) return;
            ctx.AccountRole.Add(new AccountRoleRelationshipModel{RoleId = roleId, AccountId = accountId});
            ctx.SaveChanges();
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public void RemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{
			var ctx = new AppContext();
            var existing = ctx.AccountRole.FirstOrDefault(x=> x.RoleId == roleId && x.AccountId == accountId);
            if (existing == null) return;
            ctx.AccountRole.Remove(existing);
            ctx.SaveChanges();
		}

		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		public IQueryable<IRoleDataModel> GetAllForAccountRole(int accountId, IModelContext context)
		{
			var ctx = new AppContext();
			var result = (from main in ctx.Role
						join link in ctx.AccountRole on main.Id equals link.RoleId
						where (link.AccountId == accountId)
						select main);
			return result;
		}
		#endregion 		
		    }
}
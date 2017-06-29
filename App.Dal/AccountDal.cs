namespace App.Dal
{
    using Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using Contracts.Dals;
    using DataModels;
    using EntityDataModels;
    
    class AccountDal : IDal<IAccountDataModel>, IAccountDal
    {        
        /// <summary> 
        /// Create a new Account
        /// </summary>
        public void Create(IAccountDataModel item, IModelContext context)
        {            
            var ctx = new AppContext();
            var dataEntity = new AccountEntityDataModel(item);
            ctx.Account.Add(dataEntity);
            ctx.SaveChanges();
            item.Id = dataEntity.Id;    
        }
        
        /// <summary> 
        /// Update a Account
        /// </summary>
        public void Update(IAccountDataModel item, IModelContext context)
        {
            var ctx = new AppContext();
            var entity = ctx.Account.FirstOrDefault(x=> x.Id == item.Id);
            if (entity == null)
            {
                return;
            }
            
			ctx.Entry(entity).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }  

        /// <summary> 
        /// Delete an existing Account
        /// </summary>
        public void Delete(int id, IModelContext context)
        {
            var ctx = new AppContext();
            var itemToRemove = ctx.Account.SingleOrDefault(x => x.Id == id); 

            if (itemToRemove != null)
            {
                ctx.Account.Remove(itemToRemove);
				ctx.AccountRole.RemoveRange(ctx.AccountRole.Where(x => x.AccountId == id)); // Remove any AccountRole relationships 


				ctx.SaveChanges();
            }   
        }
        
        /// <summary> 
        /// Find a single Account
        /// </summary>
        public IAccountDataModel Get(Func<IAccountDataModel, bool> filter, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Account.FirstOrDefault(filter);
             return rtn;
        }
        
        /// <summary> 
        /// Find a single Account
        /// </summary>
        public IAccountDataModel Get(int id, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Account.FirstOrDefault(x=>x.Id == id);
             return rtn;
        }
        
        /// <summary> 
        /// Find zero or more Account
        /// </summary>
        public IQueryable<IAccountDataModel> GetAll(Func<IAccountDataModel, bool> filter, IModelContext context)
        {
            var ctx = new AppContext();
            var rtn = ctx.Account.Where(filter).AsQueryable();
            return rtn;
        }


	
		#region 'AccountRole'		
		// add child to parent ( Role Account )
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public void AddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context)
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
		public void RemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context)
		{
			var ctx = new AppContext();
            var existing = ctx.AccountRole.FirstOrDefault(x=> x.RoleId == roleId && x.AccountId == accountId);
            if (existing == null) return;
            ctx.AccountRole.Remove(existing);
            ctx.SaveChanges();
		}

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		public IQueryable<IAccountDataModel> GetAllForAccountRole(int roleId, IModelContext context)
		{
			var ctx = new AppContext();
			var result = (from main in ctx.Account
						join link in ctx.AccountRole on main.Id equals link.AccountId
						where (link.RoleId == roleId)
						select main);
			return result;
		}
		#endregion 		
		    }
}
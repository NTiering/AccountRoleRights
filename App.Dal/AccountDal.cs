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
        /// Delete an existing Account
        /// </summary>
        public void Delete(int id, IModelContext context)
        {
            var ctx = new AppContext();
            var itemToRemove = ctx.Account.SingleOrDefault(x => x.Id == id); 

            if (itemToRemove != null)
            {
                ctx.Account.Remove(itemToRemove);
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
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public IQueryable<IAccountDataModel> GetAccountRole(int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var result = (from main in ctx.Account
                          join link in ctx.AccountRole on main.Id equals link.AccountId
						  where (link.RoleId == roleId)
                          select main);
            return result;
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void AddAccountRole(int accountId, int roleId, IModelContext context)
		{
			var ctx = new AppContext();
			var model = new AccountRoleRelationshipModel{ AccountId = accountId , RoleId = roleId };
			
			if(ctx.AccountRole.Any(x=> x.AccountId == accountId && x.RoleId == roleId )) return ;
			
			ctx.AccountRole.Add(model);
			ctx.SaveChanges();
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void RemoveAccountRole(int accountId, int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var model = ctx.AccountRole.FirstOrDefault(x => x.AccountId == accountId && x.RoleId == roleId);
            if (model == null) return;
            ctx.AccountRole.Remove(model);
            ctx.SaveChanges();   
		}
			

    }
}
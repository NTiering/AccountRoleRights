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

	
		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public IQueryable<IRoleDataModel> GetAccountRole(int accountId, IModelContext context)
		{
			var ctx = new AppContext();//2
            var result = (from main in ctx.Role
                          join link in ctx.AccountRole on main.Id equals link.RoleId
                          join outer in ctx.Account on link.AccountId equals outer.Id
						  where outer.Id == accountId
                          select main);
            return result;
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void AddAccountRole(int roleId, int accountId, IModelContext context)
		{
			var ctx = new AppContext();
			var model = new AccountRoleRelationshipModel{ RoleId = roleId , AccountId = accountId };
			ctx.AccountRole.Add(model);
			ctx.SaveChanges();
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void RemoveAccountRole(int roleId, int accountId, IModelContext context)
		{
			var ctx = new AppContext();
            var model = ctx.AccountRole.FirstOrDefault(x => x.RoleId == roleId && x.AccountId == accountId);
            if (model == null) return;
            ctx.AccountRole.Remove(model);
            ctx.SaveChanges();   
		}
		
		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public IQueryable<IRoleDataModel> GetRoleRight(int rightId, IModelContext context)
		{
			var ctx = new AppContext();//2
            var result = (from main in ctx.Role
                          join link in ctx.RoleRight on main.Id equals link.RoleId
                          join outer in ctx.Right on link.RightId equals outer.Id
						  where outer.Id == rightId
                          select main);
            return result;
		}

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void AddRoleRight(int roleId, int rightId, IModelContext context)
		{
			var ctx = new AppContext();
			var model = new RoleRightRelationshipModel{ RoleId = roleId , RightId = rightId };
			ctx.RoleRight.Add(model);
			ctx.SaveChanges();
		}

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
		public void RemoveRoleRight(int roleId, int rightId, IModelContext context)
		{
			var ctx = new AppContext();
            var model = ctx.RoleRight.FirstOrDefault(x => x.RoleId == roleId && x.RightId == rightId);
            if (model == null) return;
            ctx.RoleRight.Remove(model);
            ctx.SaveChanges();   
		}
		

    }
}
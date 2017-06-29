namespace App.Dal
{
    using Contracts;
    using Contracts.DataModels;
    using System;
    using System.Linq;
    using Contracts.Dals;
    using DataModels;
    using EntityDataModels;
    
    class RightDal : IDal<IRightDataModel>, IRightDal
    {        
        /// <summary> 
        /// Create a new Right
        /// </summary>
        public void Create(IRightDataModel item, IModelContext context)
        {            
            var ctx = new AppContext();
            var dataEntity = new RightEntityDataModel(item);
            ctx.Right.Add(dataEntity);
            ctx.SaveChanges();
            item.Id = dataEntity.Id;    
        }
        
        /// <summary> 
        /// Update a Right
        /// </summary>
        public void Update(IRightDataModel item, IModelContext context)
        {
            var ctx = new AppContext();
            var entity = ctx.Right.FirstOrDefault(x=> x.Id == item.Id);
            if (entity == null)
            {
                return;
            }
            
			ctx.Entry(entity).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }  

        /// <summary> 
        /// Delete an existing Right
        /// </summary>
        public void Delete(int id, IModelContext context)
        {
            var ctx = new AppContext();
            var itemToRemove = ctx.Right.SingleOrDefault(x => x.Id == id); 

            if (itemToRemove != null)
            {
                ctx.Right.Remove(itemToRemove);

				ctx.Role.Where(x=>x.RoleRightId == id).ToList().ForEach(x=>x.RoleRightId = -1) ;// unset any RoleRight relationships 

				ctx.SaveChanges();
            }   
        }
        
        /// <summary> 
        /// Find a single Right
        /// </summary>
        public IRightDataModel Get(Func<IRightDataModel, bool> filter, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Right.FirstOrDefault(filter);
             return rtn;
        }
        
        /// <summary> 
        /// Find a single Right
        /// </summary>
        public IRightDataModel Get(int id, IModelContext context)
        {
             var ctx = new AppContext();
             var rtn = ctx.Right.FirstOrDefault(x=>x.Id == id);
             return rtn;
        }
        
        /// <summary> 
        /// Find zero or more Right
        /// </summary>
        public IQueryable<IRightDataModel> GetAll(Func<IRightDataModel, bool> filter, IModelContext context)
        {
            var ctx = new AppContext();
            var rtn = ctx.Right.Where(filter).AsQueryable();
            return rtn;
        }

		
		#region 'RoleRight'        
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        public IRightDataModel GetSingleRightByRoleForRoleRight(int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var item = ctx.Role.Find(roleId);
			if(item == null) return null;
			var rtn = ctx.Right.Find(item.RoleRightId);
			return rtn;
		} 

		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        public void AddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var item = ctx.Role.Find(roleId);
            if (item == null) return;
            item.RoleRightId = rightId;
            ctx.SaveChanges();
		}   

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		public void RemoveRightFromRoleForRoleRight(int roleId, IModelContext context)
		{
			var ctx = new AppContext();
            var item = ctx.Role.Find(roleId);
            if (item == null) return;
            item.RoleRightId = -1;
            ctx.SaveChanges();
		}  

		#endregion 
		
    }
}
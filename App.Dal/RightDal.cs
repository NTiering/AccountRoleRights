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
        /// Delete an existing Right
        /// </summary>
        public void Delete(int id, IModelContext context)
        {
            var ctx = new AppContext();
            var itemToRemove = ctx.Right.SingleOrDefault(x => x.Id == id); 

            if (itemToRemove != null)
            {
                ctx.Right.Remove(itemToRemove);
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
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public IQueryable<IRightDataModel> GetRoleRight(int roleId, IModelContext context)
        {
            var ctx = new AppContext();
            var result = (from main in ctx.Right
                          join link in ctx.RoleRight on main.Id equals link.RightId
                          where (link.RoleId == roleId)
                          select main);
            return result;
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public void AddRoleRight(int rightId, int roleId, IModelContext context)
        {
            var ctx = new AppContext();
            var model = new RoleRightRelationshipModel{ RightId = rightId , RoleId = roleId };
            
            if(ctx.RoleRight.Any(x=> x.RightId == rightId && x.RoleId == roleId )) return ;
            
            ctx.RoleRight.Add(model);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public void RemoveRoleRight(int rightId, int roleId, IModelContext context)
        {
            var ctx = new AppContext();
            var model = ctx.RoleRight.FirstOrDefault(x => x.RightId == rightId && x.RoleId == roleId);
            if (model == null) return;
            ctx.RoleRight.Remove(model);
            ctx.SaveChanges();   
        }
            

    }
}
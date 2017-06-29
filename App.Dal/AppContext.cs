namespace App.Dal
{
    using Contracts.DataModels;
    using DataModels;
    using EntityDataModels;
    using System.Data.Entity;

    class AppContext : DbContext
    {
        static AppContext()
        {
            // only use for debug instances // do not deploy debug to a live enviroment
#if DEBUG
            Database.SetInitializer<AppContext>(new DropCreateDatabaseIfModelChanges<AppContext>());
#endif
        }

        public AppContext()  : base("App")
        {

        }

        /// <summary>
        /// Represents a validated end user
        /// </summary>        
        public DbSet<AccountEntityDataModel> Account { get; set; } 

        /// <summary>
        /// A single action an end user can perform
        /// </summary>        
        public DbSet<RightEntityDataModel> Right { get; set; } 

        /// <summary>
        /// Represents a collection of common rights
        /// </summary>        
        public DbSet<RoleEntityDataModel> Role { get; set; } 
        
        /// <summary>
        /// Used internally to manage relationships between Account and Role for AccountRole searches.
        /// </summary>        
        public DbSet<AccountRoleRelationshipModel> AccountRole { get; set; } 

    }

}
namespace App.Dal
{
    using Contracts.Dals;
    using Contracts.DataModels;
    using Contracts;
    using Dals;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {
			// register all types to be used outside of the project here
			registerClient.Register(typeof(IStartupDal), typeof(StartupDal));  
			registerClient.Register(typeof(ISearchDal), typeof(SearchDal));  
			          
			registerClient.Register(typeof(IDal<AccountDataModel>), typeof(AccountDal));	
			registerClient.Register(typeof(IAccountDal), typeof(AccountDal));	
			registerClient.Register(typeof(IDal<RoleDataModel>), typeof(RoleDal));	
			registerClient.Register(typeof(IRoleDal), typeof(RoleDal));	
			registerClient.Register(typeof(IDal<RightDataModel>), typeof(RightDal));	
			registerClient.Register(typeof(IRightDal), typeof(RightDal));	
        }
    }
}
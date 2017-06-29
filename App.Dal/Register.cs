namespace App.Dal
{
    using Contracts.Dals;
    using Contracts.DataModels;
    using Contracts;
    using Dals;
    using Store;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {
            // register all types to be used inside of the project here
            registerClient.Register(typeof(IFileStore), typeof(FileSystemFileStore));

            // register all types to be used outside of the project here
            registerClient.Register(typeof(IStartupDal), typeof(StartupDal));  
            registerClient.Register(typeof(ISearchDal), typeof(SearchDal));  
                      
            registerClient.Register(typeof(IDal<IAccountDataModel>), typeof(AccountDal));    
            registerClient.Register(typeof(IAccountDal), typeof(AccountDal));    
            registerClient.Register(typeof(IDal<IRightDataModel>), typeof(RightDal));    
            registerClient.Register(typeof(IRightDal), typeof(RightDal));    
            registerClient.Register(typeof(IDal<IRoleDataModel>), typeof(RoleDal));    
            registerClient.Register(typeof(IRoleDal), typeof(RoleDal));    
        }
    }
}
namespace App.Services
{
    using Interfaces;
    using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Encryption;
    using Validators;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {    
            // register all types to be used outside of the project here
            registerClient.Register(typeof(IStartupService), typeof(StartupService));
            registerClient.Register(typeof(ISearchService), typeof(SearchService));
            registerClient.Register(typeof(IService<AccountDataModel>), typeof(AccountService));    
            registerClient.Register(typeof(IAccountService), typeof(AccountService));    
            registerClient.Register(typeof(IService<RoleDataModel>), typeof(RoleService));    
            registerClient.Register(typeof(IRoleService), typeof(RoleService));    
            registerClient.Register(typeof(IService<RightDataModel>), typeof(RightService));    
            registerClient.Register(typeof(IRightService), typeof(RightService));    
                        
            // register all validators only be used internally to this project
            registerClient.Register(typeof(IValidator<IAccountDataModel>), typeof(AccountValidator));
            registerClient.Register(typeof(IValidator<IRoleDataModel>), typeof(RoleValidator));
            registerClient.Register(typeof(IValidator<IRightDataModel>), typeof(RightValidator));

            // register other tools 
            registerClient.Register(typeof(ICryptoProvider), typeof(CryptoProvider));
           
        }
    }
}
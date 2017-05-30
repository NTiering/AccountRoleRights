namespace App.Services
{
    using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Encryption;
    using Validators;
    using Contracts.ChangeHandlers;
    using ChangeHandlers;
    using Contracts.Validators;


    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {    
            // register all types to be used outside of the project here
            registerClient.Register(typeof(IStartupService), typeof(StartupService));
            registerClient.Register(typeof(ISearchService), typeof(SearchService));
            registerClient.Register(typeof(IAccountService), typeof(AccountService));    
            registerClient.Register(typeof(IRoleService), typeof(RoleService));    
            registerClient.Register(typeof(IRightService), typeof(RightService));    
                        
            // register all validators only be used internally to this project
            registerClient.Register(typeof(IAccountValidator), typeof(AccountValidator));
			registerClient.Register(typeof(IAccountChangeHandler), typeof(AccountChangeHandler));
            registerClient.Register(typeof(IRoleValidator), typeof(RoleValidator));
			registerClient.Register(typeof(IRoleChangeHandler), typeof(RoleChangeHandler));
            registerClient.Register(typeof(IRightValidator), typeof(RightValidator));
			registerClient.Register(typeof(IRightChangeHandler), typeof(RightChangeHandler));

            // register other tools 
            registerClient.Register(typeof(ICryptoProvider), typeof(CryptoProvider));
           
        }
    }
}
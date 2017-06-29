namespace App.Services
{
    using Contracts;
    using Contracts.Services;
    using Encryption;
    using Validators;
    using Contracts.ChangeHandlers;
    using ChangeHandlers;
    using Contracts.Validators;
    using StateMachines;

    public static class Register
    {
        public static void RegisterTypes(IRegisterClient registerClient)
        {    
            // register all services to be used outside of the project here
            registerClient.Register(typeof(IStartupService), typeof(StartupService));
            registerClient.Register(typeof(ISearchService), typeof(SearchService));
            registerClient.Register(typeof(IAccountService), typeof(AccountService));    
            registerClient.Register(typeof(IRightService), typeof(RightService));    
            registerClient.Register(typeof(IRoleService), typeof(RoleService));    
            
			// register all state machines to be used outside of the project here
            registerClient.Register(typeof(IAccountStateMachine), typeof(AccountStateMachine));    
            registerClient.Register(typeof(IRightStateMachine), typeof(RightStateMachine));    
            registerClient.Register(typeof(IRoleStateMachine), typeof(RoleStateMachine));    
			            
            // register all validators only be used internally to this project
            registerClient.Register(typeof(IAccountValidator), typeof(AccountValidator));
			registerClient.Register(typeof(IAccountChangeHandler), typeof(AccountChangeHandler));
            registerClient.Register(typeof(IRightValidator), typeof(RightValidator));
			registerClient.Register(typeof(IRightChangeHandler), typeof(RightChangeHandler));
            registerClient.Register(typeof(IRoleValidator), typeof(RoleValidator));
			registerClient.Register(typeof(IRoleChangeHandler), typeof(RoleChangeHandler));

            // register other tools 
            registerClient.Register(typeof(ICryptoProvider), typeof(CryptoProvider));
			registerClient.Register(typeof(ILogProvider), typeof(LogProvider));
           
        }
    }
}
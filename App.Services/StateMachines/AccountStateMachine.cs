namespace App.Services.StateMachines
{
	using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using StateMachines;
    using System;
    using System.Collections.Generic;

    class AccountStateMachine : BaseAccountStateMachine, IAccountStateMachine
    {
        public AccountStateMachine(IAccountService service):base(service)
        {}

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, AccountTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(IAccountDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, AccountTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, AccountTriggers.Complete, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(IAccountDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, AccountTriggers.Complete, errors, context);
        }

        // Add new methods to represent other states //

        protected override AccountStates ExtractState(IAccountDataModel model)
        {
            // todo : extract a AccountStates to repersent the current model
            throw new NotImplementedException();
        }

        protected override void SetModelState(AccountStates state, IAccountDataModel model)
        {
            // todo : update model properties to reflect the state
            throw new NotImplementedException();
        }
    }
}
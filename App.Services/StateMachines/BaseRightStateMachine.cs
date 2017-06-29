namespace App.Services.StateMachines
{
	using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Stateless;
    using StateMachines;
    using System.Collections.Generic;

    abstract class BaseRightStateMachine
    {
        private IRightService service;

        public BaseRightStateMachine(IRightService service)
        {
            this.service = service; 
        }

        /// <summary>
        /// Tries the state of the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="trigger">The trigger.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected bool TryUpdateItemState(int id, RightTriggers trigger, List<IModelError> errors, IModelContext context = null)
        {
            var item = service.Get(id, errors, context);
            return TryUpdateItemState(item, trigger, errors, context);
        }

        /// <summary>
        /// Tries the state of the item.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="trigger">The trigger.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected bool TryUpdateItemState(IRightDataModel model, RightTriggers trigger, List<IModelError> errors, IModelContext context = null)
        {
            var state = ExtractState(model);
            var stateMachine = GetStateMachine(model);
            if (stateMachine.CanFire(trigger))
            {
                stateMachine.Fire(trigger);
                SetModelState(stateMachine.State, model);
                return service.TrySave(model, errors, context);
            }
            else
            {
                MakeErrorMessage(stateMachine, trigger, errors);
                return false;
            }

        }

        /// <summary>
        /// Constructs an error message and inserts it into to list
        /// </summary>
        protected virtual void MakeErrorMessage(StateMachine<RightStates, RightTriggers> stateMachine, RightTriggers trigger, List<IModelError> errors)
        {
            var errmsg = string.Format(
                                "Cannot set state to {0} at current state of {1}. Legal states are {2}",
                                trigger.ToString(),
                                stateMachine.State.ToString(),
                                string.Join(",", stateMachine.PermittedTriggers));
            errors.Add(new ModelError { Property = "" , ErrorMessage = errmsg });
        }

        /// <summary>
        /// Gets the state machine.
        /// </summary>
        protected virtual StateMachine<RightStates, RightTriggers> GetStateMachine(IRightDataModel model)
        {
            return new StateMachine<RightStates, RightTriggers>(ExtractState(model));
        }

        /// <summary>
        /// Extracts the state.
        /// </summary>
        abstract protected RightStates ExtractState(IRightDataModel model);

        /// <summary>
        /// Sets the state of the model.
        /// </summary>
        abstract protected void SetModelState(RightStates state, IRightDataModel model);
    }
}
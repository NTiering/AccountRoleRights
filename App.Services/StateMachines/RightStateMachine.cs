namespace App.Services.StateMachines
{
	using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using StateMachines;
    using System;
    using System.Collections.Generic;

    class RightStateMachine : BaseRightStateMachine, IRightStateMachine
    {
        public RightStateMachine(IRightService service):base(service)
        {}

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, RightTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(IRightDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, RightTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, RightTriggers.Complete, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(IRightDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, RightTriggers.Complete, errors, context);
        }

        // Add new methods to represent other states //

        protected override RightStates ExtractState(IRightDataModel model)
        {
            // todo : extract a RightStates to repersent the current model
            throw new NotImplementedException();
        }

        protected override void SetModelState(RightStates state, IRightDataModel model)
        {
            // todo : update model properties to reflect the state
            throw new NotImplementedException();
        }
    }
}
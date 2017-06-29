namespace App.Services.StateMachines
{
	using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using StateMachines;
    using System;
    using System.Collections.Generic;

    class RoleStateMachine : BaseRoleStateMachine, IRoleStateMachine
    {
        public RoleStateMachine(IRoleService service):base(service)
        {}

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, RoleTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "start" state.
        /// </summary>
        public bool TrySetStart(IRoleDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, RoleTriggers.Start, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(int id, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(id, RoleTriggers.Complete, errors, context);
        }

        /// <summary>
        /// Tries the set the model to "complete" state.
        /// </summary>
        public bool TrySetComplete(IRoleDataModel model, List<IModelError> errors, IModelContext context = null)
        {
            return TryUpdateItemState(model, RoleTriggers.Complete, errors, context);
        }

        // Add new methods to represent other states //

        protected override RoleStates ExtractState(IRoleDataModel model)
        {
            // todo : extract a RoleStates to repersent the current model
            throw new NotImplementedException();
        }

        protected override void SetModelState(RoleStates state, IRoleDataModel model)
        {
            // todo : update model properties to reflect the state
            throw new NotImplementedException();
        }
    }
}
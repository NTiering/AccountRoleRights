namespace App.Services.StateMachines
{
    using System.Collections.Generic;
    using Contracts;
    using Contracts.DataModels;
    
	public enum RoleStates { Initial , Final } // add other states for Role data models  here

    public enum RoleTriggers { Start, Complete } // add other triggers Role data models here 

    public interface IRoleStateMachine
    {
        /// <summary>
        /// Tries the set complete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TrySetComplete(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries the set complete.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TrySetComplete(IRoleDataModel model, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries the set start.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TrySetStart(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries the set start.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TrySetStart(IRoleDataModel model, List<IModelError> errors, IModelContext context = null);
    }
}
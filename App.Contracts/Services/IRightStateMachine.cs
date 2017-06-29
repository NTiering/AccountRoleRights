namespace App.Services.StateMachines
{
    using System.Collections.Generic;
    using Contracts;
    using Contracts.DataModels;
    
	public enum RightStates { Initial , Final } // add other states for Right data models  here

    public enum RightTriggers { Start, Complete } // add other triggers Right data models here 

    public interface IRightStateMachine
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
        bool TrySetComplete(IRightDataModel model, List<IModelError> errors, IModelContext context = null);

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
        bool TrySetStart(IRightDataModel model, List<IModelError> errors, IModelContext context = null);
    }
}
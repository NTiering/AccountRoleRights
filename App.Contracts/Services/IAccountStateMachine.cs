namespace App.Services.StateMachines
{
    using System.Collections.Generic;
    using Contracts;
    using Contracts.DataModels;
    
	public enum AccountStates { Initial , Final } // add other states for Account data models  here

    public enum AccountTriggers { Start, Complete } // add other triggers Account data models here 

    public interface IAccountStateMachine
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
        bool TrySetComplete(IAccountDataModel model, List<IModelError> errors, IModelContext context = null);

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
        bool TrySetStart(IAccountDataModel model, List<IModelError> errors, IModelContext context = null);
    }
}
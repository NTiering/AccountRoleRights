namespace App.Services.Interfaces
{
    using Contracts;
    using Contracts.Models;

    public interface IOperationAllowed<T>
        where T : IDataModel
    {
        /// <summary>
        /// Returns true if the action is allowed
        /// </summary>
        bool Allowed(Operation action, IModelContext context);
    }
}
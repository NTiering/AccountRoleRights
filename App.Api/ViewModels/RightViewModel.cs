namespace App.Api.ViewModels
{
    using App.Contracts.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    public static class RightDataModelExt
    {
        public static RightViewModel ToViewModel(this IRightDataModel dataModel)
        {
            var vm = new RightViewModel
            {
                Id = dataModel.Id 

                ,Name = dataModel.Name // (Human readable name)
                ,Key = dataModel.Key // (Unique string the application can check against)
                ,IsAssignable = dataModel.IsAssignable // (If true the right can be assigned to a role)
            };

            return vm;
        }
    }

    [DataContract]
    public class RightViewModel : IRightDataModel
    { 
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [DataMember]
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the Name.
        /// (Human readable name)
        /// </summary>
        [DataMember]
        public string Name { get; set; } 

        /// <summary>
        /// Gets or sets the Key.
        /// (Unique string the application can check against)
        /// </summary>
        [DataMember]
        public string Key { get; set; } 

        /// <summary>
        /// Gets or sets the IsAssignable.
        /// (If true the right can be assigned to a role)
        /// </summary>
        [DataMember]
        public bool IsAssignable { get; set; } 

        /// <summary>
        /// Gets a value indicating whether this instance is unknown to the data access layer (DAL).
        /// </summary>
        public bool IsNew
        {
            get
            {
                return (Id == 0);
            }
        }        
    }
}
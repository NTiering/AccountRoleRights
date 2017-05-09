namespace App.Dal.DataModels
{   
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// Used internally to manage relationships between Account and Role for AccountRole searches.
    /// </summary>
    class AccountRoleRelationshipModel 
    {
        /// <summary>
        /// Id for  AccountDataModel.
        /// </summary>
        [Key, Column(Order = 0)]
        public int AccountId {get;set;}

        /// <summary> 
        /// Id for  RoleDataModel.
        /// </summary>
        [Key, Column(Order = 1)]
        public int RoleId {get;set;}
    }
         

    /// <summary>
    /// Used internally to manage relationships between Right and Role for RoleRight searches.
    /// </summary>
    class RoleRightRelationshipModel 
    {
        /// <summary>
        /// Id for  RightDataModel.
        /// </summary>
        [Key, Column(Order = 0)]
        public int RightId {get;set;}

        /// <summary> 
        /// Id for  RoleDataModel.
        /// </summary>
        [Key, Column(Order = 1)]
        public int RoleId {get;set;}
    }
         
}
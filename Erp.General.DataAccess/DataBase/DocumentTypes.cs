//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Erp.General.DataAccess.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentTypes()
        {
            this.MovementsAccountsReceivable = new HashSet<MovementsAccountsReceivable>();
            this.MovementsDebtsToPay = new HashSet<MovementsDebtsToPay>();
            this.MovementsInventory = new HashSet<MovementsInventory>();
        }
    
        public short DocumentTypeId { get; set; }
        public string Name { get; set; }
        public short DebitAccountId { get; set; }
        public short CreditAccountId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementsAccountsReceivable> MovementsAccountsReceivable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementsDebtsToPay> MovementsDebtsToPay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementsInventory> MovementsInventory { get; set; }
    }
}

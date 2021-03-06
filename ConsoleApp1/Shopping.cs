//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shopping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shopping()
        {
            this.ShoppingAudit = new HashSet<ShoppingAudit>();
            this.ShoppingProduct = new HashSet<ShoppingProduct>();
        }
    
        public int ShoppingID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> StorageId { get; set; }
        public string ShoppingCode { get; set; }
        public string ShoppingType { get; set; }
        public Nullable<System.DateTime> TimeTo { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<byte> State { get; set; }
        public Nullable<int> AdminId { get; set; }
        public Nullable<decimal> TotalMoney { get; set; }
    
        public virtual Storage Storage { get; set; }
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingAudit> ShoppingAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingProduct> ShoppingProduct { get; set; }
    }
}

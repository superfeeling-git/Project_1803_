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
    
    public partial class Storage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Storage()
        {
            this.Shopping = new HashSet<Shopping>();
            this.StorageRegion = new HashSet<StorageRegion>();
        }
    
        public int StorageId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string StorageName { get; set; }
        public string StorageCode { get; set; }
        public Nullable<bool> State { get; set; }
        public string StorageLocation { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<int> AdminId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shopping> Shopping { get; set; }
        public virtual StorageType StorageType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StorageRegion> StorageRegion { get; set; }
    }
}

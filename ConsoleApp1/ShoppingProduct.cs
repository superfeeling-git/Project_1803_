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
    
    public partial class ShoppingProduct
    {
        public int ID { get; set; }
        public int ShoppingID { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BuyCount { get; set; }
        public Nullable<decimal> BuyPrice { get; set; }
        public Nullable<bool> IsGive { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Shopping Shopping { get; set; }
    }
}

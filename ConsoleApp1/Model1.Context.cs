﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class erp_testEntities : DbContext
    {
        public erp_testEntities()
            : base("name=erp_testEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductClass> ProductClass { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Shopping> Shopping { get; set; }
        public virtual DbSet<ShoppingAudit> ShoppingAudit { get; set; }
        public virtual DbSet<ShoppingProduct> ShoppingProduct { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<StorageRegion> StorageRegion { get; set; }
        public virtual DbSet<StorageType> StorageType { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierClass> SupplierClass { get; set; }
        public virtual DbSet<V_ProductList> V_ProductList { get; set; }
        public virtual DbSet<v_shop_product> v_shop_product { get; set; }
        public virtual DbSet<v_shopping> v_shopping { get; set; }
        public virtual DbSet<V_Storage_List> V_Storage_List { get; set; }
        public virtual DbSet<V_StorageLocation_List> V_StorageLocation_List { get; set; }
        public virtual DbSet<V_StorageRegion_List> V_StorageRegion_List { get; set; }
        public virtual DbSet<V_StorageType_List> V_StorageType_List { get; set; }
        public virtual DbSet<test> test { get; set; }
    
        [DbFunction("erp_testEntities", "fun_ProList")]
        public virtual IQueryable<fun_ProList_Result> fun_ProList(Nullable<decimal> price)
        {
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fun_ProList_Result>("[erp_testEntities].[fun_ProList](@price)", priceParameter);
        }
    
        [DbFunction("erp_testEntities", "tvpoints")]
        public virtual IQueryable<tvpoints_Result> tvpoints()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<tvpoints_Result>("[erp_testEntities].[tvpoints]()");
        }
    
        public virtual int p_pagedlist(string table, string where, string keyField, string showField, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalCount, ObjectParameter pageCount)
        {
            var tableParameter = table != null ?
                new ObjectParameter("table", table) :
                new ObjectParameter("table", typeof(string));
    
            var whereParameter = where != null ?
                new ObjectParameter("where", where) :
                new ObjectParameter("where", typeof(string));
    
            var keyFieldParameter = keyField != null ?
                new ObjectParameter("KeyField", keyField) :
                new ObjectParameter("KeyField", typeof(string));
    
            var showFieldParameter = showField != null ?
                new ObjectParameter("ShowField", showField) :
                new ObjectParameter("ShowField", typeof(string));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_pagedlist", tableParameter, whereParameter, keyFieldParameter, showFieldParameter, pageIndexParameter, pageSizeParameter, totalCount, pageCount);
        }
    
        public virtual ObjectResult<p_PageList_Result> p_PageList(Nullable<int> pageSize, Nullable<int> pageIndex, string typeCode, string typeName, ObjectParameter totalCount, ObjectParameter pageCount)
        {
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var typeCodeParameter = typeCode != null ?
                new ObjectParameter("TypeCode", typeCode) :
                new ObjectParameter("TypeCode", typeof(string));
    
            var typeNameParameter = typeName != null ?
                new ObjectParameter("TypeName", typeName) :
                new ObjectParameter("TypeName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<p_PageList_Result>("p_PageList", pageSizeParameter, pageIndexParameter, typeCodeParameter, typeNameParameter, totalCount, pageCount);
        }
    
        public virtual ObjectResult<P_SupplierPage_Result> P_SupplierPage(string supplierName, string contact, string phone, Nullable<bool> supplierState, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalCount, ObjectParameter pageCount)
        {
            var supplierNameParameter = supplierName != null ?
                new ObjectParameter("supplierName", supplierName) :
                new ObjectParameter("supplierName", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("Contact", contact) :
                new ObjectParameter("Contact", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var supplierStateParameter = supplierState.HasValue ?
                new ObjectParameter("supplierState", supplierState) :
                new ObjectParameter("supplierState", typeof(bool));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_SupplierPage_Result>("P_SupplierPage", supplierNameParameter, contactParameter, phoneParameter, supplierStateParameter, pageIndexParameter, pageSizeParameter, totalCount, pageCount);
        }
    
        public virtual int up_pagedlist(string table, string where, string keyField, string showField, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalCount, ObjectParameter pageCount)
        {
            var tableParameter = table != null ?
                new ObjectParameter("table", table) :
                new ObjectParameter("table", typeof(string));
    
            var whereParameter = where != null ?
                new ObjectParameter("where", where) :
                new ObjectParameter("where", typeof(string));
    
            var keyFieldParameter = keyField != null ?
                new ObjectParameter("KeyField", keyField) :
                new ObjectParameter("KeyField", typeof(string));
    
            var showFieldParameter = showField != null ?
                new ObjectParameter("ShowField", showField) :
                new ObjectParameter("ShowField", typeof(string));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("up_pagedlist", tableParameter, whereParameter, keyFieldParameter, showFieldParameter, pageIndexParameter, pageSizeParameter, totalCount, pageCount);
        }
    
        public virtual int up_pagelist(string table, string where, string keyField, string showField, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalCount, ObjectParameter pageCount)
        {
            var tableParameter = table != null ?
                new ObjectParameter("table", table) :
                new ObjectParameter("table", typeof(string));
    
            var whereParameter = where != null ?
                new ObjectParameter("where", where) :
                new ObjectParameter("where", typeof(string));
    
            var keyFieldParameter = keyField != null ?
                new ObjectParameter("KeyField", keyField) :
                new ObjectParameter("KeyField", typeof(string));
    
            var showFieldParameter = showField != null ?
                new ObjectParameter("ShowField", showField) :
                new ObjectParameter("ShowField", typeof(string));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("up_pagelist", tableParameter, whereParameter, keyFieldParameter, showFieldParameter, pageIndexParameter, pageSizeParameter, totalCount, pageCount);
        }
    }
}

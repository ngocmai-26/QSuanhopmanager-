﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QShopManagement.MODEL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLCHEntities : DbContext
    {
        public QLCHEntities()
            : base("name=QLCHEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_HANGHOA> tbl_HANGHOA { get; set; }
        public virtual DbSet<tbl_HOADON> tbl_HOADON { get; set; }
        public virtual DbSet<tbl_KHACHHANG> tbl_KHACHHANG { get; set; }
        public virtual DbSet<tbl_NHACUNGCAP> tbl_NHACUNGCAP { get; set; }
        public virtual DbSet<tbl_NHANVIEN> tbl_NHANVIEN { get; set; }
        public virtual DbSet<tbl_PHIEUNHAPKHO> tbl_PHIEUNHAPKHO { get; set; }
        public virtual DbSet<tbl_TAIKHOAN> tbl_TAIKHOAN { get; set; }
        public virtual DbSet<tbl_CTHOADON> tbl_CTHOADON { get; set; }
        public virtual DbSet<tbl_CTPHIEUNHAP> tbl_CTPHIEUNHAP { get; set; }
    }
}

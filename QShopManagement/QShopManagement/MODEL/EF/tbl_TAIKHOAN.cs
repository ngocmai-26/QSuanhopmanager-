//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tbl_TAIKHOAN
    {
        public int ID { get; set; }
        public string UserNam { get; set; }
        public string Password { get; set; }
        public string HieuLuc { get; set; }
        public string MSNV { get; set; }
    
        public virtual tbl_NHANVIEN tbl_NHANVIEN { get; set; }
    }
}

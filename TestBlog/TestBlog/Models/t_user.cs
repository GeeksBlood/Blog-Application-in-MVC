//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_user()
        {
            this.t_posts = new HashSet<t_posts>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string mobile_no { get; set; }
        public string city { get; set; }
        public string last_login { get; set; }
        public string password { get; set; }
        public int is_type { get; set; }
        public bool is_active { get; set; }
        public string reg_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_posts> t_posts { get; set; }
        public virtual t_userType t_userType { get; set; }
    }
}

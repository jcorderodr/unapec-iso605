using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(500)]
        public string Password { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(11)]
        public string Identification { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}

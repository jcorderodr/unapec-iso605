using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unapec.HumanResourcesM.Framework.Entities
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
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public bool ChangePassword { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}

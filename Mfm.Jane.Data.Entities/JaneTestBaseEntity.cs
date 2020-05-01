using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfm.Jane.Data.Entities
{
    public class JaneTestBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string CreatedBy { get ; set ; }
        public DateTime LastModifiedDate { get ; set ; }
        public string LastModifiedBy { get ; set ; }
    }
}

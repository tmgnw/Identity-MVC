using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityMVC.Models
{
    [Table("TB_T_TodoList")]
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }
        public virtual string UserId { get; set; }
    }
}
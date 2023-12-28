using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Entites.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Time { get; set; }
    }
}

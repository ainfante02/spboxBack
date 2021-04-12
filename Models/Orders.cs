using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace appspbox.Models
{
    public class Orders
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }

        public DateTime Fecha { get; set; }
        [ForeignKey("GetProvider")]
        public int providerId { get; set; }
        
    }
}

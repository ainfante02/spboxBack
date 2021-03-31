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
        public int orderrId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int identity { get; set; }
        [JsonIgnore]
        public List<Product> GetProducts { get; set; }
    }
}

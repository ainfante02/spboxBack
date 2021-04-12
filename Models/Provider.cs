using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace appspbox.Models
{
    public class Provider
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int providerId { get; set; }
        public string providerName { get; set; }
        public string direction { get; set; }
        public int phone { get; set; }

    }
}

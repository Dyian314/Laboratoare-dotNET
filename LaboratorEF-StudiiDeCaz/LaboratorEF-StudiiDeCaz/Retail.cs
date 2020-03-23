using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorEF_StudiiDeCaz
{
    [Table("Retail", Schema = "BazaDeDate")]
    class Retail : Business
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }

    }
}

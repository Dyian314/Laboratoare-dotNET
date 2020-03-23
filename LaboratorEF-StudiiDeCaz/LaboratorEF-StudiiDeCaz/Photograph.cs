using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace LaboratorEF_StudiiDeCaz
{
    public class Photograph
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public byte[] ThumbnailBits { get; set; }
        [ForeignKey("PhotoId")]
        public virtual PhotographFullImage PhotographFullImage { get; set; }
    }
}

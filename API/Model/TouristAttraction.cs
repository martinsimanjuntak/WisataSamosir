using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_tourist_Actraction")]
    public class TouristAttraction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("location"), MaxLength(100)]
        public string Location{ get; set; }
        [Column("name"), MaxLength(25)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}

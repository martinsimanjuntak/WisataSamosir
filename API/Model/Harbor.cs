using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_harbor")]
    public class Harbor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("pelabuhan_name"), MaxLength(25)]
        public string Harbor_Name { get; set; }
        [Column("location"), MaxLength(100)]
        public string Location { get; set; }
        [Column("latitude")]
        public double Latitude { get; set; }
        [Column("longitude")]
        public double Longitude { get; set; }
        [Column("description")]
        public string Description { get; set; }
        public virtual PortRoute Route_id { get; set; }
    }
}

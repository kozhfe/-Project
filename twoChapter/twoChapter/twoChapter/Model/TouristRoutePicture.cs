using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace twoChapter.Model
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        [ForeignKey("TouristRouteId")]
        public Guid TouristRouteId { get; set; }
        public TouristRoute TouristRoute { get; set; }//链接属性
    }
}

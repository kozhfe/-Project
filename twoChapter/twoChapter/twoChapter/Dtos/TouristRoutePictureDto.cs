using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using twoChapter.Model;

namespace twoChapter.Dtos
{
    public class TouristRoutePictureDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public Guid TouristRouteId { get; set; }
    }
}

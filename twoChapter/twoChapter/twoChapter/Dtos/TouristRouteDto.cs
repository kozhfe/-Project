using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using twoChapter.Model;

namespace twoChapter.Dtos
{
    public class TouristRouteDto
    {
        [Key]
        public Guid id { get; set; }
        [Required]//不能为空
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
        [Range(0.0, 1.0)]
        public double? DiscountPresent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        [MaxLength]
        public string Features { get; set; }
        [MaxLength]
        public string Fess { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        /// <summary>
        /// 外键
        /// </summary>
        public ICollection<TouristRoutePictureDto> TouristRoutePictures { get; set; }
    }
}

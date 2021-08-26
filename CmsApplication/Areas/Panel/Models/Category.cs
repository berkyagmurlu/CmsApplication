using CmsApplication.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Areas.Panel.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(128), Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Durum")]
        public StatusEnum Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Eklenme Tarihi"), DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}

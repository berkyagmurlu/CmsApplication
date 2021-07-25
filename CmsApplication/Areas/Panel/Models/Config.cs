using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Areas.Panel.Models
{
    public class Config
    {
        public int Id { get; set; }

        [StringLength(256), Required]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [StringLength(256), Required]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [StringLength(256), Required]
        [Display(Name = "Değer")]
        public string Value { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Eklenme Tarihi"), DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Areas.Panel.Models
{
    public class Config
    {
        public int Id { get; set; }

        [StringLength(256), Required]
        public string Name { get; set; }

        [StringLength(256), Required]
        public string Title { get; set; }
        [StringLength(256), Required]
        public string Value { get; set; }

        [Display(Name = "Eklenme Tarihi"), DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}

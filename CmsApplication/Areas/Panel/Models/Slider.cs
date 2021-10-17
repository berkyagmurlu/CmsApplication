using CmsApplication.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Areas.Panel.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [StringLength(512), Required]
        public string FileName { get; set; }

        public int Direction { get; set; }
       
        [Required]
        public StatusEnum Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}

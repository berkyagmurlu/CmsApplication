using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Enums
{
    public enum StatusEnum: int
    {
        [Display(Name = "Pasif")]
        Passive = 0,

        [Display(Name = "Aktif")]
        Active = 1,
    }
}

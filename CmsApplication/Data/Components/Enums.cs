using System;
using System.ComponentModel.DataAnnotations;

namespace CmsApplication.Data
{
    public class Enums
    {
        public enum StatusEnum
        {
            [Display(Name = "Aktif")]
            Active = 1,

            [Display(Name = "Pasif")]
            Passive = 0
        }
    }
}

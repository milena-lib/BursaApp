using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Bursa.Models.Enums;

namespace Bursa.Models
{
    public class BursaType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
    public class PaperType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public  BursaType Bursa { get; set; }
    }
    public class Paper
    {
        public int PaperId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PaperName { get; set; }
        [Required]
        public PaperType PaperTypeValue { get; set; }

        [MaxLength(5)]
        public string LastDeal{ get; set; }

        public double LastRate { get; set; }
        public double LastRatePercent { get; set; }

        public double Amount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.Models
{
    public class CustomerAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AnthropometricMeasurements? AMDescription { get; set; }
        public float Value { get; set; }
        public int IdProgress { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
    }
}
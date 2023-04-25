using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.Models
{
    public class CustomerPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime EndsAt { get; set; }
        public PaymentPlan? PlanSelected { get; set; }
        public int CustomerId { get; set; }
    }
}
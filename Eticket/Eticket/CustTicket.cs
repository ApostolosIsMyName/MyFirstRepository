namespace Eticket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustTicket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerEmail { get; set; }

        [StringLength(20)]
        public string CustomerPhone { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [StringLength(15)]
        public string CSAgent { get; set; }

        [StringLength(15)]
        public string TechSupport { get; set; }

        public bool Closed { get; set; }

        public virtual CSAgent CSAgent1 { get; set; }

        public virtual TechSupportUser TechSupportUser { get; set; }
    }
}

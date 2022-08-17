namespace FIT5032_careUmore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dotor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int WorkYears { get; set; }

        [Required]
        public string Locations { get; set; }

        [Required]
        public string Email { get; set; }

        public string Position { get; set; }

        
        [Column(TypeName = "date")]
        public DateTime AvailabilityDate { get; set; }
    }
}

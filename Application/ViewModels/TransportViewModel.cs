using System;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels
{
    public class TransportViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Distanace /km")]
        public int Distance { get; set; }
        [Required]
        [Display(Name = "Living area /m2")]
        public int LivingArea { get; set; }
        [Required]
        [Display(Name = "Attic area /m2")]
        public int AtticArea { get; set; }
        [Required]
        [Display(Name = "Distance price SEK /car")]
        public double DistancePriceCar { get; set; }
        [Required]
        public bool Piano { get; set; }
        [Required]
        [Display(Name = "Price /SEK")]
        public double Price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace StripeApiProto.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserEmail { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

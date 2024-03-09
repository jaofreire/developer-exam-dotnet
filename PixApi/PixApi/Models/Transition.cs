using System.ComponentModel.DataAnnotations;

namespace PixApi.Models
{
    public class Transition
    {
        
        public int Id { get; set; }
        public string? IssuerClient { get; set; }
        public string? IssuerClientKey { get; set; }
        public string? ReceiverClient { get; set; }
        public string? ReceiverClientKey { get; set; }
        public double DepositValue { get; set; }

    }
}

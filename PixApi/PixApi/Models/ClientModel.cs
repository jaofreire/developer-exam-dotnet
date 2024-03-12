using System.ComponentModel.DataAnnotations.Schema;

namespace PixApi.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ClientKeyId { get; set; }

        public KeyModel? Key { get; set; }

    }
}

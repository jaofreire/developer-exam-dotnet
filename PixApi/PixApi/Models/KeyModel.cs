using System.ComponentModel.DataAnnotations.Schema;

namespace PixApi.Models
{
    public class KeyModel
    {
       
        public int Id { get; set; }
        public string? TypeKey { get; set; }
        public string? Key { get; set; }
        

    }
}

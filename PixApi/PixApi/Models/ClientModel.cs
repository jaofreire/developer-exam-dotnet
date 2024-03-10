namespace PixApi.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int KeysId { get; set; }
        public KeyModel? Key { get; set; }
    }
}

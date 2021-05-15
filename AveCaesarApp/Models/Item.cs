namespace AveCaesarApp.Models
{
    public class Item
    {
        public Item()
        {
            
        }

        public Item(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int GetId() => Id;

    }
}

namespace Pc.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string specifications { get; set; } = string.Empty;
    }
}

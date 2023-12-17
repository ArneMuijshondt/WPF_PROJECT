using System.ComponentModel.DataAnnotations;

namespace WpfApp1
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

    }
}
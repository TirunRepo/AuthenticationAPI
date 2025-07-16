using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationAPI.Infrastructure
{
    [Table("User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

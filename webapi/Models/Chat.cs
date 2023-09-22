using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Chat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}

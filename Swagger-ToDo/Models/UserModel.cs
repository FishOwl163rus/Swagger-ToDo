using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Swagger_ToDo.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<NoteModel> Notes { get; set; } = new List<NoteModel>();
    }
}
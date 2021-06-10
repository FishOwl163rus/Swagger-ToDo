using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Swagger_ToDo.Models
{
    public class NoteModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Info { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public bool IsCompleted { get; set; } = false;
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [JsonIgnore]
        public virtual UserModel User { get; set; }
    }
}
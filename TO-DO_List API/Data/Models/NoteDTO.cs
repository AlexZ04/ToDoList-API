using System.ComponentModel.DataAnnotations;

namespace TO_DO_List_API.Data.Models
{
    public class NoteDTO
    {
        [Required]
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
    }
}

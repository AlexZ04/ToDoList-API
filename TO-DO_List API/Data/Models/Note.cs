using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TO_DO_List_API.Data.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsCompleted { get; set; }

        public Note()
        {
            IsCompleted = false;
        }

        public Note(string text)
        {
            Text = text;
            IsCompleted = false;
        }

        public void EditTask(string newText)
        {
            Text = newText;
        }

        public void CheckTask()
        {
            IsCompleted = !IsCompleted;
        }

        public void ChangeText(string newText)
        {
            Text = newText;
        }
    }
}

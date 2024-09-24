using System.Runtime.CompilerServices;

namespace TO_DO_List_API
{
    public class Task
    {
        public int id {  get; set; }
        public string text {  get; set; }
        public bool isCompleted { get; set; }

        public Task(int inputId, string inputText) {
            id = inputId;
            text = inputText;
            isCompleted = false;
        }

        public void EditTask(string newText)
        {
            text = newText;
        }

        public void CheckTask()
        {
            isCompleted = !isCompleted;
        }

        public void ChangeText(string newText) 
        { 
            text = newText;
        }
    }
}

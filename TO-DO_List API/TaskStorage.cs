namespace TO_DO_List_API
{
    public class TaskStorage
    {
        private List<Task> tasks;
        private int currentId;

        public TaskStorage()
        {
            tasks = new List<Task>();
            currentId = 0;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
            currentId++;
        }

        public int GetId()
        {
            return currentId;
        }

        public int GetLength()
        {
            return tasks.Count;
        }

        public Task GetTask(int index)
        {
            return tasks[index];
        }

        public List<Task> GetTasksList()
        {
            return tasks;
        }
    }
}

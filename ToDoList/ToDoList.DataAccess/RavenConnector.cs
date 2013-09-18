using Raven.Client.Document;
using ToDoList.Domain;

namespace ToDoList.DataAccess
{
    public class RavenConnector
    {
        private DocumentStore store;
        private const string DatabaseName = "tasks";
        public RavenConnector(string connectionString)
        {
            store = new DocumentStore { Url = connectionString };
            store.Initialize();
        }

        public void Save(Task task)
        {
            using (var session = store.OpenSession(DatabaseName))
            {
                session.Store(task);
                session.SaveChanges();
            }
        }

        public void Delete(Task task)
        {
            using (var session = store.OpenSession(DatabaseName))
            {
                session.Delete(task);
                session.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Contact
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection db;

        public UserDatabase(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Schema.UserItem>().Wait();
        }

        public Task<Schema.UserItem> Get(int id)
        {
            return db.Table<Schema.UserItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Schema.UserItem>> GetAll()
        {
            return db.Table<Schema.UserItem>().ToListAsync();
        }

        public Task<int> Save(Schema.UserItem item)
        {
            if (item.ID != 0)
            {
                return db.UpdateAsync(item);
            }

            return db.InsertAsync(item);
        }

        public Task<int> Delete(Schema.UserItem item)
        {
            return db.DeleteAsync(item);
        }
    }
}

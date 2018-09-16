using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Contact
{
    public class ContactDatabase
    {
        readonly SQLiteAsyncConnection db;

        public ContactDatabase(string path) {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Schema.ContactItem>().Wait();
        }

        public Task<Schema.ContactItem> Get(int id)
        {
            return db.Table<Schema.ContactItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Schema.ContactItem>> GetAll()
        {
            return db.Table<Schema.ContactItem>().ToListAsync();
        }

        public Task<int> Save(Schema.ContactItem item)
        {
            if (item.ID != 0)
            {
                return db.UpdateAsync(item);
            }

            return db.InsertAsync(item);
        }

        public Task<int> Delete(Schema.ContactItem item)
        {
            return db.DeleteAsync(item);
        }
    }
}

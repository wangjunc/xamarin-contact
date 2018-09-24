using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Contact.Schema
{
    public class UserItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //public string Username { get; set; }
        //public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}

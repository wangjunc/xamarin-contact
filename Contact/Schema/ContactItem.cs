using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contact.Schema
{
    public class ContactItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}

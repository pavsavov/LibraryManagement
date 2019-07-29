using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Data.Models.BaseModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryManagement.Data.Models
{
    public class Book : BaseDbModel
    {
        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int Copies { get; set; }
    }
}

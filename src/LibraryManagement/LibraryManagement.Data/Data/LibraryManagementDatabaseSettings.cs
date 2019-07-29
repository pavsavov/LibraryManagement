using LibraryManagement.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data.Models
{
    public class LibraryManagementDatabaseSettings : ILibraryManagementDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

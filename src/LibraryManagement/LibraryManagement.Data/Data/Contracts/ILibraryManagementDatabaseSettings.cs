using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data.Models.Contracts
{
    public interface ILibraryManagementDatabaseSettings
    {
        string BooksCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}

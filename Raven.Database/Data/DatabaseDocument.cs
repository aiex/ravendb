using System;
using System.Collections.Generic;

namespace Raven.Database.Data
{
    public class DatabaseDocument
    {
        public string Id { get; set; }
        public Dictionary<string, string> Settings { get; set; }

        public DatabaseDocument()
        {
            Settings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
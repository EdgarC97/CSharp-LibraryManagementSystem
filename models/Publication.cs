using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    public class Publication
    {
        public string? Title { get; set; }
        public DateOnly PublicationYear { get; set; }

        public Publication(string title, DateOnly publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
        }
    }
}


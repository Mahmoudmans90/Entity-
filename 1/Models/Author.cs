using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.Models
{
    public class Author
    {
     public int Id { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string Email { get; set; }

     public string Biography { get; set; }   
     public DateTime dateOfBirth { get; set; }
     public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CluedIn.Crawling.SQL.Core.Models
{
    public class Person
    {
        public Person(SqlDataReader reader)
        {
            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            Id = reader["Id"].ToString();
            JobTitle = reader["JobTitle"].ToString();
            Email = reader["Email"].ToString();
            Age = reader["Age"].ToString();
            Gender = reader["Gender"].ToString();
            CreatedAt = reader["CreatedAt"].ToString();

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; }
    }
}

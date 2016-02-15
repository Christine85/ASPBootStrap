using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterASP
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string id;

        public Person(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
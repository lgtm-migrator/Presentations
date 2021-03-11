﻿namespace AdvEx
{
    public interface IPerson
    {
        string FirstName { get; set; }
        int ID { get; set; }
        string LastName { get; set; }

        string FullName();
    }

    public class Person : IPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsOOP
{
    class Person
    {
        private string name;
        private string lastName;
        private DateTime data;

        public Person()
        {
            this.name = "";
            this.lastName = "";
            this.data = new DateTime(0);
        }

        public Person(string name, string lastName, DateTime data)
        {
            this.name = name;
            this.lastName = lastName;
            this.data = data;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int DataInt
        {
            get { return (int)this.data.Ticks; }
            set { this.data = new DateTime(value); }
        }

        public override string ToString()
        {
            return "Name: " + this.name + '\n' +
                   "LastName: " + this.lastName + '\n' +
                   "Birth Date: " + this.data.ToString();
        }

        public virtual string ToShortString()
        {
            return "Name: " + this.name + '\n' +
                   "LastName: " + this.lastName;
        }

        public virtual bool Equals(object obj)
        {
            if (typeof(Person) != obj.GetType())
                return false;
            Person other = (Person)obj;
            return(this.name.Equals(other.Name) &&
                   this.lastName.Equals(other.LastName) &&
                   this.data.Equals(other.Data)
                );
        }

        public virtual object DeepCopy()
        {
            return new Person(this.name, this.lastName, this.data);
        }

        public override int GetHashCode()
        {
            return(
                Hash.ShiftAndWrap(this.data.GetHashCode(), 4) ^
                Hash.ShiftAndWrap(this.lastName.GetHashCode(), 2) ^
                this.name.GetHashCode()
                );
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Name == person2.Name && person1.LastName == person2.LastName && person1.Data == person2.Data;
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
                   "Birth Date: " + this.data.ToString() ;
        }

        public virtual string ToShortString()
        {
            return "Name: " + this.name + '\n' +
                   "LastName: " + this.lastName;
        }
    }

   


        

    }

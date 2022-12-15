using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabsOOP
{
    class Edition
    {
        protected string name;
        protected DateTime data;
        protected int circulation;

        public Edition(string name, DateTime data, int circulation)
        {
            this.name = name;
            this.data = data;
            this.circulation = circulation;
        }

        public Edition()
        {
            this.name = "";
            this.data = new DateTime(0);
            this.circulation = 0;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Circulation
        {
            get { return this.circulation; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value >= 0 "); 
                this.circulation = value;
                }
        }

        public virtual Edition DeepCopy()
        {
            return new Edition(this.name, this.data, this.circulation);
        }

        public override int GetHashCode()
        {
            return(
                Hash.ShiftAndWrap(this.data.GetHashCode(), 4) ^
                Hash.ShiftAndWrap(this.circulation.GetHashCode(), 2) ^
                this.name.GetHashCode()
                );
        }

        public virtual bool Equals(object obj)
        {
            if (typeof(Edition) != obj.GetType())
                return false;
            Edition edition = (Edition)obj;
            return (this.name.Equals(edition.name) &&
                    this.data.Equals(edition.data) &&
                    this.circulation.Equals(edition.circulation)
                );
        }

        public override string ToString()
        {
            return "Name: " + this.name + '\n' +
                   "Data: " + this.data.ToString() + '\n' +
                   "Тираж: " + this.circulation.ToString();
        }
    }
}

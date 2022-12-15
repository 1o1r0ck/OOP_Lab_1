using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsOOP
{
    class Magazine : Edition, IRateAndCopy
    {
        private Frequncy frequncy;
        private ArrayList articles;
        protected ArrayList editors;

        public Magazine(string name, Frequncy frequncy, DateTime data, int count) : base(name, data, count)
        {
            this.frequncy = frequncy;
            this.articles = new ArrayList();
            this.editors = new ArrayList();
          
        }

        public Magazine() : base()
        {
            this.frequncy = Frequncy.Weekly;
            this.articles = new ArrayList();
            this.editors = new ArrayList();
        }

        public Edition Edition
        {
            get { return new Edition(name, data, circulation); }
            set {
                this.name = value.Name;
                this.data = value.Data;
                this.circulation = value.Circulation;
            }
        }

        public ArrayList Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        public Frequncy Frequncy
        {
            get { return this.frequncy;}
            set { this.frequncy = value;}
        }


        public double Avg
        {
            get
            {
                if (this.Articles.Count == 0)
                    return 0;
                double sum_ = 0;
                foreach (Article article in this.Articles)
                    sum_ += article.rating;
                return sum_ / this.Articles.Count;
            }
        }

        public bool IsTrue(Frequncy value)
        {
            return value == this.frequncy;
        }

        public void AddArticles(Object[] new_articles)
        {
            this.articles.AddRange(new_articles);
        }

        public new Magazine DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequncy, this.data, this.circulation);
            magazine.AddArticles(this.articles.ToArray());
            magazine.AddEditors(this.editors.ToArray());
            return magazine;
        }
        object IRateAndCopy.DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequncy, this.data, this.circulation);
            magazine.AddArticles((Article[])this.articles.ToArray());
            magazine.AddEditors((Person[])this.editors.ToArray());
            return magazine;
        }
        double IRateAndCopy.Rating => this.Avg;

        public void AddEditors(Object[] new_editors)
        {
            this.editors.AddRange(new_editors);
        }

        public override string ToString()
        {
            string result = (
                "Name: " + this.name + '\n' +
                "Frequncy: " + this.frequncy.ToString() + '\n' +
                "Data: " + this.data.ToString() + '\n' +
                "Count: " + this.circulation.ToString() + '\n' +
                "Articles:\n"
                );
            if (this.articles.Count == 0)
                result += "Not atricles";
            else
            {
                foreach (Article article in this.articles)
                {
                    result += article.ToString() + '\n';
                }
            }
            result += "No editors\n";

            if(this.editors.Count == 0)
                result += "No editors";
            else
                foreach (Person person in this.editors)
                {
                    result += person.ToString() + "\n";
                }

            return result;
        }

        public virtual string ToShortString()
        {
            return "Name " + this.name +
                   "Frequncy " + this.frequncy.ToString() +
                   "Data " + this.data.ToString() + ' ' +
                   "Count " + this.circulation.ToString() + ' ' +
                   "AVG " + this.Avg.ToString() + ' ';
        }
    }
}

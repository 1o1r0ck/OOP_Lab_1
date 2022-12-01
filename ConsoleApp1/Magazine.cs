using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Magazine
    {
        private string name;
        private Frequncy frequncy;
        private DateTime data;
        private int count;
        private Article[] articles;

        public Magazine(string name, Frequncy frequncy, DateTime data, int count)
        {
            this.name = name;
            this.frequncy = frequncy;
            this.data = data;
            this.count = count;
            this.articles = new Article[0];
        }

        public Magazine()
        {
            this.name = "";
            this.frequncy = Frequncy.Weekly;
            this.data = new DateTime(0);
            this.count = 0;
            this.articles = new Article[0];
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Frequncy Frequncy
        {
            get { return this.frequncy; }
            set { this.frequncy = value; }
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Counter
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public Article[] Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }


        public double Avg
        {
            get
            {
                if (this.Articles.Length == 0)
                    return 0;
                else
                    return this.Articles.Sum(a => a.rating) / this.Articles.Length;
            }
        }

        public bool IsTrue(Frequncy value)
        {
            return value == this.frequncy;
        }

        public void AddArticles(Article[] new_articles)
        {
            int len = this.articles.Length;
            Array.Resize(ref this.articles, this.articles.Length + new_articles.Length);
            for (int i = 0; i < new_articles.Length; i++)
            {
                this.articles[len + i] = new_articles[i];
            }
        }

        public override string ToString()
        {
            string result = (
                "Name: " + this.name + '\n' +
                "Frequncy: " + this.frequncy.ToString() + '\n' +
                "Data: " + this.data.ToString() + '\n' +
                "Count: " + this.count.ToString() + '\n' +
                "Articles:\n" 
              
                );
            if (this.articles.Length == 0)
                result += "Not atricles";
            else
            {
                foreach (Article article in this.articles)
                {
                    result += article.ToString() + '\n';
                }
            }
            return result;
        }

        public virtual string ToShortString()
        {
            return "Name: " + this.name + '\n' +
                "Frequncy: " + this.frequncy.ToString() + '\n' +
                "Data: " + this.data.ToString() + '\n' +
                "Count: " + this.count.ToString() + '\n' +
                "Average: " + this.Avg.ToString() + '\n';
        }
    }
}

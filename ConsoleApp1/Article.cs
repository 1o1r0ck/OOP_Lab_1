using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Article
    {
        public Person author;
        public string title;
        public double rating;

        public Article(Person author, string title, double rating)
        {
            this.author = author;
            this.title = title;
            this.rating = rating;
        }

        public Article()
        {
            this.author = new Person();
            this.title = "";
            this.rating = 0;
        }

        public override string ToString()
        {
            return
                 "-------------------------------\n" +
                "Author: " + this.author.ToString() + '\n' +
                   "Title: " + this.title + '\n' +
                   "Rating: " + this.rating.ToString() + '\n' +
                  "-------------------------------\n";
        }
    }
}

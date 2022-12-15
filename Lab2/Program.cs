using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabsOOP
{

    enum Frequncy { Weekly, Monthly, Yearly };

    interface IRateAndCopy
    {
        double Rating { get;}
        object DeepCopy();
    }

    public static class Hash
    {
        public static int ShiftAndWrap(int value, int positions)
        {
            positions &= 0x1F;
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //PrintPoint(1);
            Edition ed1 = new Edition();
            Edition ed2 = new Edition();

            Console.WriteLine(
                "Data equals: " + (ed1 == ed2).ToString() + '\n' +
                "Reference equals: " + ReferenceEquals(ed1, ed2).ToString() + '\n' + 
                "First hash: " + ed1.GetHashCode().ToString() + '\n' +
                "Second hash: " + ed2.GetHashCode().ToString() + '\n' +
                "----------------------------------------------"
                );

            //PrintPoint(2);
            try
            {
                ed1.Circulation = -2;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //PrintPoint(3);
            Magazine m = new Magazine();
            m.AddArticles(
                new Article[2] {
                    new Article (
                        new Person("Первый", "Пользователь", new System.DateTime(2003, 6, 12)),
                        "C#",
                        3.8
                    ),
                    new Article (
                        new Person("Второй", "Пользователь", new System.DateTime(2003, 10, 14)),
                        "C#",
                        4.3
                    )
                }
            );
            m.AddEditors(
                new Person[2] {
                    new Person("Третий", "Пользователь", new System.DateTime(2003, 3, 16)),
                    new Person("Четвертый", "Пользователь", new System.DateTime(2004, 2, 14))
                }
            );
            Console.WriteLine(m.ToString());
            Console.WriteLine(m.Edition.ToString());
            
            Magazine m1 = m.DeepCopy();
            m1.AddEditors(
                new Person[1] {
                    new Person("Пятый", "Пользователь", new System.DateTime(2003, 10, 14))
                }
            );
            m1.Name = "Users";
            Console.WriteLine(m.ToString());
            Console.WriteLine(m1.ToString());
        }
    }
}


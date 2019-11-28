using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 의미심장
{
    //Getter Setter 이용
    class Person_GetSet
    {
        private string name;

        public void SetName(string value)
        {
            name = value;
        }

        public string GetName()
        {
            return name;
        }

    }
    //perperties 이용
    class Person_Properties
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }//set 의 암묵적 매개변수
        }
    }
    class Program
    {
        
            static void Main(string[] args)
            {
            Person_GetSet p1 = new Person_GetSet();
            p1.SetName("아이유");
            Console.WriteLine(p1.GetName());

            Person_Properties p2 = new Person_Properties();
            p2.Name = "장만월";
            Console.WriteLine(p2.Name);
   
            }
        }
    }


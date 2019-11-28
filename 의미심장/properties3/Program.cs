using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties3
{
   class Computer
    {
        public string name;
        public string powerOn;
        public string Name
        {

            get { return name; }
            set { name = value; }
        }

        public string Boot()
        {
            return "부팅합니다";
        }
        public string Shutdown()
        {
            return "전원을 종료합니다";
        }
        public string Reset()
        {
            return "재부팅합니다";
        }
        
    }
    class Notebook : Computer
    {

    }
    class Program
    {
        static void Main(string[] args)
        {

            Computer com = new Computer();
            

        }
    }
}

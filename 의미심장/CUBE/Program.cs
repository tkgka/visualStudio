using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 평택
{

    class form
    {
        public string Name { get; set; }
        public int heigth { get; set; }
    }
    class main
    {
        static void Main(string[] args)
        {

            form[] arrProfile =
            {
                new form() { Name = "정우성", heigth = 186 },
                new form() { Name = "김태희", heigth = 158 },
                new form() { Name = "고현정", heigth = 172 },
                new form() { Name = "이문세", heigth = 178 },
                new form() { Name = "하하", heigth = 171 }
        };


            var listprofile = from profile in arrProfile
                              orderby profile.heigth
                              group profile by profile.heigth < 175 into g
                              select new { groupkey = g.Key, profiles = g };
            foreach (var Group in listprofile)
            {
                Console.WriteLine($"-175미만? : {Group.groupkey}");

                foreach (var profile in Group.profiles)
                {
                    Console.WriteLine($"     {profile.Name}, {profile.heigth}");
                }
            }
        }
    }
}


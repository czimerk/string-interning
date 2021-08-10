using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StringInterning
{
    class Message
    {
        public string Msg { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string p = "test1";

            //string k = "test1";

            //string t = "test2";

            string p = "test1test1test1test1test1test1test1";
            string k = "test1test1test1test1test1test1test1";
            string t = "test1test1test1test1test1test1test2";

            string pk = "tes" + "t1";

            string t1 = "t1";

            string interp = $"tes{t1}";

            string interpInterned = string.Intern(interp);

            string tModositott = t.Replace("t", "p");
            string tOsszekotott = string.Concat(t, "test2");
            //t[2] = "p";


            var h = new Hello();
            Console.WriteLine($"p és k memóriacíme azonos");
            Console.WriteLine(ReferenceEquals(p, k));

            Console.WriteLine($"k és a statikus stringekből összefűzött pk memóriacíme azonos");
            Console.WriteLine(ReferenceEquals(k, pk));

            Console.WriteLine($"k és az interp interpolált string nem egyezik, de ");
            Console.WriteLine(ReferenceEquals(k, interp));
            Console.WriteLine($"az IsInterned függvény visszaadja az első referenciát az intern pool-ból (k-ét) amennyiben internalizált");
            Console.WriteLine(ReferenceEquals(k, string.IsInterned(interp)));

            Console.WriteLine($"interpInterned tartalmazza az internalizált referenciát - ez másik referencia mint az interp változóban");
            Console.WriteLine(ReferenceEquals(k, interpInterned));

            Console.WriteLine($"p és egy osztályban tárolt azonos string memóriacíme nem egyezik");
            Console.WriteLine(ReferenceEquals(p, Hello.HelloTxt));

            Console.WriteLine($"k és a metódusból visszaadott string memóriacíme nem azonos");
            Console.WriteLine(ReferenceEquals(k, h.getHello()));

            Console.WriteLine($"k és a Program.cs-ben visszaadott string memória címe sem azonos");
            Console.WriteLine(ReferenceEquals(k, GetHello()));

            var sw = new Stopwatch();
            sw.Start();
            var dt0 = sw.Elapsed;
            Console.WriteLine(dt0);
            int i = 0;
            for (i = 0; i < 10000000; i++)
            {
                bool isEqual;
                if (p == k)
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = true;
                }
            }

            var dt1 = sw.Elapsed - dt0;
            Console.WriteLine("összehasonlítás azonos stringekre");
            Console.WriteLine(sw.Elapsed);
          

            for (i = 0; i < 10000000; i++)
            {
                bool isEqual;
                if (p == t)
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = true;
                }
            }

            var dt2 = sw.Elapsed - dt1;
            Console.WriteLine("összehasonlítás különböző stringekre");
            Console.WriteLine(sw.Elapsed);

            var list = new List<string>();
            var list2 = new List<string>();


            //100000 különböző string egy listában
            
            for (i=0; i < 100000; i++)//<<breakpoint, memory snapshot
            {
                list.Add("test" + i);
            }

            //100000 azonos string egy listában
            for (i = 0; i < 100000; i++)//<<breakpoint, memory snapshot
            {
                list2.Add("test" + "100000");
            }
            Console.ReadLine();//<<breakpoint, memory snapshot

            i++;

            var f = list[0];
            var f2 = list2[0];
        }

        static string GetHello()
        {
            return "Hello";
        }

    }
}

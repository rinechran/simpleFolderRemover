using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoRemoveNet
{

    class Program
    {
        static void helpCommand()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
            Console.WriteLine("this program remove yyyy-MM-dd");
            Console.WriteLine("-path folder path (example D:\\test)");
            Console.WriteLine("-expire expireDay (default 30 day)");
            Console.WriteLine("-format format (default yyyy-MM-dd)");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");

        }
        static void Main(string[] args)
        {
            FileRemover fileRemover = new FileRemover();

            if (args.Length == 0)
            {
                helpCommand();
            }
            else if(args.Length%2==0)
            {
                int i = 0;
                while (i < args.Length)
                {
                    string tag = args[i];
                    string behaver = args[i + 1];

                    switch (tag)
                    {
                        case "-path":
                            fileRemover.Path = behaver;
                            break;
                        case "-format":
                            fileRemover.Format = behaver;
                            break;
                        case "-expire":
                            fileRemover.ExpireDay = -Convert.ToInt32(behaver);
                            break;

                    }
                    i += 2;

                }
                fileRemover.Run();

            }
        }
    }
}

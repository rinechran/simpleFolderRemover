using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoRemoveNet
{
    public class FileRemover
    {
        public FileRemover()
        {
            Format = "yyyy-MM-dd";
            ExpireDay = -30;
            CurrentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }


        public bool IsDateValieDate(string str)
        {
            try
            {
                DateTime.ParseExact(str, Format, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool IsExpire(string str)
        {
            DateTime dateMin = CurrentTime.AddDays(ExpireDay);
            DateTime fileDate = DateTime.ParseExact(str, Format, System.Globalization.CultureInfo.CurrentCulture)
                .AddHours(23).AddMinutes(59).AddSeconds(59);

            if (DateTime.Compare(fileDate,dateMin) > 0)
            {
                return false;
            }

            return true;
        }
        public void Run()
        {
            if (Path == "")
            {
                throw new ArgumentException("Not Setting Path");
            }
            string [] dirs = Directory.GetDirectories(Path);
            foreach (string dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);

                if (IsDateValieDate(dirInfo.Name) && IsExpire(dirInfo.Name))
                {
#if DEBUG
                    Console.WriteLine("Delete folder " + dirInfo.Name);
#endif
                    dirInfo.Delete(true);
                }
                else
                {
#if DEBUG
                    Console.WriteLine("Not Delete folder " + dirInfo.Name);
#endif
                }

            }
        }

        public string Path
        {
            get;
            set;
        }
        public string Format
        {
            get;
            set;
        }
        public int ExpireDay
        {
            get;
            set;
        }
        private DateTime CurrentTime
        {
            get;
            set;
        }
    }
}

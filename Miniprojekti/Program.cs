// See https://aka.ms/new-console-template for more information
using System.IO;
using Tiedostokuvaus;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Diagnostics;
class Program
{
    public static void Main(string[] args)
    {
        var cultureInfo = new CultureInfo("fi-FI");
        var path = @"C:\Users\Jere\Programming\viikko2\Miniprojekti\CourseData_20180901_210145.csv";
        var virhePath = @"C:\Users\Jere\Programming\viikko2\Miniprojekti\loki.txt";
        File.Delete(virhePath);
        using (var reader = new StreamReader(path))
        {
            List<Tiedostokuvaus.Tiedostokuvaus> listA = new List<Tiedostokuvaus.Tiedostokuvaus>();
            var index = 0;
            string headerLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Split(';');

                Tiedostokuvaus.Tiedostokuvaus rivi = new Tiedostokuvaus.Tiedostokuvaus();
                rivi.CourseCode = Convert.ToInt32(line[0]);
                rivi.Name = line[1];
                rivi.StartDate = DateTime.Parse(line[2], cultureInfo);
                rivi.EndDate = DateTime.Parse(line[3], cultureInfo);
                rivi.Location = line[4];
                rivi.MaterialType = line[5];
                rivi.Description = line[6];
                try
                {
                    rivi.MatCode = Convert.ToBoolean(line[7]);
                }
                catch (System.FormatException)
                {
                    Debug.WriteLine(line[7]);
                    Tiedostokuvaus.Tiedostokuvaus.KirjoitaVirhe(virhePath, index + 1, "MatCode", "System.FormatException");
                }
                //rivi.MainCategory = line[8];
                //rivi.SubCategory1 = line[9];
                //try
                //{
                //    rivi.SubCategory2 = line[10];
                //}
                //catch (System.IndexOutOfRangeException) { continue; }
                listA.Add(rivi);
                index++;
                Console.WriteLine(line);
            }
        }
        Console.WriteLine("Finished!");
    }

}


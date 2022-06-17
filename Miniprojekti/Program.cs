// See https://aka.ms/new-console-template for more information
using System.IO;
using Tiedostokuvaus;
using System.Linq;
using System.Reflection;
using System.Globalization;
class Program
{
    public static void Main(string[] args)
    {
        var cultureInfo = new CultureInfo("fi-FI");
        var path = @"C:\Users\Jere\Programming\viikko2\Miniprojekti\CourseData_20180901_210145.csv";
        var stringOfProps = "CourseCode, Name, StartDate, EndDate, Location, MaterialType,"
            + "Description, MatCode, MainCategory, SubCategory1, SubCategory2";
        var listOfProps = stringOfProps.Split(',');
        using (var reader = new StreamReader(path))
        {
            List<Tiedostokuvaus.Tiedostokuvaus> listA = new List<Tiedostokuvaus.Tiedostokuvaus>();
            var index = 0;
            while (!reader.EndOfStream)
            {
                string headerLine = reader.ReadLine();
                var line = reader.ReadLine().Split(';');
                Tiedostokuvaus.Tiedostokuvaus rivi = new Tiedostokuvaus.Tiedostokuvaus();
                rivi.CourseCode = Convert.ToInt32(line[0]);
                rivi.Name = line[1];
                rivi.StartDate = DateTime.Parse(line[2], cultureInfo);
                rivi.EndDate = DateTime.Parse(line[3], cultureInfo);
                rivi.Location = line[4];
                //rivi.MaterialType = Convert.ToBoolean(line[5]); //logiikka, sähköinen = True, paperi=false
                rivi.Description = line[6];
                try
                {
                    rivi.MatCode = Convert.ToBoolean(line[7]);
                }
                catch (System.FormatException) { continue; }
                rivi.MainCategory = line[8];
                rivi.SubCategory1 = line[9];
                try
                {
                    rivi.SubCategory2 = line[10];
                }
                catch (System.IndexOutOfRangeException) { continue; }
                listA.Add(rivi);
                index++;
                Console.WriteLine(line);
            }
        }
    }
}
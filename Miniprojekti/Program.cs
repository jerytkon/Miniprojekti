// See https://aka.ms/new-console-template for more information
using System.IO;
using Tiedostokuvaus;
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
        Console.WriteLine("stoppaa");
        Tiedostokuvaus.Tiedostokuvaus.TarkistaCSVTiedosta(path, virhePath, cultureInfo);
        Console.WriteLine("Finished!");
    }


}


// See https://aka.ms/new-console-template for more information
using System.IO;
var path = @"C:\Users\Jere\Programming\viikko2\Miniprojekti\CourseData_20180901_210145.csv";
using (var reader = new StreamReader(path))
{
    List<string[]> listA = new List<string[]>();
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine().Split(';') ;
        Console.WriteLine(line[0]);
    }
}
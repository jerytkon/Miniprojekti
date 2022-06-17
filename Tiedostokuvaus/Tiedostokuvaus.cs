using System.Globalization;
namespace Tiedostokuvaus
{
    public class Tiedostokuvaus
    {
        public int CourseCode { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string MaterialType { get; set; }
        public string Description { get; set; }
        public bool MatCode { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory1 { get; set; }
        public string SubCategory2 { get; set; }
        public Tiedostokuvaus()
        {

        }
        public Tiedostokuvaus(int courseCode, string name, DateTime startDate, DateTime endDate, string location, string materialType, string description, bool matCode, string mainCategory, string subCategory1, string subCategory2)
        {
            CourseCode = courseCode;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            MaterialType = materialType;
            Description = description;
            MatCode = matCode;
            MainCategory = mainCategory;
            SubCategory1 = subCategory1;
            SubCategory2 = subCategory2;
        }


        public static void KirjoitaVirhe(string path, int riviNumero, string kenttäNimi, string selite)
        {
            if (!File.Exists(path))
            {
                using (var fileStream = new FileStream(String.Format(path), FileMode.OpenOrCreate))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(String.Format("{0};{1};{2}", riviNumero, kenttäNimi, selite));
                }
            }
            else
            {
                using (var fileStream = new FileStream(String.Format(path), FileMode.Append))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(String.Format("{0};{1};{2}", riviNumero, kenttäNimi, selite));
                }
            }

        }

        public static bool Tarkistukset(string[] line, int index, string virhePath)
        {
            if (line.Length < 9)
            {
                Console.WriteLine("mikset tee tätä");
                KirjoitaVirhe(virhePath, index + 1, "Category", "Kategoria puuttuu.");
                return false;
            }
            if (line[6].Length > 500)
            {
                Console.WriteLine("mikset tee tätä");
                KirjoitaVirhe(virhePath, index + 1, "Description", "Liian pitkä.");
                return false;
            }
            return true;
        }

        public static void TarkistaCSVTiedosta(string path, string virhePath, CultureInfo cultureInfo)
        {
            using (var reader = new StreamReader(path))
            {
                List<Tiedostokuvaus> listA = new List<Tiedostokuvaus>();
                var index = 0;
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(';');
                    if (Tarkistukset(line, index, virhePath) == false)
                    {
                        continue;
                    }
                    Tiedostokuvaus rivi = new Tiedostokuvaus();
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
                        KirjoitaVirhe(virhePath, index + 1, "MatCode", "System.FormatException");
                    }
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

}
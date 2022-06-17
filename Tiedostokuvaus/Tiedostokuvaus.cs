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

    }

}
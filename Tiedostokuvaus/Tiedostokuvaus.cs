namespace Tiedostokuvaus
{
    public class Tiedostokuvaus
    {
        public int CourseCode { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public bool MaterialType { get; set; }
        public string Description { get; set; }
        public bool MatCode { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory1 { get; set; }
        public string SubCategory2 { get; set; }
        public Tiedostokuvaus()
        {

        }
        public Tiedostokuvaus(int courseCode, string name, DateTime startDate, DateTime endDate, string location, bool materialType, string description, bool matCode, string mainCategory, string subCategory1, string subCategory2)
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




    }
}
using static RESTStaticListTemplate.Controllers.SLTempsController;

namespace RESTStaticListTemplate
{
    public class SLTemp
    {
        // Propertis og Data field
        // Mine Propertis har to auto accessors get og set som man også kan kalde read-write property
        // Get = skal returnerne
        // Set = Mener om en metod som returtype er void
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Parameterized Constructor
        //Har ingen returtype
        //Dem der er i() hedder Arguments
        public SLTemp(string firstName, string lastName)
        {
            Id = nextId++;
            FirstName = firstName;
            LastName = lastName;
        }

        // Tøm constructor
        public SLTemp() { }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
        }
    }
}

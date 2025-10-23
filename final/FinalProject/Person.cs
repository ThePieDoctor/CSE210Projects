namespace LibraryManagementSystem.Models
{
    public abstract class Person
    {

        public string Name { get; set; }
        public string ID { get; set; }

        public Person()
        {
            Name = "Default";
            ID = "Default";
        }
        
        public Person(string name, string id)
        {
            Name = name;
            ID = id;
        }

        public string GetID()
        {
            return ID;
        }

        public abstract string GetDetailsString();
    }
}


namespace ExampleAdapterPattern
{
    public class Example
    {
        public static void Main()
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Using of pattern Adapter");

            var domainPerson = new Person("John", "Doe");
            var personModel = new PersonModelAdapter(domainPerson);

            Console.WriteLine(personModel.FullName);
        }
    }

    public class Person
    {
        public string FirstName { get; private set; }  
        public string LastName {get;private set;}

        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }

    public interface IPersonModel {
        string FullName {get;}
    }

    public class PersonModelAdapter : IPersonModel
    {
        public string FullName {get; private set;}
        public PersonModelAdapter(Person person)
        {
           this.FullName = $"{person.FirstName} {person.LastName}";
        }
    }
}


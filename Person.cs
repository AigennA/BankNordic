public class Person
{
    public string Name { get; }
    public string PersonalNumber { get; }

    public Person(string name, string personalNumber) // Constructor to initialize properties
    {
        Name = name;
        PersonalNumber = personalNumber;
    }
}
using System;

namespace ToDoListWebApp.Models
{
    public class Person
    {
        // 1) Deklarera de privata fält som krävs för klassen. Privata fält för att lagra data.
        private readonly int id; // Unikt ID för varje person, readonly så det bara kan sättas via konstruktorn och ska inte kunna ändras efter konstruktion.
        private string firstName; // Förnamn för personen
        private string lastName;  // Efternamn för personen

        // 2) Implementera en konstruktor för att skapa ett Person-objekt med ett unikt ID, förnamn och efternamn
        public Person(int id, string firstName, string lastName)
        {
            this.id = id; // Tilldelar det angivna id-värdet till det readonly fältet
            FirstName = firstName; // Använder egenskapen för att tilldela och validera förnamnet
            LastName = lastName; // Använder egenskapen för att tilldela och validera efternamnet
        }

        // 3) Egenskap för att hämta värdet av id alltså hantera data för Id, FirstName och LastName
        public int Id
        {
            get { return id; } // Returnerar värdet av det readonly fältet id
        }

        // 4-1) Egenskap för att hämta och sätta förnamn, med validering för att förhindra null eller tomma strängar
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // Validerar att värdet inte är null eller tomt
                    throw new ArgumentException("First name cannot be null or empty.");
                firstName = value; // Tilldelar värdet om det är giltigt
            }
        }

        // 4-2) Egenskap för att hämta och sätta efternamn, med samma validering som för förnamn
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // Validerar att värdet inte är null eller tomt
                    throw new ArgumentException("Last name cannot be null or empty.");
                lastName = value; // Tilldelar värdet om det är giltigt
            }
        }
    }
}

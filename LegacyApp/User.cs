using System;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }


        private User(Client client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;

            HasCreditLimit = (client.Type != "VeryImportantClient");
            
            CalculateCreditLimit(new UserCreditService());
        }

        public static User MakeNewUser(Client client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                !IsValidEmail(emailAddress) || 
                !Is21YearsOld(dateOfBirth))
            {
                return null;
            }

            var user = new User(client, dateOfBirth, emailAddress, firstName, lastName);
            user.CalculateCreditLimit(new UserCreditService());

            return user;
        }
        
        
        private static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private static bool Is21YearsOld(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age >= 21;
        }
        

        private void CalculateCreditLimit(UserCreditService userCreditService)
        {
            if (!HasCreditLimit) return;
            
            
            var creditLimit = userCreditService.GetCreditLimit(this.LastName, this.DateOfBirth);
            if (Client.Type == "ImportantClient")
            {
                creditLimit *= 2;
            }

            this.CreditLimit = creditLimit;
        }
    }
}
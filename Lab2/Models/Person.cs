namespace Lab2.Models
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime? BirthDate { get; }

        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;

            CalculateProperties();
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, string.Empty, birthDate) { }

        private void CalculateProperties()
        {
            if (BirthDate.HasValue)
            {
                int age = DateTime.Today.Year - BirthDate.Value.Year;
                if (BirthDate.Value.Date > DateTime.Today.AddYears(-age))
                    age--;

                IsAdult = age >= 18;
                IsBirthday = BirthDate.Value.Day == DateTime.Today.Day && BirthDate.Value.Month == DateTime.Today.Month;

                SunSign = ZodiacHelper.GetWesternZodiac(BirthDate.Value);
                ChineseSign = ZodiacHelper.GetChineseZodiac(BirthDate.Value.Year);
            }
        }
    }
}

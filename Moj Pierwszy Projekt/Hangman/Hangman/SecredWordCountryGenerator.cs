using System;

namespace Hangman
{
    class SecredWordCountryGenerator
    {
        public CountryWithCapitalCity GetSecredWord()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\data\countries_and_capitals.txt");
            Random random = new Random();
            int randomRowNumber = random.Next(lines.Length);
            string CountryAndCapital = lines[randomRowNumber];
            string[] CountryAndCapitalsplit = CountryAndCapital.Split("|");
            string Country = CountryAndCapitalsplit[0].Trim();
            string Capital = CountryAndCapitalsplit[1].Trim();

            CountryWithCapitalCity countryWithCapitalCity = new CountryWithCapitalCity();
            countryWithCapitalCity.Country = Country;
            countryWithCapitalCity.CapitalCity = Capital;

            return countryWithCapitalCity;
        }
    }

    class CountryWithCapitalCity
    {
        public string CapitalCity;
        public string Country;
    }
}

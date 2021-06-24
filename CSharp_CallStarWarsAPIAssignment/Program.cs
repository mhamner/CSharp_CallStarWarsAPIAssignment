using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_CallStarWarsAPIAssignment.Models;
using CSharp_CallStarWarsAPIAssignment.BusinessLogic;

namespace CSharp_CallStarWarsAPIAssignment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Calls our Star Wars WebAPI methods based on user selection
            bool keepGoing = true;

            //Initialize our http client to get ready for our API call
            ApiHelper.InitializeClient();

            while (keepGoing)
            {
                Console.WriteLine("** MAIN MENU **");
                Console.WriteLine("Please choose an API method to call.");
                Console.WriteLine("[1]  Get a list of all Star Wars character information");
                Console.WriteLine("[2]  Get a Star Wars character's information by their name");
                Console.WriteLine("[3]  Get a list of Star Wars character information by allegiance");
                Console.WriteLine("[4]  Get a list of Star Wars character information by trilogy");
                Console.WriteLine("");
                Console.Write("Your choice?  ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RunGetAllCharactersAPI();
                        break;
                    case "2":
                        await RunGetCharacterInfoByNameAPI();
                        break;
                    case "3":
                        await RunGetAllCharactersByAllegianceAPI();
                        break;
                    case "4":
                        await RunGetAllCharactersByTrilogyAPI();
                        break;
                    default:
                        Console.WriteLine($"{choice} is not a valid option.");
                        break;
                }

                Console.Write("Do another [Y/N]?  ");
                keepGoing = (Console.ReadLine().ToLower() == "y") ? true : false;
            }
        }

        private static async Task RunGetAllCharactersAPI()
        {
            CharacterBL characterBL = new CharacterBL();
            List<StarWarsCharacterModel> characters = await characterBL.GetListOfAllCharacterInfo();
            
            WriteCharacterInfoToConsole(characters);
        }

        private static async Task RunGetCharacterInfoByNameAPI()
        {
            Console.Write("What is the name of the character?  ");
            string name = Console.ReadLine();

            CharacterBL characterBL = new CharacterBL();
            StarWarsCharacterModel character = await characterBL.GetCharacterInfoByName(name);

            WriteCharacterInfoToConsole(character);
        }

        private static async Task RunGetAllCharactersByAllegianceAPI()
        {
            Console.Write("What is the allegiance of the characters?  ");
            string allegiance = Console.ReadLine();

            CharacterBL characterBL = new CharacterBL();
            List<StarWarsCharacterModel> characters = await characterBL.GetListOfCharacterInfoByAllegiance(allegiance);

            WriteCharacterInfoToConsole(characters);
        }

        private static async Task RunGetAllCharactersByTrilogyAPI()
        {
            Console.Write("What is the trilogy of the characters?  ");
            string trilogy = Console.ReadLine();

            CharacterBL characterBL = new CharacterBL();
            List<StarWarsCharacterModel> characters = await characterBL.GetListOfCharacterInfoByTrilogy(trilogy);

            WriteCharacterInfoToConsole(characters);
        }

        private static void WriteCharacterInfoToConsole(List<StarWarsCharacterModel> characters)
        {
            foreach (StarWarsCharacterModel character in characters)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Name:  {character.Name}");
                Console.WriteLine($"Allegiance:  {character.Allegiance}");
                Console.WriteLine($"Trilogy when Introduced:  {character.IntroducedInTrilogy}");
                Console.WriteLine($"Is a Jedi:  {character.IsJedi}");
                Console.WriteLine("----------------------------------------");
            }
        }

        private static void WriteCharacterInfoToConsole(StarWarsCharacterModel character)
        {          
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Name:  {character.Name}");
            Console.WriteLine($"Allegiance:  {character.Allegiance}");
            Console.WriteLine($"Trilogy when Introduced:  {character.IntroducedInTrilogy}");
            Console.WriteLine($"Is a Jedi:  {character.IsJedi}");
            Console.WriteLine("----------------------------------------");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAndFilm
{
    class Program2
    {
        static void Main(string[] args)
        {
            int c;
            do
            {
                Console.WriteLine("***** List Game and Film*****\n");
                Console.WriteLine("1. Add new Game");
                Console.WriteLine("2. Add new Film");
                Console.WriteLine("3. Print list game");
                Console.WriteLine("4. Print list Film");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter the Number:\n");
                c = Console.Read();
                switch (c)
                {
                    case '1':
                        Console.WriteLine("Enter the Game name:");
                        string n1 = Console.ReadLine();
                        Console.WriteLine("Game production site:");
                        string m1 = Console.ReadLine();
                        Console.WriteLine("year of game production:");
                        int y1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Type of game:");
                        string t1 = Console.ReadLine();
                        GameCollection myGame = new GameCollection();
                        myGame.addGame(new Game(n1, m1, y1, t1));
                        break;
                    case '2':
                        Console.WriteLine("Enter the Film name:");
                        string n2 = Console.ReadLine();
                        Console.WriteLine("Film production site:");
                        string m2 = Console.ReadLine();
                        Console.WriteLine("year of Film production:");
                        int y2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Type of Film:");
                        string t2 = Console.ReadLine();
                        FilmCollection myFilm = new FilmCollection();
                        myFilm.addFilm(new Film(n2, m2, y2, t2));
                        break;
                    case '3':
                        UseGameCollection();
                        break;
                    case '4':
                        UseFilmCollection();
                        break;
                }
                while (c == 5) ;
                Console.ReadLine();
            }
        }

        static void UseGameCollection()
        {
            GameCollection myGame = new GameCollection();
            foreach (Game p1 in myGame)
                Console.WriteLine(p1);
        }

        static void UseFilmCollection()
        {
            FilmCollection myFilm = new FilmCollection();
            foreach (Film p2 in myFilm)
                Console.WriteLine(p2);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAndFilm
{
    class GameCollection : IEnumerable
    {
        private ArrayList arGame = new ArrayList();

        public Game GetGame(int pos1) => (Game)arGame[pos1];

        public void addGame(Game g)
        {
            arGame.Add(g);
        }

        public void ClearGame()
        {
            arGame.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator() => arGame.GetEnumerator();
    }

    class FilmCollection : IEnumerable
    {
        private ArrayList arFilm = new ArrayList();

        public Film GetFilm(int pos2) => (Film)arFilm[pos2];

        public void addFilm(Film f)
        {
            arFilm.Add(f);
        }

        public void ClearFilm()
        {
            arFilm.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator() => arFilm.GetEnumerator();
    }
}
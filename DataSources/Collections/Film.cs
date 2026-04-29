using System;
using System.Collections.Generic;
using System.Text;

namespace DataSources.Collections
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Année { get; set; }

        public Film(int id, string titre, int année)
        {
            Id = id;
            Titre = titre;
            Année = année;
        }
    }
}
using System;

namespace BibliothequeApp
{
    public class Livre : Document
    {
        public int NombrePages { get; set; }

        public Livre(Guid id, string titre, string auteur, int annee, int nombrePages)
            : base(id, titre, auteur, annee)
        {
            NombrePages = nombrePages;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine("LIVRE : " + Titre + " - " + Auteur + " (" + Annee + ") | Pages : " + NombrePages);
        }
    }
}

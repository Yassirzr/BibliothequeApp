using System;

namespace BibliothequeApp
{
    public abstract class Document
    {
        public Guid Id { get; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int Annee { get; set; }

        public Document(Guid id, string titre, string auteur, int annee)
        {
            Id = id;
            Titre = titre;
            Auteur = auteur;
            Annee = annee;
        }

        public abstract void AfficherDetails();
    }
}

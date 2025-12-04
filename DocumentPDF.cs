using System;

namespace BibliothequeApp
{
    public class DocumentPDF : Document
    {
        public double TailleEnMo { get; set; }

        public DocumentPDF(Guid id, string titre, string auteur, int annee, double tailleEnMo)
            : base(id, titre, auteur, annee)
        {
            TailleEnMo = tailleEnMo;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine("PDF : " + Titre + " - " + Auteur + " (" + Annee + ") | Taille : " + TailleEnMo + " Mo");
        }
    }
}

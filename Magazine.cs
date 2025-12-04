using System;

namespace BibliothequeApp
{
    public class Magazine : Document
    {
        public int Numero { get; set; }

        public Magazine(Guid id, string titre, string auteur, int annee, int numero)
            : base(id, titre, auteur, annee)
        {
            Numero = numero;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine("MAGAZINE : " + Titre + " - " + Auteur + " (" + Annee + ") | Numéro : " + Numero);
        }
    }
}

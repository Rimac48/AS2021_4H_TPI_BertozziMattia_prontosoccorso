using AS2021_4H_TPI_BertozziMattia_prontosoccorso.Models;
using System;

namespace AS2021_4H_TPI_BertozziMattia_prontosoccorso
{
    class Program
    {
        static void Main(string[] args)
        {
            ProntoSoccorso prontoSoccorso = new ProntoSoccorso();

            prontoSoccorso.InserisciPaziente("Prova", "Prova", "prprprprprr", "Rosso", Convert.ToDateTime("2/1/2021"));
            Console.WriteLine(prontoSoccorso.ListaPazientiColore("Rosso"));
            try
            {
                Console.WriteLine(prontoSoccorso.RecuperoPaziente("prprprprprr"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            prontoSoccorso.SalvataggioDati();
            prontoSoccorso.EliminazionePaziente("prprprprprr");
            prontoSoccorso.SalvataggioDati();

            // Console.WriteLine("Esito salvataggio: " + prontoSoccorso.SalvataggioDati());
            // Console.WriteLine(prontoSoccorso.EliminazionePaziente("prprprprprr"));
            // Console.WriteLine("Esito salvataggio: " + prontoSoccorso.SalvataggioDati());

        }
    }
}

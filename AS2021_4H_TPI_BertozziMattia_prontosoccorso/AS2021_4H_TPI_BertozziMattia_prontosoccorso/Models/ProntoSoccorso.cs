using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AS2021_4H_TPI_BertozziMattia_prontosoccorso.Models
{
    class ProntoSoccorso
    {
        List<Paziente> _pazienti = new List<Paziente>();

        public ProntoSoccorso()
        {
            _pazienti = new List<Paziente>
            {
                new Paziente("Luca", "Rossi", Convert.ToDateTime("12/03/2000"), "RSSLCU12C00H294Q", "Giallo"),
                new Paziente("Surry", "WasTaken", Convert.ToDateTime("19/12/1995"), "WSTARR19J95H294T", "Giallo"),
                new Paziente("Liam", "Bartolini", Convert.ToDateTime("29/01/2003"), "BRTLMI29A03H294W", "Bianco"),
                new Paziente("Nando", "Angela", Convert.ToDateTime("23/10/2018"), "AGLNDN23H18H294K", "Rosso")
            };
        }

        public void InserisciPaziente(string nome, string cognome, string codiceFiscale, string colore, DateTime dataDiNascita)
        {
            _pazienti.Add(new Paziente(nome, cognome, dataDiNascita, codiceFiscale, colore));
        }

        public Paziente RecuperoPaziente(string codiceFiscale)
        {
            for (int i = 0; i < _pazienti.Count; i++)
                if (_pazienti[i].CodiceFiscale == codiceFiscale)
                    return _pazienti[i];
            
            throw new Exception("Il paziente non è stato trovato!");
        }

        public string ListaPazientiColore(string colore)
        {
            List<Paziente> daOrdinare = new List<Paziente>();
            for (int i = 0; i < _pazienti.Count; i++)
                if (_pazienti[i].Colore == colore)
                    daOrdinare.Add(_pazienti[i]);

            // sort
            for (int i = 0; i < daOrdinare.Count - 1; i++)
            {
                for (int j = i + 1; j < daOrdinare.Count; j++)
                {
                    if (daOrdinare[i]._dataAccettazione.CompareTo(daOrdinare[j]._dataAccettazione) > 0)
                    {
                        var tmp = daOrdinare[j];
                        daOrdinare[j] = daOrdinare[i];
                        daOrdinare[i] = tmp;
                    }
                }
            }

            StringBuilder sb  = new StringBuilder();
            for (int i = 0; i < daOrdinare.Count; i++)
                sb.AppendLine(daOrdinare[i].ToString());

            return sb.ToString();
        }

        public bool EliminazionePaziente(string codiceFiscale)
        {
            for (int i = 0; i < _pazienti.Count; i++)
                if (_pazienti[i].CodiceFiscale == codiceFiscale)
                    {
                        _pazienti[i]._dataDimmissione = DateTime.Now;
                        return true;
                    }

            return false;
        }

        public void SalvataggioDati()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t\t{DateTime.Today:dd/MM/yyyy:HH:mm}");
            for (int i = 0; i < _pazienti.Count; i++)
                sb.AppendLine(_pazienti[i].ToString());

            File.AppendAllText("Dati.txt", sb.ToString());
        }
    }
}
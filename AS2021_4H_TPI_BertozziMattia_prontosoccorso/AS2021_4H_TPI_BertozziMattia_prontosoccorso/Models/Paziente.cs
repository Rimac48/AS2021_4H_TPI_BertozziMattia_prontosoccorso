using System;
using System.Text;

namespace AS2021_4H_TPI_BertozziMattia_prontosoccorso.Models
{
    class Paziente
    {
        string _nome;
        string _cognome;
        DateTime _dataDiNascita;
        string _colore;
        public string Colore { get => _colore; }

        string _codiceFiscale;
        public string CodiceFiscale { get => _codiceFiscale; }
        public DateTime _dataAccettazione;
        public DateTime _dataDimmissione;
    
        public Paziente(string nome, string cognome, DateTime dataDiNascita, string codiceFiscale, string colore)
        {
            _nome = nome;
            _cognome = cognome;
            _dataDiNascita = dataDiNascita;
            _codiceFiscale = codiceFiscale;
            _colore = colore;
            _dataAccettazione = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome:\t\t\t{_nome}");
            sb.AppendLine($"Cognome:\t\t{_cognome}");
            sb.AppendLine($"Data di Nascita:\t{_dataDiNascita:dd/MM/yyyy}");
            sb.AppendLine($"CF:\t\t\t{_codiceFiscale}");
            sb.AppendLine($"Colore:\t\t\t{_colore}");
            sb.AppendLine($"Accettazione:{_dataAccettazione:dd/MM/yyyy:HH:mm}");
            sb.AppendLine($"Dimmissione:{_dataDimmissione:dd/MM/yyyy:HH:mm}\n\t\t\t;");
            
            return sb.ToString();
        }
    }
}
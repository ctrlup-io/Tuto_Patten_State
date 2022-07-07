
//Ce qu'il ne faut jamais faire!!!!
//Nous allons remplacer ça par le pattern STATE
using System.Text.RegularExpressions;


namespace Tuto_Pattern_State
{
    public enum Etat
    {
        Aucun,
        Insere,
        Ejecte,
        ComposePin,
        RetireEspece,
        Interdit
    }

    public class DistributeurAutomatique
    {
        private string _pin = "1234";
        private decimal _soldeCompte = 10000;
        private int _nbEssaisMax = 3;
        private int _nbEssais = 0;

        private bool _carteInseree = false;
        private bool _PinSaisi = false;
        private bool _montantSaisi = false;
        private bool _carteInterdite = false;
        private bool _carteRetiree = false;
        private List<string> _commandes;   

        public DistributeurAutomatique()
        {
            _commandes = new List<string>
            {
                "inserer carte",
                "entrer code pin",
                "entrer montant",
                "retirer carte"
            };
        }

        public void InsereCarte()
        {
            if (_carteInseree)
            {
                Console.WriteLine($"La carte est déjà insérée.{Environment.NewLine}");
            }
            else
            {
                _carteInseree = true;
                Console.WriteLine($"Carte est insérée.{Environment.NewLine}");
            }


        }

        public void Help()
        {
            Console.WriteLine($"Commandes disponibles:{Environment.NewLine}");
            foreach(string s in _commandes) { Console.WriteLine(s); }
            Console.WriteLine();
        }

        public void RAZ()
        {
            _carteInseree = false;
            _PinSaisi = false;
            _montantSaisi = false;
            _carteRetiree = false;
        }

        public void RetireCarte()
        {
            if (!_carteInseree)
            {
                Console.WriteLine($"La carte n'a pas été insérée.{Environment.NewLine}");
                return;
            }

            if (_carteRetiree)
            {
                Console.WriteLine($"La carte est déjà retirée.{Environment.NewLine}");
                return;
            }

            if (_carteInterdite)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return;
            }

            _carteRetiree = true;
            Console.WriteLine($"La carte est retirée.{Environment.NewLine}");
            RAZ();
        }

        public void EntreCodePin()
        {
            if (!_carteInseree)
            {
                Console.WriteLine($"La carte n'a pas été insérée.{Environment.NewLine}");
                return;
            }

            if (_PinSaisi)
            {
                Console.WriteLine($"La code pin est déjà entré.{Environment.NewLine}");
                return;
            }

            if (_carteInterdite)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return;
            }

            Console.WriteLine("Entrez votre code pin:");
            string pinSaisi = Console.ReadLine();
            Console.WriteLine($"Code pin saisi: {pinSaisi}.{Environment.NewLine}");

            if (PinIsOk(pinSaisi))
            {
                _PinSaisi = true;
                Console.WriteLine($"Le code pin est correct.{Environment.NewLine}");
            }

        }

        public void EntreMontant()
        {
            if (!_carteInseree)
            {
                Console.WriteLine($"La carte n'a pas été insérée.{Environment.NewLine}");
                return;
            }

            if (_carteInterdite)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return;
            }

            if (!_PinSaisi)
            {
                Console.WriteLine($"La code pin n'est pas saisi.{Environment.NewLine}");
                return;
            }

            if (_montantSaisi)
            {
                Console.WriteLine($"Le montant a déjà été saisi.{Environment.NewLine}");
                return;
            }

            Console.WriteLine("Entrez le montant souhaité:");
            string demande = Console.ReadLine();

            if (!IsDecimal(demande))
            {
                Console.WriteLine("Vous n'avez pas saisi un montant !");
            }

            decimal montant = decimal.Parse(demande);

            Console.WriteLine($"Montant saisi: {montant}");
            if (montant > 0 && _soldeCompte - montant >= 0)
            {
                _soldeCompte -= montant;
                _montantSaisi = true;
            }
            else
            {
                Console.WriteLine($"Le montant saisi n'est pas autorisé");
            }


        }

        private bool PinIsOk(string pin)
        {
            if (_carteInterdite)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return false;
            }
            _nbEssais++;


            if (pin.ToUpperInvariant() != _pin.ToUpperInvariant())
            {
                if (_nbEssais >= _nbEssaisMax)
                {
                    _carteInterdite = true;
                    Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                    return false;
                }
                Console.WriteLine($"Le code pin est incorrect.{Environment.NewLine}");
                return false;
            }

            _nbEssais = 0;
            return true;
        }

        private bool IsDecimal(string chaine)
        {
            if (string.IsNullOrWhiteSpace(chaine))
            {
                return false;
            }
            Regex regex = new Regex("^[0-9](.[0-9]+)?$");

            return regex.IsMatch(chaine);
        }
    }
}

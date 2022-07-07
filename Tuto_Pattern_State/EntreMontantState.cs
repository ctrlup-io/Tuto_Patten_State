using System.Text.RegularExpressions;

namespace Tuto_Pattern_State
{
    public class EntreMontantState : State
    {
        private static decimal _soldeCompte = 1000;
        public override void ChangeEtat(DistributeurAutomatique context)
        {
            if(context == null) return;

            if (Validate(context))
            {
                context.State = this;
            }
        }

        protected override bool Validate(DistributeurAutomatique context)
        {
            if (context.State is BloqueCarteState)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return false;
            }

            if (context.State is EntreMontantState)
            {
                Console.WriteLine($"Le montant est déjà saisi.{Environment.NewLine}");
                return false;
            }

            if (context.State == null)
            {
                Console.WriteLine($"La carte n'a pas été insérée.{Environment.NewLine}");
                return false;
            }

            if (context.State is not EntreCodePinState)
            {
                Console.WriteLine($"La code pin n'est pas saisi.{Environment.NewLine}");
                return false;
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
                return true;
            }
            else
            {
                Console.WriteLine($"Le montant saisi n'est pas autorisé");
            }
            return false; ;
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

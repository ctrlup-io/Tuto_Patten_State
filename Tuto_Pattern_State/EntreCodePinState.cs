namespace Tuto_Pattern_State
{
    public class EntreCodePinState : State
    {
        private string _pin = "1234";
        private static int _nbEssaisMax = 3;
        private static int _nbEssais = 0;

        public override void ChangeEtat(DistributeurAutomatique context)
        {
            if (context == null) return;
            if (Validate(context))
            {
                context.State = this;
                Console.WriteLine($"Le code pin est correct.{Environment.NewLine}");
            }
        }

        protected override bool Validate(DistributeurAutomatique context)
        {
            if (context.State is BloqueCarteState)
            {
                Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
                return false;
            }

            if (context.State == null)
            {
                Console.WriteLine($"La carte n'a pas été insérée.{Environment.NewLine}");
                return false;
            }

            if(context.State is not InsereCarteState)
            {
                Console.WriteLine($"La code pin est déjà entré.{Environment.NewLine}");
                return false;
            }

            Console.WriteLine("Entrez votre code pin:");
            string pinSaisi = Console.ReadLine();
            Console.WriteLine($"Code pin saisi: {pinSaisi}.{Environment.NewLine}");

            return PinIsOk(pinSaisi, context);
        }

        private bool PinIsOk(string pin, DistributeurAutomatique context)
        {
            _nbEssais++;

            if (pin.ToUpperInvariant() != _pin.ToUpperInvariant())
            {
                if (_nbEssais >= _nbEssaisMax)
                {
                    new BloqueCarteState().ChangeEtat(context);
                    return false;
                }
                Console.WriteLine($"Le code pin est incorrect.{Environment.NewLine}");
                return false;
            }

            _nbEssais = 0;
            return true;
        }       
    }
}

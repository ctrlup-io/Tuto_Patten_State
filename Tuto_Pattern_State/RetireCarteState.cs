namespace Tuto_Pattern_State
{
    public class RetireCarteState : State
    {
        public override void ChangeEtat(DistributeurAutomatique context)
        {
            if(context == null) { return; }

            if (Validate(context))
            {
                context.State = null;
                Console.WriteLine($"La carte est retirée.{Environment.NewLine}");
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

            if (context.State is RetireCarteState)
            {
                Console.WriteLine($"La carte est déjà retirée.{Environment.NewLine}");
                return false;
            }

            return true;
        }
    }
}

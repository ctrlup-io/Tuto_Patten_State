namespace Tuto_Pattern_State
{
    public class InsereCarteState : State
    {
        public override void ChangeEtat(DistributeurAutomatique context)
        {
            if (context == null) { return; }

            if (Validate(context))
            {
                context.State = this;
                Console.WriteLine($"Carte insérée.{Environment.NewLine}");
            }
        }
       

        protected override bool Validate(DistributeurAutomatique context)
        {
            if (context == null)
            {
                return false;
            }

            if (context.State == null)
            {
                return true;
            }

            if(context.State is InsereCarteState)
            {
                Console.WriteLine($"La carte est déjà insérée.{Environment.NewLine}");
            }

            return false;
        }
    }
}

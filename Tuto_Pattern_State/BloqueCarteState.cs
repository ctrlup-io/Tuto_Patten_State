namespace Tuto_Pattern_State
{
    internal class BloqueCarteState : State
    {
        public override void ChangeEtat(DistributeurAutomatique context)
        {
            if (context == null) { return; }

            Validate(context);
            return;
        }

        protected override bool Validate(DistributeurAutomatique context)
        {
            context.State = this;
            Console.WriteLine($"Carte bloquée.{Environment.NewLine}");
            return true;
        }
    }
}

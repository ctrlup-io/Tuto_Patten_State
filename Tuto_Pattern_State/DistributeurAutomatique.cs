namespace Tuto_Pattern_State
{
    public class DistributeurAutomatique
    {
        public IState? State { get; set; } = null;
        private readonly List<string> _commandes;

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
            InsereCarteState state = new();
            state.ChangeEtat(this);

        }

        public void Help()
        {
            Console.WriteLine($"Commandes disponibles:{Environment.NewLine}");
            foreach (string s in _commandes) { Console.WriteLine(s); }
            Console.WriteLine();
        }

        public void RetireCarte()
        {
            RetireCarteState state = new();
            state.ChangeEtat(this);
        }

        public void EntreCodePin()
        {
            EntreCodePinState state = new();
            state.ChangeEtat(this);
        }

        public void EntreMontant()
        {
            EntreMontantState state = new();
            state.ChangeEtat(this);
        }   
    }
}

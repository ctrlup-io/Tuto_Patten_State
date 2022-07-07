using Tuto_Pattern_State;

Console.WriteLine($"Bienvenue sur notre tuto !{Environment.NewLine}");

string commande = string.Empty;
DistributeurAutomatique distributeurAutomatique = new DistributeurAutomatique();
while(commande.ToUpperInvariant() != "TERMINER")
{
    commande = Console.ReadLine();

    switch (commande.ToUpperInvariant().Replace(" ", String.Empty))
    {
        case "INSERERCARTE":
            distributeurAutomatique.InsereCarte();
            break;
        case "ENTRERCODEPIN":
            distributeurAutomatique.EntreCodePin();
            break;
        case "ENTRERMONTANT":
            distributeurAutomatique.EntreMontant();
            break;
        case "RETIRERCARTE":
            distributeurAutomatique.RetireCarte();
            break;
        case "HELP":
            distributeurAutomatique.Help();
            break;
        case "TERMINER":
            break;
        default:
            Console.WriteLine($"Je n'ai pas compris votre demande.{Environment.NewLine}");
            break;
    }
}

Environment.Exit(0);


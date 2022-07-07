# Tuto_Pattern_State
Cette appli console permet d'illustrer de manière très simple l'utilisation du pattern "STATE"

# Il y a deux branches :
  1. La branche master qui implémente le pattern "State"
  2. La branche without-state qui fait exactement la même chose avec des switch et des if
 
## Quel intérêt ?
A première vue le pattern state demande plus de code mais que dire de la maintenabilité du contenu de la branche without ?
Que dire de son évolutivité ?

Et bien l'enjeu est là !

La version "without" n'est que peu maintenable et insérer un nouvel état serait très complexe.

à l'inverse, avec la version "State" nous pouvons très simplement ajouter, supprimer ou modifier autant d'états que l'on souhaite.

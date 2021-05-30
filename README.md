# galactic-hunter

ESSAADOUNI Amine <br>
HAJJI Adham <br>
E4FI

> A bord de votre vaisseau spatial, vous détruirez les météorites avant qu'elles ne touchent la surface de la Terre. Mais faites attention à rattraper les météorites dorées, riches en or.

## Description de notre brique technique

Nous nous sommes proposés d'implémenter la génération procédurale de météorites. Pour ce faire, nous nous sommes inspirés du [tutoriel suivant](https://www.youtube.com/watch?v=QN39W020LqU) pour écrire un algorithme réaliste, qui suit les étapes suivantes :

1. On crée un plan composé d'arrêtes et de triangles.
2. On forme un cube à partir de six plans qui auront chacun une normale différente.
3. On normalise les points du cube pour obtenir une sphère.
4. On génère un bruit à partir de [cette implémentation](https://github.com/SebLague/Procedural-Planets/blob/master/Procedural%20Planet%20Noise/Noise.cs).
5. Avec ce bruit, on déforme chaque arrête de notre objet en appliquant ce bruit plusieurs fois pour obtenir un résultat réaliste.

## Autres fonctionnalités

- Nous avons limité la zone où le vaisseau peut circuler à travers le script `WorldBoundaries.cs`.
- Nous avons utilisé un asset pour obtenir un contrôle plus réaliste du vaisseau.
- Nous avons utilisé un asset pour notre vaisseau spatial, qui a l'avantage de faire apparaître la combustion des réacteurs.
- Nous avons ajouté du son, un fond et la rotation de la Terre pour obtenir une atmosphère agréable.
- Nous générons aléatoirement les météorites en faisant attention à les faire apparaître du côté du vaisseau pour les rendre accessibles.

## Pistes d'amélioration

- Ecriture d'un shader pour générer des textures aléatoires de météorites.
- Pouvoir détruire les météorites en faisant apparaître un effet d'explosion.
- Pouvoir gagner / perdre dans le jeu.
- Faire tourner les météorites sur elles-même.
- Implémenter les _fameuses_ météorites dorées.

**La suite pour une prochaine fois peut-être :grin:**

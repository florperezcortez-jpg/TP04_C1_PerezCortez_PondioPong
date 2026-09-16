# PondioPong

A 2-player Pong game with physics-based movement, made in Unity 6 for the Programming with Game Engines I course (Tecnicatura Superior en Programación de Videojuegos, Image Campus).

## Author
Florencia Perez Cortez

## Course
Programación con Motores de Videojuegos I — Image Campus
Instructor: Federico Olivé

## How to Play
- **Player 1**: Move with `W` / `A` / `S` / `D`
- **Player 2**: Move with the `Arrow Keys`
- First to 3 points wins the match.
- If no goal is scored within 20 seconds, the player holding the ball on their side automatically concedes a point.

## Features
- Physics-based movement (Rigidbody2D + AddForce) for players and ball
- ScriptableObject-based game settings (points to win, goal time limit)
- Dynamic paddle color changes (black on wall hit, random on ball hit)
- Random obstacle spawning using the Object Pool pattern

## Play it online
🎮 [Play on itch.io](https://florperezcortez-jpg.itch.io/pondiopong)

## Credits
- Cyberpunk GUI Pack
- Kenney (kenney.nl)
- Assets provided by Prof. Héctor

## Built with
Unity 6000.3.11f1

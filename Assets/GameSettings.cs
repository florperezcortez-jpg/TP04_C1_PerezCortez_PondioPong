using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Reglas del partido")]
    public int pointsToWin = 3;     //que gane el mejor de 5

    [Header("Tiempo por gol")]
    public float goalTimeLimit = 20f; //segundos antes del gol automatico
}

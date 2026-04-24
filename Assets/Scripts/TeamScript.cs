using UnityEngine;
public enum Team
    {
        White,
        Black
    }
public class TeamScript : MonoBehaviour
{
    

    public abstract class Piece : MonoBehaviour
    {
        public Team team; // Set this in the Inspector or during spawning
        public int currentX;
        public int currentY;

        // This method will be overridden by each piece type
        public abstract bool[,] GetPossibleMoves(Piece[,] board, int tileCountX, int tileCountY);
    }
}

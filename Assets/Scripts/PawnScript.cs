using System.Collections.Generic;
using UnityEngine;

public class PawnScript : Piece
{
    

    public List<Vector2Int> GetAvailableMoves(ref Piece[,] board, int tileCount)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        
        // Direction depends on the team (White moves up +1, Black moves down -1)
        int direction = (team == Team.White) ? 1 : -1;

        // 1. Move forward one tile
        if (board[currentX, currentY + direction] == null)
        {
            r.Add(new Vector2Int(currentX, currentY + direction));

            // 2. Move forward two tiles (only on first move)
            if (team == Team.White && currentY == 1 && board[currentX, currentY + (direction * 2)] == null)
                r.Add(new Vector2Int(currentX, currentY + (direction * 2)));

            if (team == Team.Black && currentY == 6 && board[currentX, currentY + (direction * 2)] == null)
                r.Add(new Vector2Int(currentX, currentY + (direction * 2)));
        }

        // 3. Diagonal Capture (Left)
        if (currentX > 0)
        {
            ChessPiece leftDiagonal = board[currentX - 1, currentY + direction];
            if (leftDiagonal != null && leftDiagonal.team != team)
                r.Add(new Vector2Int(currentX - 1, currentY + direction));
        }

        // 4. Diagonal Capture (Right)
        if (currentX < tileCount - 1)
        {
            ChessPiece rightDiagonal = board[currentX + 1, currentY + direction];
            if (rightDiagonal != null && rightDiagonal.team != team)
                r.Add(new Vector2Int(currentX + 1, currentY + direction));
        }

        return r;
    }
}

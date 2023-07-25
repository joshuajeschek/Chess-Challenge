using ChessChallenge.API;

public class MyBot : IChessBot
{
    private readonly int[] _pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        int bestScore = 0;
        Move bestMove = moves[0];
        foreach (Move move in moves)
        {
            int moveScore = ComputeMoveScore(board, move, 1);
            if (moveScore > bestScore)
            {
                bestScore = moveScore;
                bestMove = move;
            }
        }
        return bestMove;
    }

    int ComputeMoveScore(Board board, Move move, int depth)
    {
        Piece captured = board.GetPiece(move.TargetSquare);
        int score = (_pieceValues[(int)captured.PieceType] * (1 / depth));
        board.MakeMove(move);
        score = board.IsInCheckmate() ? Int32.MaxValue : score;
        board.UndoMove(move);
        return score;
    }
}

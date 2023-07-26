using ChessChallenge.API;
using System;
using static ChessChallenge.Application.ConsoleHelper;

public class MyBot : IChessBot
{

    private int[] _pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        Move bestMove = Move.NullMove;
        int bestScore = Int32.MinValue;
        foreach (Move move in moves) {
          board.MakeMove(move);
          int score = -Evaluate(board);
          board.UndoMove(move);
          if (score > bestScore) {
            bestScore = score;
            bestMove = move;
          }
        }
        return bestMove;
    }

    private int Evaluate(Board board)
    {
      if (board.IsInCheckmate()) {
        return Int32.MinValue;
      }
      if (board.IsInCheck()) {
        return Int32.MinValue / 2;
      }
      if (board.IsRepeatedPosition()) {
        return Int32.MinValue / 4;
      }
      if (board.IsDraw()) {
        return 0;
      }
      int score = board.GetLegalMoves().Length;
      /* int score = 0; */
      foreach(PieceList list in board.GetAllPieceLists()) {
          score += list.IsWhitePieceList==board.IsWhiteToMove ? _pieceValues[(int)list.TypeOfPieceInList] : 0;
      }
      return score;
    }
}

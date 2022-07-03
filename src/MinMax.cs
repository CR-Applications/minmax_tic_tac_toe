using System;

public static class MinMax
{
    static int evaluate(Board board)
    {
        Mark winnner = board.currentWinner();
        if(winnner == Mark.X)
        {
            return 10;
        }
        if(winnner == Mark.O)
        {
            return -10;
        }
        return 0;
    }
    public static int minMax(Board board, int depth, bool isMax)
    {
        // 10 max wins, -10 min wins, 0 draw
        int score = evaluate(board);

        // if maximizer won 
        if(score == 10) 
        {
            return score;
        }
        // if minmizer won
        if(score == -10)
        {
            return score;
        }

        // if no more moves and no more winner
        // draw
        if(board.movesLeft() == false)
        {
            return 0; // draw
        }
        if(depth <= 0)
        {
            return score;
        }
        // if maximizer is trying to move
        if(isMax)
        {
            int best = int.MinValue;

            // travers all cells
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    // cell is empty
                    if(board.getAtPlace(i,j) == Mark.None)
                    {
                        // make move
                        board.setMove(i,j,Mark.X);
                        // call min max recursivly
                        best = Math.Max(best,minMax(board,depth-1,!isMax));

                        // undo move
                        board.setMove(i,j,Mark.None);
                    }
                }
            }
            return best;
        }
        // if minimizer is trying to move
        else
        {
            int best = int.MaxValue;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                     // cell is empty
                    if(board.getAtPlace(i,j) == Mark.None)
                    {
                        board.setMove(i,j,Mark.O);
                        best = Math.Min(best,minMax(board,depth-1,!isMax));
                        board.setMove(i,j,Mark.None);
                    }
                }
            }
            return best;

        }
    }

    public static Move findBestMove(Board board, Mark player, Dificulty d)
    {
        int bestValue = player==Mark.X? int.MinValue: int.MaxValue;
        Move bestMove = new Move();
        bestMove.row = -1;
        bestMove.col = -1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // Check if cell is empty
                if(board.getAtPlace(i,j) == Mark.None)
                {
                    // make move
                    board.setMove(i,j,player);

                    // compute evaluation for this move
                    int moveVal = minMax(board,(int)d,player==Mark.X? false:true);
                    board.setMove(i,j,Mark.None);

                    // If the value of the current move is
                    // more than the best value, then update
                    // best/
                    if(player == Mark.X)
                    {
                        if (moveVal > bestValue)
                        {
                            bestMove.row = i;
                            bestMove.col = j;
                            bestValue = moveVal;
                        }
                    }
                    else
                    {
                        if (moveVal < bestValue)
                        {
                            bestMove.row = i;
                            bestMove.col = j;
                            bestValue = moveVal;
                        }
                    }
                    
                }
            }
        }
    Console.Write("The value of the best Move " + "is : {0}\n\n", bestValue);
 
    return bestMove;

    }
}


public struct Move{
    public int col;
    public int row;
}
public enum Dificulty
{
    hard = int.MaxValue,
    medium = 2,
    easy = 1
}
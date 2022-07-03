using System;


public class Board
{
    private Mark[,] boardData;

    public Board()
    {
       initBoardData(); // initilize the array

    }

    private void initBoardData()
    {
        boardData = new Mark[3,3];

        for(int i =0; i < 3; i++)
        {
            for(int j = 0; j< 3; j++)
            {
                boardData[i,j] = Mark.None;
            }

        }
    }

    public Mark getAtPlace(int row, int col)
    {
        return boardData[row,col];
    }
    public void setMove(int row, int col, Mark m)
    {
        // m is the player that made the move so what gets stored
        boardData[row,col] = m;
    }

    public Mark currentWinner()
    {
        // curretn winner returns which one is the winner in the current
        // state of the board
        // if no winner None is returned
        // Checking for Rows for X or O victory.
        for (int row = 0; row < 3; row++)
        {
            if (boardData[row, 0] == boardData[row, 1] && boardData[row, 1] == boardData[row, 2])
            {
                if (boardData[row, 0] == Mark.X)
                    return Mark.X;
                else if (boardData[row, 0] == Mark.O)
                    return Mark.O;
            }
        }
    
        // Checking for Columns for X or O victory.
        for (int col = 0; col < 3; col++)
        {
            if (boardData[0, col] == boardData[1, col] && boardData[1, col] == boardData[2, col])
            {
                if (boardData[0, col] == Mark.X)
                    return Mark.X;
    
                else if (boardData[0, col] == Mark.O)
                    return Mark.O;
            }
        }
    
        // Checking for Diagonals for X or O victory.
        if (boardData[0, 0] == boardData[1, 1] && boardData[1, 1] == boardData[2, 2])
        {
            if (boardData[0, 0] == Mark.X)
                return Mark.X;
            else if (boardData[0, 0] == Mark.O)
                return Mark.O;
        }
    
        if (boardData[0, 2] == boardData[1, 1] && boardData[1, 1] == boardData[2, 0])
        {
            if (boardData[0, 2] == Mark.X)
                return Mark.X;
            else if (boardData[0, 2] == Mark.O)
                return Mark.O;
        }
    
        // Else if none of them have won then return 0
        return Mark.None;
    }

    public bool movesLeft()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(boardData[i,j] == Mark.None)
                {
                    // if any available move or empty spot
                    return true;
                }
            }
        }
        return false;
    }
    public override string ToString()
    {
        string s = "";

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                s = s + boardData[i,j] + ",";
            }
            s = s + "\n";
        }
        return s;


    }

}


// 

public enum Mark
{
    X = 'X',
    O = 'O',
    None = '_'

}
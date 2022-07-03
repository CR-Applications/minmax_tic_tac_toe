using System;
class Driver {

    public static void debugBoard(Board board)
    {
        Console.WriteLine("Debug for board");
        Console.WriteLine(board.getAtPlace(0,0));
        Console.WriteLine(board.ToString());
        Console.WriteLine("Current winner is: " + board.currentWinner());

        board.setMove(0,1,Mark.X);
        board.setMove(0,0,Mark.O);
        
        board.setMove(1,0,Mark.X);
        // board.setMove(1,0,Mark.X);
        // board.setMove(1,1,Mark.X);
        // board.setMove(1,2,Mark.O);

        Console.WriteLine(board.ToString());
        Console.WriteLine("Current winner is: " + board.currentWinner());

        // board.setMove(0,0,Mark.O);
        // board.setMove(1,2,Mark.O);
        // board.setMove(2,1,Mark.O);

        // Console.WriteLine(board.ToString());
        // Console.WriteLine("Current winner is: " + board.currentWinner());

    }
    static void Main() {
        Console.WriteLine("Min max debug output");

        Board board = new Board();
        debugBoard(board);
        Move m = MinMax.findBestMove(board,Mark.O,Dificulty.hard);
        Console.WriteLine("Best move on empty board " + m.row + " " + m.col);



        
    }
}
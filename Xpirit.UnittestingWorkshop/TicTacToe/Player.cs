using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public Player(string name, char mark)
        {
            Name = name;
            Mark = mark;
        }

        public int NumberOfMoves { get; private set; }

        public string Name { get;}

        public char Mark { get; }

        public void Move()
        {
            NumberOfMoves++;
        }
    }
}

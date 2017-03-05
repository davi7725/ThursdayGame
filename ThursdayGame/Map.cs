using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayGame
{
    public class Map
    {
        public Player[,] MapArray { get; private set; }

        public Map()
        {
            MapArray = new Player[80, 23];
        }

        public void AddPlayerAt(int x, int y, Player player)
        {
            player.posX = x;
            player.posY = y;
            if (MapArray[x, y] == null)
            {
                MapArray[x, y] = player;
            }
            DrawMap();
        }

        public void DrawMap()
        {
            Console.CursorVisible = false;
            char c;
            for (int y = 0; y < 23; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    c = ' ';
                    if (MapArray[x, y] != null)
                    {
                        c = MapArray[x, y].DisplayedChar;
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write(c);
                }
            }
        }


        public void move(int FromX, int FromY, int ToX, int ToY)
        {
            if (MapArray[FromX, FromY] != null && MapArray[ToX, ToY] == null)
            {
                MapArray[ToX, ToY] = MapArray[FromX, FromY];
                MapArray[FromX, FromY] = null;
                Console.SetCursorPosition(FromX, FromY);
                Console.Write(" ");
                Console.SetCursorPosition(ToX, ToY);
                Console.Write(MapArray[ToX, ToY].DisplayedChar);
            }
        }
        public void Attack(int FromX, int FromY, int ToX, int ToY)
        {
            if (MapArray[FromX, FromY] != null && MapArray[ToX, ToY] != null)
            {
                MapArray[ToX, ToY].Hit();
                if (MapArray[ToX, ToY].Live <= 0)
                {
                    MapArray[ToX, ToY] = null;
                    Console.SetCursorPosition(ToX, ToY);
                    Console.Write(" ");
                }
            }
        }

    }

}

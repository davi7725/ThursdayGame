using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThursdayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProg = new Program();
            myProg.Run();
        }
        
        private void Run()
        {
            Player p = new Player("Tom", 'X');
            Map m = new Map();

            m.AddPlayerAt(0, 0, p);

            Enemy e = new Enemy("Jerry", 'O',m,p);

            Thread enemyThread = new Thread(new ThreadStart(e.StartEnemy));
            enemyThread.Start();
            

            bool gameIsRunning = true;

            while(gameIsRunning == true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                switch (input.Key)
                {
                    case ConsoleKey.W:
                        m.move(p.posX, p.posY, p.posX, p.posY - 1);
                        p.posY = p.posY - 1;
                        break;
                    case ConsoleKey.A:
                        m.move(p.posX, p.posY, p.posX-1, p.posY);
                        p.posX= p.posX - 1;
                        break;
                    case ConsoleKey.S:
                        m.move(p.posX, p.posY, p.posX, p.posY + 1);
                        p.posY = p.posY + 1;
                        break;
                    case ConsoleKey.D:
                        m.move(p.posX, p.posY, p.posX + 1, p.posY);
                        p.posX = p.posX + 1;
                        break;
                    case ConsoleKey.Escape:
                        gameIsRunning = false;
                        break;
                }
            }


            Console.ReadKey();
        }
    }
}

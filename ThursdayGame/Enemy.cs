using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThursdayGame
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    class Enemy : Player
    {
        private Map map;
        private Player player;
        public Enemy(string name, char displayedchar, Map m, Player p) : base(name, displayedchar)
        {
            map = m;
            player = p;
        }

        public void StartEnemy()
        {
            map.AddPlayerAt(79, 22, this);
            bool enemyAlive = true;

            while (enemyAlive)
            {
                switch(ChooseDirection())
                {
                    case Direction.UP:
                        map.move(this.posX, this.posY, this.posX, this.posY - 1);
                        this.posY = this.posY - 1;
                        break;
                    case Direction.DOWN:
                        map.move(this.posX, this.posY, this.posX, this.posY + 1);
                        this.posY = this.posY + 1;
                        break;
                    case Direction.LEFT:
                        map.move(this.posX, this.posY, this.posX - 1, this.posY);
                        this.posX = this.posX - 1;
                        break;
                    case Direction.RIGHT:
                        map.move(this.posX, this.posY, this.posX + 1, this.posY);
                        this.posX = this.posX + 1;
                        break;
                }
                Thread.Sleep(100);
            }
        }

        private Direction ChooseDirection()
        {
            Direction returnedDirection;
            if(this.posY > player.posY)
            {
                returnedDirection = Direction.UP;
            }
            else if (this.posY < player.posY)
            {
                returnedDirection = Direction.DOWN;
            }
            else
            {
                if(this.posX > player.posX)
                {
                    returnedDirection = Direction.LEFT;
                }
                else
                {
                    returnedDirection = Direction.RIGHT;
                }
            }
            return returnedDirection;
        }
    }
}

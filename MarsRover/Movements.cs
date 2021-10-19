using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Movements : RoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnums Direction { get; set; }

        public Movements(string location)
        {
            //girilen koordinatlar
            X = Convert.ToInt32(location.Split(" ")[0]);
            Y = Convert.ToInt32(location.Split(" ")[1]);
            Direction = (DirectionEnums)Enum.Parse(typeof(DirectionEnums), location.Split(" ")[2]);
        }

        //sola donuslerde mevcut duruma gore alabilecegi yonler
        public override void TurnLeft()
        {
            switch (Direction)
            {
                case DirectionEnums.N:
                    Direction = DirectionEnums.W;
                    break;
                case DirectionEnums.S:
                    Direction = DirectionEnums.E;
                    break;
                case DirectionEnums.E:
                    Direction = DirectionEnums.N;
                    break;
                case DirectionEnums.W:
                    Direction = DirectionEnums.S;
                    break;
                default:
                    break;
            }
        }

        //saga donuslerde mevcut duruma gore alabilecegi yonler
        public override void TurnRight()
        {
            switch (Direction)
            {
                case DirectionEnums.N:
                    Direction = DirectionEnums.E;
                    break;
                case DirectionEnums.S:
                    Direction = DirectionEnums.W;
                    break;
                case DirectionEnums.E:
                    Direction = DirectionEnums.S;
                    break;
                case DirectionEnums.W:
                    Direction = DirectionEnums.N;
                    break;
                default:
                    break;
            }
        }

        // bulunan konuma gore hareket durumlari
        public override void MoveOnePoint()
        {
            switch (Direction)
            {
                case DirectionEnums.N:
                    Y += 1;
                    break;
                case DirectionEnums.S:
                    Y -= 1;
                    break;
                case DirectionEnums.E:
                    X += 1;
                    break;
                case DirectionEnums.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }

        //girilen hareket listesine gore gerceklesecek aksiyonlari belirleme
        public override void Move(List<int> locationPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveOnePoint();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Tanımsız Karakter {move}");
                        break;
                }

                if (this.X < 0 || this.X > locationPoints[0] || this.Y < 0 || this.Y > locationPoints[1])
                {
                    throw new Exception($" Belirlenen sınır aşıldı. ({locationPoints[0]} , {locationPoints[1]})");
                }
            }
        }
    }
}

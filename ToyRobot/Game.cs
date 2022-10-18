﻿namespace ToyRobot
{


    public partial class Game
    {
        private int _yCoordinate;
        private int _xCoordinate;
        private Direction _direction;

        public void MoveRobot()
        {
            
        }

        public void PlaceRobot(string[] @params)
        {
            _xCoordinate = int.Parse(@params[0]);
            _yCoordinate = int.Parse(@params[1]);
            _direction = ParseEnum<Direction>(@params[2]);
        }

        public string ReportRobotLocation()
        {
            return $"Output: {_xCoordinate},{_yCoordinate},{_direction.ToString()}";
        }

        public void TurnRobotLeft()
        {
            switch ((int)_direction)
            {
                case 1:
                    _direction = Direction.WEST;
                    break;
                case 2:
                    _direction = Direction.NORTH;
                    break;
                case 3:
                    _direction = Direction.EAST;
                    break;
                case 4:
                    _direction = Direction.SOUTH;
                    break;
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
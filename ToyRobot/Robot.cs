public class Robot
{
    public Direction Direction { get; private set; }
    public int? YCoordinate { get; private set; }
    public int? XCoordinate { get; private set; }

    public void Place(int xCoordinate, int yCoordinate, Direction direction)
    {
        YCoordinate = yCoordinate;
        XCoordinate = xCoordinate;
        Direction = direction;
    }

    public bool IsPlaced()
    {
        if (XCoordinate is null) return false;
        if (YCoordinate is not null)
            return true;
        return false;
    }
    public void TurnLeft()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.West,
            Direction.East => Direction.North,
            Direction.South => Direction.East,
            Direction.West => Direction.South,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void TurnRight()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new ArgumentOutOfRangeException()
        };    }

    public void Move()
    {
        if (!IsPlaced())
        {
            Console.WriteLine("Please place robot first");
            return;
        }

        switch (Direction)
        {
            case Direction.North:
                var proposedNorthCoordinate = YCoordinate+1;
                if (CheckCoordinateOnTable(proposedNorthCoordinate))
                    YCoordinate = proposedNorthCoordinate;
                break;
            case Direction.East:
                var proposedEastCoordinate = XCoordinate + 1;
                if (CheckCoordinateOnTable(proposedEastCoordinate))
                        XCoordinate =  proposedEastCoordinate;
                break;
            case Direction.South:
                var proposedSouthCoordinate = YCoordinate - 1;
                if (CheckCoordinateOnTable(proposedSouthCoordinate))
                    YCoordinate =  proposedSouthCoordinate;
                break;
            case Direction.West:
                var proposedWestCoordinate = XCoordinate - 1;
                if (CheckCoordinateOnTable(proposedWestCoordinate))
                    XCoordinate =  proposedWestCoordinate;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private bool CheckCoordinateOnTable(int? coordinate)
    {
        return coordinate is <= 4 and >= 0;
    }
}
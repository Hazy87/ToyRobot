(int x, int y, Direction direction) ParseCommandToPlace(string[] command1)
{
    var strings = command1[1].Split(",");
    var x = strings[0];
    var y  = strings[1];
    var direction = Enum.Parse<Direction>(strings[2]);
    return (int.Parse(x), int.Parse(y), direction);
}

var robot = new Robot();
while (true)
{
    var command = Console.ReadLine().Split(" ");
    switch (command[0])
    {
        case "MOVE" : 
            robot.Move();
            break;
        case "PLACE" :
            var placeParameters = ParseCommandToPlace(command);
            robot.Place(placeParameters.x,placeParameters.y, placeParameters.direction);
            break;
        case "LEFT": robot.TurnLeft();
            break;
        case "RIGHT": robot.TurnRight();
            break;
        case "REPORT" : Console.WriteLine($"Robot is at {robot.XCoordinate},{robot.YCoordinate} facing {robot.Direction}");
            break;
        default:Console.WriteLine("Please use valid command");
            break;
    }
}
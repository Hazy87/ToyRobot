using Xunit;

namespace ToyRobotTests;

public class RobotTests
{

    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.East, Direction.North)]
    [InlineData(Direction.West, Direction.South)]
    public void Robot_CanTurn_Left(Direction currentDirection, Direction expectedDirection)
    {
        var robot = new Robot();
        robot.Place(0,0, currentDirection);
        robot.TurnLeft();
        Assert.Equal(expectedDirection, robot.Direction);
    }
    
    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.West, Direction.North)]
    public void Robot_CanTurn_Right(Direction currentDirection, Direction expectedDirection)
    {
        var robot = new Robot();
        robot.Place(0,0, currentDirection);
        robot.TurnRight();
        Assert.Equal(expectedDirection, robot.Direction);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    public void Robot_CanMoveForward_WhenFacingNorth(int startCoordinate, int expectedEndCoordinate)
    {
        var robot = new Robot();

        robot.Place( 0, startCoordinate, Direction.North);
        robot.Move();
        
        Assert.Equal(expectedEndCoordinate, robot.YCoordinate);
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    public void Robot_CanMoveForward_WhenFacingSouth(int startCoordinate, int expectedEndCoordinate)
    {
        var robot = new Robot();

        robot.Place(0,startCoordinate, Direction.South);
        robot.Move();
        
        Assert.Equal(expectedEndCoordinate, robot.YCoordinate);
    }
    
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    public void Robot_CanMoveForward_WhenFacingEast(int startCoordinate, int expectedEndCoordinate)
    {
        var robot = new Robot();

        robot.Place(startCoordinate, 0, Direction.East);
        robot.Move();
        
        Assert.Equal(expectedEndCoordinate, robot.XCoordinate);
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    public void Robot_CanMoveForward_WhenFacingWest(int startCoordinate, int expectedEndCoordinate)
    {
        var robot = new Robot();
        robot.Place(startCoordinate,0, Direction.West);
        robot.Move();
        
        Assert.Equal(expectedEndCoordinate, robot.XCoordinate);
    }
    
    [Fact]
    public void Robot_CannotMoveForward_WhenFacingWest_OnEdge()
    {
        var robot = new Robot();

        robot.Place(0,0, Direction.West);
        robot.Move();
        
        Assert.Equal(0, robot.XCoordinate);
    }
    
    [Fact]
    public void Robot_CannotMoveForward_WhenFacingEast_OnEdge()
    {
        var robot = new Robot();

        robot.Place(4,0, Direction.East);
        robot.Move();
        
        Assert.Equal(4, robot.XCoordinate);
    }
    
    [Fact]
    public void Robot_CannotMoveForward_WhenFacingNorth_OnEdge()
    {
        var robot = new Robot();

        robot.Place(0,4, Direction.North);
        robot.Move();
        
        Assert.Equal(4, robot.YCoordinate);
    }
    [Fact]
    public void Robot_CannotMoveForward_WhenFacingSouth_OnEdge()
    {
        var robot = new Robot();

        robot.Place(0,0, Direction.South);
        robot.Move();
        
        Assert.Equal(0, robot.YCoordinate);
    }

    [Fact]
    public void RobotCantMove_BeforePlaced()
    {
        var robot = new Robot();
        
        robot.Move();
        
        Assert.Null(robot.XCoordinate);
        
        Assert.Null(robot.YCoordinate);
    }

    [Theory]
    [InlineData(2, 3)]
    [InlineData(4, 1)]
    public void RobotCanBePlaced_Anywhere(int xCoordinate, int yCoordinate)
    {
        var robot = new Robot();
        
        robot.Place(xCoordinate,yCoordinate, Direction.East);
        
        Assert.Equal(xCoordinate, robot.XCoordinate);
        Assert.Equal(yCoordinate, robot.YCoordinate);
    }
}
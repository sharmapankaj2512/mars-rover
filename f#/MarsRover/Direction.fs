namespace MarsRover.Tests

module Direction =
    type Direction =
        | North = 0
        | West = 1
        | South = 2
        | East = 3

    let Left (direction: Direction) =
        match direction with
        | Direction.North -> Direction.West
        | Direction.West -> Direction.South
        | Direction.South -> Direction.East
        | Direction.East -> Direction.North
        
    let Right (direction: Direction) =
        match direction with
        | Direction.North -> Direction.East
        | Direction.East -> Direction.South
        | Direction.South -> Direction.West

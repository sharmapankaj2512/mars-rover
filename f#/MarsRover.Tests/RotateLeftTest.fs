namespace MarsRover.Tests

open NUnit.Framework
open PositionTest

module RotateLeftTest =
    type Direction =
        | North = 0
        | West = 1

    type Rover = { direction: Direction }
    let NewRover () = { direction = Direction.North }

    let Execute (rover: Rover, command: string) =
        if rover.direction = Direction.North then
            "0:0:W"
        else
            Execute(command)

    [<Test>]
    let RotateLeft () =
        let rover = NewRover()
        Assert.AreEqual("0:0:W", Execute(rover, "L"))

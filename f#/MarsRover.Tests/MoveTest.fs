namespace MarsRover.Tests

open NUnit.Framework
open Rover

module MoveTest =
    [<Test>]
    [<TestCase("M", "1:0:N")>]
    let moveRight (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updateRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updateRover))

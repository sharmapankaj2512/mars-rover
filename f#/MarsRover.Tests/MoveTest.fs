namespace MarsRover.Tests

open NUnit.Framework
open Rover

module MoveTest =
    [<Test>]
    [<TestCase("RM", "1:0:E")>]
    [<TestCase("RMMM", "3:0:E")>]
    [<TestCase("RMMMMMMMMMM", "10:0:E")>]
    let moveRight (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))

    [<Test>]
    [<TestCase("RMLLM", "0:0:W")>]
    let moveLeft (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))

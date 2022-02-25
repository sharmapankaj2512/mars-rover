namespace MarsRover.Tests

open NUnit.Framework
open MarsRover.Rover
open MarsRover.RoverController

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
    [<TestCase("RMMLLMM", "0:0:W")>]
    [<TestCase("RMMLLM", "1:0:W")>]
    [<TestCase("RMMMMMMMMMMLLMMM", "7:0:W")>]
    let moveLeft (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))

    [<Test>]
    [<TestCase("RMMMMMMMMMMM", "0:0:E")>]
    [<TestCase("RMMMMMMMMMMMMMM", "3:0:E")>]
    let wrapRight (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))

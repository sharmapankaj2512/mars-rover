namespace MarsRover.Tests

open NUnit.Framework
open Rover

module RotateRightTest =
    [<Test>]
    [<TestCase("R", "0:0:E")>]
    [<TestCase("RR", "0:0:S")>]
    [<TestCase("RRR", "0:0:W")>]
    [<TestCase("RRRR", "0:0:N")>]
    let RotateRight (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))


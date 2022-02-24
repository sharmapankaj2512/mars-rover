namespace MarsRover.Tests

open NUnit.Framework
open Rover

module RotateRightTest =
    [<Test>]
    [<TestCase("R", "0:0:E")>]
    [<TestCase("RR", "0:0:S")>]
    let RotateRight (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))


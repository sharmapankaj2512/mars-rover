namespace MarsRover.Tests

open NUnit.Framework
open Rover

module RotateLeftTest =

    [<Test>]
    [<TestCase("L", "0:0:W")>]
    let RotateLeft (command: string, expectedPosition: string) =
        let rover = NewRover()
        let updatedRover = Navigate(rover, command)
        Assert.AreEqual(expectedPosition, Position(updatedRover))

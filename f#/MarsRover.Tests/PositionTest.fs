namespace MarsRover.Tests

open NUnit.Framework
open MarsRover.Rover

module PositionTest =

    [<Test>]
    let InitialPosition () =
        Assert.AreEqual("0:0:N", Position(NewRover()))

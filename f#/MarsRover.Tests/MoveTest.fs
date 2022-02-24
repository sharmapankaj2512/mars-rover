namespace MarsRover.Tests

open NUnit.Framework
open Rover

module MoveTest =
    [<Test>]
    let moveRight () =
        let rover = NewRover()
        let updateRover = Navigate(rover, "M")
        Assert.AreEqual("1:0:N", Position(updateRover))

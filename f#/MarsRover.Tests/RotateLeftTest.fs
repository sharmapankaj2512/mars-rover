namespace MarsRover.Tests

open NUnit.Framework
open Rover

module RotateLeftTest =    

    [<Test>]
    let RotateLeft () =
        let rover = NewRover()
        Assert.AreEqual("0:0:W", Position(Execute(rover, "L")))

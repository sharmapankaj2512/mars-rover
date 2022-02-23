namespace MarsRover.Tests

open NUnit.Framework
open PositionTest

module RotateLeftTest =

    [<Test>]
    let RotateLeft () =
        Assert.AreEqual("0:0:W", Execute("L"))

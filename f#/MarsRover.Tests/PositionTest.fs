module MarsRover.Tests

open NUnit.Framework

let Execute(command: string) = "0:0:N"

[<Test>]
let InitialPosition () =    
    Assert.AreEqual("0:0:N", Execute("P"))

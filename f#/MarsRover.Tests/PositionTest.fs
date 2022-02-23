module MarsRover.Tests

open NUnit.Framework

let Execute(command: string) = ""

[<Test>]
let InitialPosition () =    
    Assert.AreEqual("0:0:N", Execute("P"))

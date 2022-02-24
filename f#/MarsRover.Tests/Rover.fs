namespace MarsRover.Tests

open System
open Direction

module Rover =
    type Rover = { direction: Direction }
    let NewRover () = { direction = Direction.North }

    let rotateLeft (rover: Rover) =
        { rover with
              direction = Left(rover.direction) }

    let Position (rover: Rover) =
        match rover.direction with
        | Direction.North -> "0:0:N"
        | Direction.West -> "0:0:W"
        | Direction.South -> "0:0:S"
        | Direction.East -> "0:0:E"
        | _ -> ArgumentOutOfRangeException() |> raise

    let rec Navigate (rover: Rover, command: string) =
        if command.Length = 0 then
            rover
        else
            Navigate(rotateLeft rover, command.[1..])

namespace MarsRover.Tests

open System

module Rover =
    type Direction =
        | North = 0
        | West = 1

    type Rover = { direction: Direction }
    let NewRover () = { direction = Direction.North }

    let Position (rover: Rover) =
        match rover.direction with
        | Direction.North -> "0:0:N"
        | Direction.West -> "0:0:W"
        | _ -> ArgumentOutOfRangeException() |> raise
        
    let Navigate (rover: Rover, command: string) =
        if rover.direction = Direction.North then
            {rover with direction = Direction.West}
        else
            rover

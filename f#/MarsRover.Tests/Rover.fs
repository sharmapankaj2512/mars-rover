namespace MarsRover.Tests

open System

module Rover =
    type Direction =
        | North = 0
        | West = 1
        | South = 2
        | East = 3

    type Rover = { direction: Direction }
    let NewRover () = { direction = Direction.North }

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
        elif rover.direction = Direction.North then
            Navigate(
                { rover with
                      direction = Direction.West },
                command.[1..]
            )
        elif rover.direction = Direction.West then
            Navigate(
                { rover with
                      direction = Direction.South },
                command.[1..]
            )
        elif rover.direction = Direction.South then
            Navigate(
                { rover with
                      direction = Direction.East },
                command.[1..]
            )
        else
            rover

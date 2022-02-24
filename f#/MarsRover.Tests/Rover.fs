namespace MarsRover.Tests

open System

module Rover =
    type Direction =
        | North = 0
        | West = 1
        | South = 2
        | East = 3

    let Left (direction: Direction) =
        match direction with
        | Direction.North -> Direction.West
        | Direction.West -> Direction.South
        | Direction.South -> Direction.East
        | _ -> direction

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

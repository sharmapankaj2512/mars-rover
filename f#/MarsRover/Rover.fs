namespace MarsRover.Tests

open Direction

module Rover =
    let MoveLimit = 11
    type Rover = { x: int; direction: Direction }
    let NewRover () = { x = 0; direction = Direction.North }

    let rotateLeft (rover: Rover) =
        { rover with
              direction = Left(rover.direction) }

    let rotateRight (rover: Rover) =
        { rover with
              direction = Right(rover.direction) }

    let moveRight (rover: Rover) =
        { rover with
              x = (rover.x + 1) % MoveLimit }

    let moveLeft (rover: Rover) = { rover with x = rover.x - 1 }

    let move (rover: Rover) =
        match rover.direction with
        | Direction.East -> moveRight rover
        | Direction.West -> moveLeft rover

    let Position (rover: Rover) =
        match rover.direction with
        | Direction.North -> $"{rover.x}:0:N"
        | Direction.West -> $"{rover.x}:0:W"
        | Direction.South -> "0:0:S"
        | Direction.East -> $"{rover.x}:0:E"

    let Navigate (rover: Rover, command: string) =
        let rec helper (rover, commands) =
            match commands with
            | 'L' :: tail -> helper (rotateLeft rover, tail)
            | 'R' :: tail -> helper (rotateRight rover, tail)
            | 'M' :: tail -> helper (move rover, tail)
            | [] -> rover

        helper (rover, command |> List.ofSeq)

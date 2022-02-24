namespace MarsRover.Tests

open Direction

module Rover =
    type Rover = { direction: Direction }
    let NewRover () = { direction = Direction.North }

    let rotateLeft (rover: Rover) =
        { rover with
              direction = Left(rover.direction) }
        
    let rotateRight (rover: Rover) =
        { rover with
              direction = Right(rover.direction) }

    let Position (rover: Rover) =
        match rover.direction with
        | Direction.North -> "0:0:N"
        | Direction.West -> "0:0:W"
        | Direction.South -> "0:0:S"
        | Direction.East -> "0:0:E"

    let Navigate (rover: Rover, command: string) =
        let rec helper (rover, commands) =
            match commands with
            | head :: tail ->
                if head = 'L' then 
                    helper (rotateLeft rover, tail)
                else
                    helper (rotateRight rover, tail)
            | [] -> rover

        helper (rover, command |> List.ofSeq)

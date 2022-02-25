namespace MarsRover

open MarsRover
open Rover

module RoverController =
    let Navigate (rover: Rover, command: string) =
        let rec helper (rover, commands) =
            match commands with
            | 'L' :: tail -> helper (rotateLeft rover, tail)
            | 'R' :: tail -> helper (rotateRight rover, tail)
            | 'M' :: tail -> helper (move rover, tail)
            | [] -> rover

        helper (rover, command |> List.ofSeq)

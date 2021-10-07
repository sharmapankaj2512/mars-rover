package mars_rover

import (
	"fmt"
)

const (
	MaxHeight = 10
	MaxWidth  = 10

	Right = 'R'
	Left  = 'L'
	Move  = 'M'
)

type Rover struct {
	direction  *Direction
	coordinate *Coordinate
}

func NewRover() *Rover {
	return &Rover{
		direction:  NewDirection(),
		coordinate: NewCoordinate(0, 0),
	}
}

func (r *Rover) navigate(commands string) {
	for _, command := range commands {
		switch command {
		case Right:
			r.direction = r.direction.Right()
		case Left:
			r.direction = r.direction.Left()
		case Move:
			r.coordinate = r.coordinate.Next(r.direction)
		}
	}
}

func (r *Rover) position() string {
	return fmt.Sprintf("%d:%d:%s",
		r.coordinate.X,
		r.coordinate.Y,
		r.direction.Value)
}

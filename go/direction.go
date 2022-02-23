package mars_rover

const North = "N"
const South = "S"
const West = "W"
const East = "E"

type Direction struct {
	Value string
	Left  func() *Direction
	Right func() *Direction
}

func NewDirection() *Direction {
	return northDirection()()
}

func (d *Direction) IsNorth() bool {
	return d.Value == North
}

func (d *Direction) IsSouth() bool {
	return d.Value == South
}

func (d *Direction) IsWest() bool {
	return d.Value == West
}

func (d *Direction) IsEast() bool {
	return d.Value == East
}

func northDirection() func() *Direction {
	return func() *Direction {
		return &Direction{
			Value: North,
			Left:  eastDirection(),
			Right: westDirection(),
		}
	}
}

func westDirection() func() *Direction {
	return func() *Direction {
		return &Direction{
			Value: West,
			Left:  northDirection(),
			Right: southDirection(),
		}
	}
}

func southDirection() func() *Direction {
	return func() *Direction {
		return &Direction{
			Value: South,
			Left:  westDirection(),
			Right: eastDirection(),
		}
	}
}

func eastDirection() func() *Direction {
	return func() *Direction {
		return &Direction{
			Value: East,
			Left:  southDirection(),
			Right: northDirection(),
		}
	}
}

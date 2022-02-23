package mars_rover

type Coordinate struct {
	X int
	Y int
}

func (c *Coordinate) Next(direction *Direction) *Coordinate {
	if direction.IsNorth() {
		return NewCoordinate(c.X, (c.Y+1)%MaxHeight)
	}
	if direction.IsSouth() && c.Y > 0 {
		return NewCoordinate(c.X, c.Y-1)
	}
	if direction.IsWest() {
		return NewCoordinate((c.X+1)%MaxWidth, c.Y)
	}
	if direction.IsEast() && c.X > 0 {
		return NewCoordinate(c.X-1, c.Y)
	}
	return c
}

func NewCoordinate(x int, y int) *Coordinate {
	return &Coordinate{
		X: x,
		Y: y,
	}
}

package mars_rover

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestFacesNorth(t *testing.T) {
	rover := NewRover()
	rover.navigate("")

	assert.Equal(t, "0:0:N", rover.position())
}

func TestRotateRight(t *testing.T) {
	tests := []RoverTestData{
		{"R", "0:0:W"},
		{"RR", "0:0:S"},
		{"RRR", "0:0:E"},
		{"RRRR", "0:0:N"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestRotateLeft(t *testing.T) {
	tests := []RoverTestData{
		{"L", "0:0:E"},
		{"LL", "0:0:S"},
		{"LLL", "0:0:W"},
		{"LLLL", "0:0:N"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveUp(t *testing.T) {
	tests := []RoverTestData{
		{"M", "0:1:N"},
		{"MMM", "0:3:N"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveBackToBottomAfterCrossingMaxHeight(t *testing.T) {
	tests := []RoverTestData{
		{"MMMMMMMMMM", "0:0:N"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveDown(t *testing.T) {
	tests := []RoverTestData{
		{"MRRM", "0:0:S"},
		{"MMMRRM", "0:2:S"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveBackToBottomAfterCrossingMinimumHeight(t *testing.T) {
	tests := []RoverTestData{
		{"MRRMM", "0:0:S"},
		{"MMRRMMMMM", "0:0:S"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveToRight(t *testing.T) {
	tests := []RoverTestData{
		{"RM", "1:0:W"},
		{"RMMM", "3:0:W"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveBackToLeftAfterCrossingMaximumWidth(t *testing.T) {
	tests := []RoverTestData{
		{"RMMMMMMMMMM", "0:0:W"},
		{"RMMMMMMMMMMMMM", "3:0:W"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveToLeft(t *testing.T) {
	tests := []RoverTestData{
		{"RMLLM", "0:0:E"},
		{"RMMMLLM", "2:0:E"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func TestMoveBackToLeftAfterCrossingMinimumWidth(t *testing.T) {
	tests := []RoverTestData{
		{"LM", "0:0:E"},
		{"RMLLMMM", "0:0:E"},
	}

	for _, test := range tests {
		runTest(t, test)
	}
}

func runTest(t *testing.T, test RoverTestData) bool {
	return t.Run(test.command, func(t *testing.T) {
		rover := NewRover()
		rover.navigate(test.command)

		assertThatRoverIsAtExpectedPosition(t, test, rover)
	})
}

func assertThatRoverIsAtExpectedPosition(t *testing.T, test RoverTestData, rover *Rover) bool {
	return assert.Equal(t, test.expected, rover.position())
}

type RoverTestData struct {
	command  string
	expected string
}

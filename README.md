# Pathfinding Visualizer

## Introduction

This project is a Pathfinding Visualizer built using C# and Windows Forms (WinForms). It's designed to visually demonstrate how various pathfinding algorithms navigate a grid to find the shortest path between two points. Currently, the visualizer supports the following algorithms:

- **A\* (A-Star) Algorithm**: Efficiently finds the shortest path by estimating the distance to the goal.
- **Breadth-First Search**: Explores nearest neighbors first, moving outward in a circular fashion.
- **Depth-First Search**: Explores as far as possible along each branch before backtracking.
- **Dijkstra's Algorithm**: Finds the shortest paths between nodes in a graph, which may vary in length.

## Features

- **Real-time Visualization**: See the algorithm's decision-making process in real-time.
- **Interactive Grid**: Click to add obstacles, start, and end points.
- **Algorithm Comparison**: Easily switch between algorithms to compare performance and path efficiency.
- **Step-by-Step Execution**: Option to view each step of the algorithm, aiding in educational purposes.

## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)
- Visual Studio (2017 or later recommended for compatibility)

### Installation

1. Clone the repository or download the ZIP file.
    ```
    git clone this_repo
    ```
2. Open the solution file in Visual Studio.
3. Build the project by going to `Build -> Build Solution` (or press `Ctrl+Shift+B`).
4. Run the project by pressing `F5` or clicking the `Start` button.

## Usage

- **Setting Up the Grid**: Left-click on the grid to place the start and end points. Right-click to place or remove obstacles.
- **Selecting an Algorithm**: Choose an algorithm from the dropdown menu and click `Start` to begin visualization.
- **Resetting the Grid**: Click `Reset` to clear the grid and start anew.

## Contributing

Contributions to the Pathfinding Visualizer are welcome! Whether it's adding new algorithms, improving the UI, or fixing bugs, your help is appreciated. Please follow the standard fork-branch-PR workflow.

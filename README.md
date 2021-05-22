# Game of Dice

This solution contains two projects one is the main code and another is for unit tests cases. This is console application that runs on commands line interface through out. 

## Setup

### Clone repo

Run the following command to clone the repository

```powershell
https://github.com/VishNu2069/game-of-dice.git
```

### Install Dotnet Core

Dotnet core 3.1 is required to run the application. Please download the latest version of .net core SDK from [here](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Open the repo in VS Code

Please download the latest version [here](https://code.visualstudio.com/)

## Run Application

### Build the soution

To build the solution run the following commands.

```powershell
game-of-dice> dotnet build
```

### Run the Solution

To run the solution run the following commands.

```powershell
game-of-dice> dotnet run --project .\GameOfDice\GameOfDice.csproj <number_of_players> <points_to_accumulate>
```

The commands line interface will guide your throught the game and displayed the score and dice values as per the specification.

## Run unit tests

To run the solution run the following commands.

```powershell
game-of-dice> cd .\UnitTests\
game-of-dice/UnitTests> dotnet test
```

# TDD Kata 1 - Tic-tac-toe Moves

This document continues from [TDD Kata - Tic-tac-toe Example](tdd_kata0.md).

## Tasks & specifications

1.  Create a `GameEngine` class which contains a `Move` method.
    - The Move method accepts the following parameters: 
        - player ID
        - position on game board
    - The `Move` method returns a `GameResult` object which contains the following properties:
        - `IsGameComplete`
        - `WinnerPlayerID`
        - `Message`

2.  The `GameEngine` should be able to  execute a maximum of 9 moves. Once the 9th move is executed the game is completed.
    - Start with writing tests to assert `IsGameComplete`. 

## Next exercise

The next kata is [TDD Kata 2 - Tic-tac-toe Winners](tdd_kata2.md).
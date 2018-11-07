# TDD Kata 2 - Tic-tac-toe Moving

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 1 - Tic-tac-toe Moving](tdd_kata1.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Create a `GameEngine` class.
    - The class needs to be initialized with two player instances: 
        - `Player` player1
        - `Player` player2
    - Add a `Move` method which accepts the following parameters: 
        - player
        - position on game board
    - Ensure that when the `Move` method is called on the `GameEngine` the `NumberOfMoves` on the correct player instance is updated.

2.  Extend the `GameEngine` with a `IsGameComplete` property.
    - Ensure that `IsGameComplete` is true after the 9th move.

## Next exercise

The next kata is [TDD Kata 3 - Tic-tac-toe Winners](tdd_kata3.md).
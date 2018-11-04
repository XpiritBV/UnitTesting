# TDD Kata 1 - Tic-tac-toe Moves

This document continues from [TDD Kata - Tic-tac-toe Example](tdd_kata0.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Create a `GameEngine` class which contains a `Move` method.
    - The Move method accepts the following parameters: 
        - player mark
        - position on game board
    - The `Move` method returns a `GameResult` object which contains the following properties:
        - `IsGameComplete`
        - `WinnerPlayerMark`
        - `NextPlayerMark`
        - `Message`

2.  Implement the `Move` method so that once it is called by player `X` then the `GameResult.NextPlayerMark` should be player `O` and vice versa.

3.  After executing the 9th move the game should be completed (`GameResult.IsGameComplete` is true). 

## Next exercise

The next kata is [TDD Kata 2 - Tic-tac-toe Winners](tdd_kata2.md).
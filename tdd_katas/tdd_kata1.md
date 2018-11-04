# TDD Kata 1

This document contains an exercise to practice coding and refactoring in a test driven approach.

Before you start: 
- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.
- Make sure you only test for correct inputs. There is no need to test for invalid inputs for this kata.

## Outline

The goal is to create a [Tic-tac-toe](https://en.wikipedia.org/wiki/Tic-tac-toe) game.

The board consists of 9 positions.

```
    1 | 2 | 3
   ---|---|---
    4 | 5 | 6
   ---|---|---
    7 | 8 | 9
```

The player ID is either `X` or `O`.

### Tasks & specifications

1.  Create a `GameEngine` class which contains a `Move` method.
    - The Move method accepts the following parameters: 
        - player ID
        - position on game board
    - The `Move` method returns a `GameResult` object which contains the following properties:
        - `IsGameComplete`
        - `WinnerPlayerID`
        - `Message`

2.  The `GameEngine` should be able to  execute a maximum of 9 moves. Once the 9th move is executed the game is completed.
    - Start with writing tests to assert `IsGameComplete` (for 0 moves, 1 move and 9 moves).

3.  The `GameEngine` should throw a `NotSupportedException`   once `Move` is called after the game is called for the 10th time.

4.  
# TDD Kata 3 - Tic-tac-toe Winning

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 2 - Tic-tac-toe Moving](tdd_kata2.md).

## Board

The game board with the positions:

```
    1 | 2 | 3
   ---|---|---
    4 | 5 | 6
   ---|---|---
    7 | 8 | 9
```

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications
1.  Update the `GameEngine` class to include a property for the winning player (e.g. `WinningPlayer`).

2. Update the `GameEngine` so that a game is won when a player has three marks in the same row:
    - row 1: 1, 2, 3
    - row 2: 4, 5, 6
    - row 3: 7, 8, 9

3. Update the `GameEngine` so that a game is won when a player has three marks in the same column:
    - column 1: 1, 4, 7
    - column 2: 2, 5, 8
    - column 3: 3, 6, 9

4. Update the `GameEngine` so that a game is won when a player has three marks in a diagonal:
    - diagonal 1: 1, 5, 9
    - diagonal 2: 3, 5, 7

## Next exercise

The next kata is [TDD Kata 4 - Tic-tac-toe Boundaries](tdd_kata4.md).
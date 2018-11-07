# TDD Kata 4 - Tic-tac-toe Boundaries

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 3 - Tic-tac-toe Winning](tdd_kata3.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  The game engine should throw a `MaximumMovesExceededException` once `Move` is called for the 10th time.

2.  The `Move` method of the game engine should throw a `MoveNotAllowedException` when a player makes a move to a position that is already used.

3.  The game engine should not throw an exception when a player makes incorrect moves and the total number of moves is greater than 9.

## Next exercise

The next kata is [TDD Kata 5 - Tic-tac-toe Logging](tdd_kata5.md).
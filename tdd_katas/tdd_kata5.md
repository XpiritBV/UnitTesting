# TDD Kata 4 - Tic-tac-toe Boundaries

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 4 - Tic-tac-toe Winning](tdd_kata3.md).

## Before you start

- Try not to read ahead.
- Do one numbered  task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  The game engine should throw a `MaximumMovesExceededException` once `Move` is called for the 10th time.
    - Ensure that this specific exception is thrown.
    - Ensure that no exceptions are thrown when `Move` is called less than 10 times.

2.  The `Move` method of the game engine should throw a `MoveNotAllowedException` when a player makes a move to a position that is already used.
    - Ensure that this specific exception is thrown.
    - Ensure that no exceptions are thrown when a free position is used.

3.  Extend the `GameEngine` with a property of available positions.  

## Next exercise

The next kata is [TDD Kata 6](tdd_kata6.md).
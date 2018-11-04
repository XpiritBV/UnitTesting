# TDD Kata 3 - Tic-tac-toe Boundaries

This document assumes the previous kata is completed: [TDD Kata 2 - Tic-tac-toe winners](tdd_kata2.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  The game engine should throw a `NotSupportedException` once `Move` is called for the 10th time.

2. The `Move` method of the game engine should return a warning message (e.g. `$"Incorrect move by player {playerMark}"`) when a player makes a move to a position that is already used.

3. In case of an incorrect move the `GameResult.NextPlayerMark` should not change to the other player.

4. The game engine should not throw an exception when a player makes incorrect moves and the total number of moves is greater than 9.

## Next exercise

The next kata is [TDD Kata 4 - Tic-tac-toe Logging](tdd_kata4.md).
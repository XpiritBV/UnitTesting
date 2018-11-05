# TDD Kata 4 - Tic-tac-toe Logging

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata0.md).

This document assumes the previous kata is completed: [TDD Kata 3 - Tic-tac-toe Boundaries](tdd_kata3.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Update the game engine so that it writes a warning to a log when the `Move` method is called for an incorrect move.
    - Use dependency injection to introduce an `ILogger` interface with a `WriteWarning` method.
    - The implementation of the `WriteWarning` method can throw a `NotImplementedException` since this code should not be executed during unit tests.
    - Use a mocking framework to verify that the `WriteWarning` method is called on the logger.

## Next exercise

The next kata is [TDD Kata 5 - Tic-tac-toe Loading game state](tdd_kata5.md).
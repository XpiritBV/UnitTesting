# TDD Kata 5 - Tic-tac-toe Logging

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 4 - Tic-tac-toe Boundaries](tdd_kata4.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Update the `GameEngine` so that it writes a message to a log when the `Move` method is called.
    - Use dependency injection to introduce an `IGameLogger` interface with a `WriteInformation` method.
    - Use a mocking framework to verify that the `WriteInformation` method is called once on the logger when the `Move` is called (interaction-based test).

## Next exercise

The next kata is [TDD Kata 6 - Tic-tac-toe Using game state](tdd_kata6.md).
# TDD Kata 6 - Tic-tac-toe Saving game state async 

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata0.md).

This document assumes the previous kata is completed: [TDD Kata 5 - Tic-tac-toe Loading game state](tdd_kata5.md).

## Before you start

- Try not to read ahead.
- Do one task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Update the game engine to allow loading of a previously saved game state.
    - A game can either be started from scratch or be loaded from a previous state. Once the game engine has started a previous state can't be loaded into it.
    - Consider introducing the game state using dependency injection.

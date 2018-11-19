# TDD Kata 8 - Tic-tac-toe Loading from disk

This kata is part of a series of exercises described in [TDD Kata - Tic-tac-toe](tdd_kata_intro.md).

This document assumes the previous kata is completed: [TDD Kata 7 - Tic-tac-toe Saving & loading game state](tdd_kata7.md).

## Before you start

- Try not to read ahead.
- Do one numbered task at a time. The trick is to learn to work incrementally.

## Tasks & specifications

1.  Introduce an integration test which loads a game state file from disk (keep the file inside the repository). Don't rely on any mocking frameworks related to System.IO.

2.  Prevent that this runs as a pure in-memory unit test by applying an attribute to the test which puts this test in a seperate category.

3.  Prevent that this test runs when using the Live Unit Testing feature in Visual Studio Enterprise.

4.  Think of a way how to refactor the test so it does not load it directly from disk but the file remains intact.


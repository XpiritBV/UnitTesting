# CCDSchool TodoList

The code in this solution is taken from [CCDSchool](https://github.com/ccdschool/brownfields). It's a Task List app with lots of hardcoded stuff, no dependency injection, no interfaces, etc.

The goal is to write tests and experience how far you can go with an app that isn't build with testing in mind. Instructions are sparse, just take what you've learned and apply it!

## Before you start

- Start the application and have a look around

## Tasks

1.	Familiarize yourself with the code so you understand how stuff works at a high level.

2.  Start from the inside and work your way out.
	- Begin by testing the business logic in CCDSchool.Business.
	- Don't bother with unittesting the SqlLiteHelper, it's too lowlevel. Just clean it up a bit if you want.

3.  Move on to the ASPX pages.
    - Initially there seem to be 2 challenges: protected methods and properties like "IsPostBack" which have no setter.
	- Think of a way to make the protected methods visible in your unittests and how to change the behavior of IsPostBack.
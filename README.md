## Introduction
    
The MaritimeDojo project is about exposing a University WEB API for the purposes of generating information on lecture halls. There is a given set
of subjects, lecturers and lecture halls. One lecturer is assigned to one subject, one subject can have many lecturers. 
Reservation concerns specific lecturer in a specific lecture hall in some timeframe. API allows listing lecturers, 
subjects and lecture halls - there is no possibility to manipulate them. The project concentrates on reservations - 
we can list/add/delete and get basic statistics about them.
 
Ninject is used to resolve dependencies and query a pattern for data retrieval. A simple, custom, in-memory database is used 
as a datastore for the purposes of this project. Other packages used: AutoMapper (mapping between entities and
view models), MSTest and FluentAssertions for unit tests.

## Problem Statement
  
You have 3 main tasks to complete:- 

1) Implement validation rules used while adding a new reservation. 
**Note:** You have to check all the rules and give a customer full information about the validation results. Do not stop after the first validation failure.

Implement following validation rules:
 - newReservation.From must be the same day as newReservation.To. If it isn't, set result |= ValidationResult.MoreThanOneDay
 - newReservation.From obviously can't be >= newReservation.To. If it is, set result |= ValidationResult.ToBeforeFrom
 - whole newReservation must be included inside working hours: 8-18 (it can't start before 8 and must finish at 18 at the very latest). If it's not met, set result |= ValidationResult.OutsideWorkingHours
 - newReservation must last 3 hours at most. If it's not, set result |= ValidationResult.TooLong
 - newReservation obviously cannot be in conflict (same hallNumber and overlapping hours) with any existing reservation. If it is, set result |= ValidationResult.Conflicting. Use _queryAll to get all extisting reservations
 - check if newReservation.LectureHallNumber points at existing lecture hall. If it's not, set result |= ValidationResult.HallDoesNotExist. Use _queryAllLectureHalls to get all extisting lecture halls
 - check if newReservation.LecturerId points at existing lecturer. If it's not, set result |= ValidationResult.LecturerDoesNotExist. Use _queryAllLecturers to get all extisting lecturers

**Remember!** Check ALL validation rules and set result with appropriate enum flag described above.
Note that for reservation dates, we take into account only date and an hour, minutes and seconds doesn't matter.

2) Implement DateTimeExtensions.cs
   a) Implement GetPreviousDayOfWeek extension method:
      - idea is to get the previous date from a given date and day of week
      - Examples:-
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Monday then the result returned should be Monday 3rd June
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Wednesday then the result returned should be Wednesday 29th May
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Tuesday then the result returned should be Tuesday 28th May
   b) Implement GetNextDayOfWeek extension method:
      - idea is to get the next date from a given date and day of week
      - Examples:-
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Monday then the result returned should be Monday 10th June
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Wednesday then the result returned should be Wednesday 5th June
        - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Tuesday then the result returned should be Tuesday 11th June

3) Implement StringExtension.cs
   a) Implement GetWordFromText extension method:
      - idea is to return a specific work of an input text. Words are separated by space (' ').
      - Examples:-
      - GetWordFromText("one two three", 2)
        Should return "two"
      
      - GetWordFromText("one;two three", 2)
        Should return "three"
      
      - GetWordFromText("one", 1)
        Should return "one"
      
      #### Be aware of ####
      
      When input parameter 'wordNumberToFind' is less than 1, the method should throw ArgumentOutOfRangeException. 
      When input text does not have enough words('GetWordFromText("one", 2)'), method should throw 'ArgumentException'. 
      When input is null method should throw 'ArgumentNullException'.
      
      The method should ignore all spaces at the beginning and at the end of the input text.
  b) Implement Reverse extension method:
     - idea is to return a reversed string of the passed input value
     - Examples:-
     - Reverse("one")
       Should return "eno"
     
     - Reverse("abcd dcba")
       Should return "abcd dcba"
     
     #### Be aware of ####
     
     When input is null method should throw 'ArgumentNullException'. 
     Method should return empty string, if empty string is passed as an input parameter. 

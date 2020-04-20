# Workshop: From DDD/BDD to Outside-in TDD

## Lab 1: Implement the First Example
Goal of this lab is to develop an implementation for the first example.

![First Example](docs/example-map-lab-1.jpg)

At the end of the lab you have a successfully running test suite validating the implementation can handle the examples we've found in our Example Mapping session.

## Implementation Pointers
The project consists out of 2 project. The `CinemaReservations.Tests` project is the one where you will implement the solution. The `External.AuditoriumLayout` project is an external dependency you will use to load the layout of the auditorium. Note, it only contains the layout of an auditorium. 

Treat this project as a solution you have no control over. Ensure a low coupling between your implementation and this project, for example by using the `Adapter Pattern`.

### Mocking data
The project includes mocking data for various examples. For this project you will need to use the following `showId` for the examples.

**Show ID: 1** - 1 Seat available  
**Show ID: 5** - No Seats available
 
### Loading of reservation data
Besides the layout of an auditorium you will need to have information on reserved seats for a specific movie screening. This data can be found in the `booked_sets.json` files in the stub folder. 

In order to help you quickly load this information we have provided a JsonFile and DTO class in `CinemaReservations.Tests.StubMovieScreening`. An example of usage can be found in `External.AuditoriumLayout.StubAuditoriumRepository.cs`
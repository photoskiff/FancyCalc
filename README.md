# C# Interview Exercise

## Implementation Notes
Given relatively short time to complete the project the final code is not yet in the production state and missing some bits like exception handling or logging for example.
I haven't added it for the reason that the exception handling strategy would vary depending on the project requirements.
- However I tried to make my code simple, concise, performant and written in a functional style and provided some unit tests as a TDD practice.
- The calculation is calculated recursively. In order to dramatically increase the performance and decrease a possibility of stack overflow I use memoization in the recursion. 
I have left a line in the *Memoized()* function that if commented out would bypass memoization just in order to demonstrate a difference in performance 
(non-memoized running under 1 min and memoized one - instantly)
- The file loading and calculation tasks are separated into 2 different static classes OperationLoader and Calculator in line with Single Responsibility principle
- My assumption about the size of the input data was that it was probably close to a practical maximum and this should not exhaust the 4MB stack limit especially 
with the support of memoizing.

## Usage
- build and run the solution. The calculation result from the provided input.txt file should be equal to **275,225,993,853**
- quick tests can be implemented within a provided Unit Test project

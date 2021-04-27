# C# Interview Exercise

## Implementation Notes

- In this exercise I tried to make my code simple, concise, performant and written in a functional style and I provided some unit tests as a TDD practice.
- The calculation is implemented using recursion. In order to dramatically improve the performance and to decrease a possibility of stack overflow I use memoization in the recursion. 
I have left a line in the *Memoized()* function that if commented out would bypass memoization just in order to demonstrate a difference in performance 
(non-memoized running under 1 min and memoized one - instantly)
- The file loading and calculation tasks are separated into 2 different static classes OperationLoader and Calculator in line with Single Responsibility principle
- My assumption about the size of the input data was that it was probably close to a practical maximum and this should not exhaust the 4MB stack limit especially 
with the memoizing support.
- For better code clarity I deliberately skipped some operational bits like exception handling, arguments checking or logging, that would be added in the production code.

## Usage
- build and run the solution. The calculation result from the provided input.txt file should be equal to **275,225,993,853**
- quick tests can be implemented within a provided Unit Test project

## Conclusion
For the given task the performance of the application is excellent and I don't see a need to optimize it further and to complicate the simple code (async, parallel processing) but if the calculation tasks were heavier, further considerations could take place. Also in case of substantial increase of the input data, a stack based iterative solution instead of recursion may be considered to avoid a possible stack overflow problem.

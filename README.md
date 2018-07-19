# ChainOfResponsiblityExample
An example of the chain of responsibility pattern in C#.

The secanrio is one in which a hierarcy of managers needs to approve purchaes.
    
    The chain is Team Lead->Manager->Director
    A Team Lead can approve purchases up to and including R200, after that a manager must look at it.
    A Manager can approve purchaes up to and including R1000, after that a director much look at it.
    A Director can approve purchaes up to R5000, after that the CEO must look at it.

The test all focus on a team lead making a purchase that needs to travel to varius positions in the chain for approval. 
Unlike most examples, which simply print a message, this example returns an object from the chain.

There is an exercies for you to try as well.

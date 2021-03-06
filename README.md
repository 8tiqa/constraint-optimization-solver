# Optimera
A .NET solution for constraint optimization of resource allocation and scheduling problems of both linear or mixed integer nature. 

+ It allows the users to perform hands-on interaction and experimentation with models by formulating the model using variables, objectives, and constraints that represent the general form of the problem to be solved; importing data defining a specific problem instance (.csv, .xlxs); and generating a specific objective function and constraint equations from the model and data. 

+ The program then solves the problem instance by running solver libraries to apply an algorithm (Simplex Algorithm, parallel barriers etc.) that considered billions or even trillions of possible solutions to find the best one. 

+ Infeasible solutions are catered by computing the Irreducible Infeasible Subset (IIS) of the model and removing all conflicting constraints until the problem cannot be solved.

+ The user can export the solution found from optimization to .sol file format, Excel spreadsheet, PDF and HTML. 

+ The user can also use the visualization tool to analyse the model and optimization status. The visualization window allows the user to analyse the types of variables involved, solution status, solution count, run time, bounds, algorithmic iterations and coefficient statistics.


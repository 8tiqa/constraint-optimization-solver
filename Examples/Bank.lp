Minimize
  200 ResearcherA + 200 ResearcherB + 80 StudentA + 80 StudentB + 80 StudentC + 80 StudentD + 80 StudentE + 80 StudentF + 80 StudentG + 80 StudentH
Subject To
  C1: ResearcherA + ResearcherB + StudentA >= 4
  C2: ResearcherA + ResearcherB + StudentA + StudentB >= 3
  C3: ResearcherA + ResearcherB + StudentA + StudentB + StudentC >= 4
  C4: ResearcherB + StudentA + StudentB + StudentC + StudentD >= 6
  C5: ResearcherA + StudentB + StudentC + StudentD + StudentE >= 5
  C6: ResearcherA + ResearcherB + StudentC + StudentD + StudentE + StudentF >= 6
  C7: ResearcherA + ResearcherB + StudentD + StudentE + StudentF + StudentG >= 8
  C8: ResearcherA + ResearcherB + StudentE + StudentF + StudentG + StudentH >= 8
  C9: StudentA + StudentB + StudentC + StudentD + StudentE + StudentF + StudentG + StudentH <= 3
Bounds
  0 <= StudentH <= INFINITY
  0 <= StudentG <= INFINITY
  0 <= StudentF <= INFINITY
  0 <= StudentE <= INFINITY
  0 <= StudentD <= INFINITY
  0 <= StudentC <= INFINITY
  0 <= StudentB <= INFINITY
  0 <= StudentA <= INFINITY
  0 <= ResearcherB <= INFINITY
  0 <= ResearcherA <= INFINITY
Integers
  ResearcherA ResearcherB StudentA StudentB StudentC StudentD StudentE StudentF StudentG StudentH
End

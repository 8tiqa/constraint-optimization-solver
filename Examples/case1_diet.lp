Minimize
  3.19 BEEF + 2.59 CHK + 2.29 FISH + 2.89 HAM + 1.89 MCH + 1.99 MTL + 1.99 SPG + 2.49 TUR 

Subject To
  A: 60 BEEF + 8 CHK + 8 FISH + 40 HAM + 15 MCH + 70 MTL + 25 SPG + 60 TUR - A = 0
  C: 20 BEEF + 0 CHK + 10 FISH + 40 HAM + 35 MCH + 30 MTL + 50 SPG + 20 TUR - C = 0 
  B1: 10 BEEF + 20 CHK + 15 FISH + 35 HAM + 15 MCH + 15 MTL + 25 SPG + 15 TUR - B1 = 0
  B2: 15 BEEF + 20 CHK + 10 FISH + 10 HAM + 15 MCH + 15 MTL + 15 SPG + 10 TUR - B2 = 0

Bounds
  700 <= A <= 10000
  700 <= C <= 10000
  700 <= B1 <= 10000
  700 <= B2 <= 10000 
  0 <= BEEF <= 100
  0 <= CHK <= 100
  0 <= FISH <= 100
  0 <= HAM <= 100
  0 <= MCH <= 100
  0 <= MTL <= 100
  0 <= SPG <= 100
  0 <= TUR <= 100

Semi-continuous
  BEEF CHK FISH HAM MCH MTL SPG TUR
End

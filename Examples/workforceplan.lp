Minimize
  1 BeginMon + 1 BeginTue + 1 BeginWed + 1 BeginThurs + 1 BeginFri + 1 BeginSat + 1 BeginSun
Subject To
  Monday: 1 BeginMon + 1 BeginThurs + 1 BeginFri + 1 BeginSat + 1 BeginSun >= 14
  Tuesday: 1 BeginMon + 1 BeginTue + 1 BeginFri + 1 BeginSat + 1 BeginSun >= 13
  Wednesday: 1 BeginMon + 1 BeginTue + 1 BeginWed + 1 BeginSat + 1 BeginSun >= 15
  Thursday: 1 BeginMon + 1 BeginTue + 1 BeginWed + 1 BeginThurs + 1 BeginSun >= 16
  Friday: 1 BeginMon + 1 BeginTue + 1 BeginWed + 1 BeginThurs + 1 BeginFri >= 19
  Saturday: 1 BeginTue + 1 BeginWed + 1 BeginThurs + 1 BeginFri + 1 BeginSat >= 18
  Sunday: 1 BeginWed + 1 BeginThurs + 1 BeginFri + 1 BeginSat + 1 BeginSun >= 11

Bounds
  BeginMon >= 0
  BeginTue >= 0
  BeginWed >= 0
  BeginThurs >= 0
  BeginFri >= 0
  BeginSat >= 0
  BeginSun >= 0
Integers
  BeginMon BeginTue BeginWed BeginThurs BeginFri BeginSat BeginSun
End

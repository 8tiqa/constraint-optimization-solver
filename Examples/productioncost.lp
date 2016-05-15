Minimize
  2000 Regular_1 + 2000 Regular_2 + 2000 Regular_3 + 2000 Regular_4
   + 2200 Overtime_1 + 2200 Overtime_2 + 2200 Overtime_3 + 2200 Overtime_4
   + 100 Inventory_1 + 100 Inventory_2 + 100 Inventory_3
Subject To
 Period_1: Regular_1 + Overtime_1 - Inventory_1 = 2000
 Period_2: Regular_2 + Overtime_2 + Inventory_1 - Inventory_2 = 15000
 Period_3: Regular_3 + Overtime_3 + Inventory_2 - Inventory_3 = 10000
 Period_4: Regular_4 + Overtime_4 + Inventory_3 = 8000
Bounds
 Regular_1 <= 10000
 Regular_2 <= 10000
 Regular_3 <= 10000
 Regular_4 <= 10000
 Overtime_1 <= 2500
 Overtime_2 <= 2500
 Overtime_3 <= 2500
 Overtime_4 <= 2500
Generals
 Regular_1 Regular_2 Regular_3 Regular_4 Overtime_1 Overtime_2 Overtime_3
 Overtime_4 Inventory_1 Inventory_2 Inventory_3
End

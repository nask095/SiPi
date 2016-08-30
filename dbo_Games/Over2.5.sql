USE dbo_Games;
GO

Select Date, Game, [1], [2], Coeff_O25, HOver25, TOver25, AOver25, ATOver25
FROM Games
Where Coeff_GG/(((val2+val3+val4)*(ValB2+ValB3+ValB4)+(Sval2+Sval3+Sval4)*(SValB2+SValB3+SValB4)+(Fval2+Fval3+Fval4)*(FValB2+FValB3+FValB4)+(F8val2+F8val3+F8val4)*(F8ValB2+F8ValB3+F8ValB4))/4)<Coeff_NG/((Val1*(ValB1+ValB2+ValB3+ValB4)+ValB1*(Val2+Val3+Val4)+SVal1*(SValB1+SValB2+SValB3+SValB4)+SValB1*(SVal2+SVal3+SVal4)+FVal1*(FValB1+FValB2+FValB3+FValB4)+FValB1*(FVal2+FVal3+FVal4)+F8Val1*(F8ValB1+F8ValB2+F8ValB3+F8ValB4)+F8ValB1*(F8Val2+F8Val3+F8Val4))/4)

;

Select Date, Game, r1, r2, Coeff_O25, HOver25, TOver25, AOver25, ATOver25
FROM History
Where Coeff_GG/(((val2+val3+val4)*(ValB2+ValB3+ValB4)+(Sval2+Sval3+Sval4)*(SValB2+SValB3+SValB4)+(Fval2+Fval3+Fval4)*(FValB2+FValB3+FValB4)+(F8val2+F8val3+F8val4)*(F8ValB2+F8ValB3+F8ValB4))/4)<Coeff_NG/((Val1*(ValB1+ValB2+ValB3+ValB4)+ValB1*(Val2+Val3+Val4)+SVal1*(SValB1+SValB2+SValB3+SValB4)+SValB1*(SVal2+SVal3+SVal4)+FVal1*(FValB1+FValB2+FValB3+FValB4)+FValB1*(FVal2+FVal3+FVal4)+F8Val1*(F8ValB1+F8ValB2+F8ValB3+F8ValB4)+F8ValB1*(F8Val2+F8Val3+F8Val4))/4)
AND Date='3 Jan.'
;

Select Date, Game, r1, r2, Coeff_O25, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG
FROM History
Where Coeff_GG/(((val2+val3+val4)*(ValB2+ValB3+ValB4)+(Sval2+Sval3+Sval4)*(SValB2+SValB3+SValB4)+(Fval2+Fval3+Fval4)*(FValB2+FValB3+FValB4)+(F8val2+F8val3+F8val4)*(F8ValB2+F8ValB3+F8ValB4))/4)<Coeff_NG/((Val1*(ValB1+ValB2+ValB3+ValB4)+ValB1*(Val2+Val3+Val4)+SVal1*(SValB1+SValB2+SValB3+SValB4)+SValB1*(SVal2+SVal3+SVal4)+FVal1*(FValB1+FValB2+FValB3+FValB4)+FValB1*(FVal2+FVal3+FVal4)+F8Val1*(F8ValB1+F8ValB2+F8ValB3+F8ValB4)+F8ValB1*(F8Val2+F8Val3+F8Val4))/4)
AND Date='5 Jan.';
use dbo_Games;
GO

Select Date, Id, Game
From Games
Where Coeff_1=0 OR Coeff_X=0 OR Coeff_2=0 OR Coeff_GG=0 OR Coeff_NG=0 OR Coeff_O05=0 OR Coeff_O15=0 OR Coeff_O25=0 OR Coeff_U25=0 OR Coeff_U35=0 OR Coeff_U45=0
OR
Coeff_1=1 OR Coeff_X=1 OR Coeff_2=1 OR Coeff_GG=1 OR Coeff_NG=1 OR Coeff_O05=1 OR Coeff_O15=1 OR Coeff_O25=1 OR Coeff_U25=1 OR Coeff_U35=1 OR Coeff_U45=1; 
;

Select Time, Date, Game, Coeff_1, (Val2*ValB1+Val3*(ValB1+ValB2)+Val4*(ValB1+ValB2+ValB3)+SVal2*SValB1+SVal3*(SValB1+SValB2)+SVal4*(SValB1+SValB2+SValB3)+FVal2*FValB1+FVal3*(FValB1+FValB2)+FVal4*(FValB1+FValB2+FValB3)+F8Val2*F8ValB1+F8Val3*(F8ValB1+F8ValB2)+F8Val4*(F8ValB1+F8ValB2+F8ValB3))/4 as Result_1
From Games
Where (Val2*ValB1+Val3*(ValB1+ValB2)+Val4*(ValB1+ValB2+ValB3)+SVal2*SValB1+SVal3*(SValB1+SValB2)+SVal4*(SValB1+SValB2+SValB3)+FVal2*FValB1+FVal3*(FValB1+FValB2)+FVal4*(FValB1+FValB2+FValB3)+F8Val2*F8ValB1+F8Val3*(F8ValB1+F8ValB2)+F8Val4*(F8ValB1+F8ValB2+F8ValB3))/4>1/Coeff_1
AND Date='27 Dec.'
Order by Result_1;

Select Time, Date, Game, Coeff_2, (ValB2*Val1+ValB3*(Val1+Val2)+ValB4*(Val1+Val2+Val3)+SValB2*SVal1+SValB3*(SVal1+SVal2)+SValB4*(SVal1+SVal2+SVal3)+FValB2*FVal1+FValB3*(FVal1+FVal2)+FValB4*(FVal1+FVal2+FVal3)+F8ValB2*F8Val1+F8ValB3*(F8Val1+F8Val2)+F8ValB4*(F8Val1+F8Val2+F8Val3))/4 as Result_2
From Games
Where (ValB2*Val1+ValB3*(Val1+Val2)+ValB4*(Val1+Val2+Val3)+SValB2*SVal1+SValB3*(SVal1+SVal2)+SValB4*(SVal1+SVal2+SVal3)+FValB2*FVal1+FValB3*(FVal1+FVal2)+FValB4*(FVal1+FVal2+FVal3)+F8ValB2*F8Val1+F8ValB3*(F8Val1+F8Val2)+F8ValB4*(F8Val1+F8Val2+F8Val3))/4>1/Coeff_2
AND Date='27 Dec.'
Order by Result_2;

Select Time, Date, Game, Coeff_GG, ((val2+val3+val4)*(ValB2+ValB3+ValB4)+(Sval2+Sval3+Sval4)*(SValB2+SValB3+SValB4)+(Fval2+Fval3+Fval4)*(FValB2+FValB3+FValB4)+(F8val2+F8val3+F8val4)*(F8ValB2+F8ValB3+F8ValB4))/4 as GG
From Games
Where ((val2+val3+val4)*(ValB2+ValB3+ValB4)+(Sval2+Sval3+Sval4)*(SValB2+SValB3+SValB4)+(Fval2+Fval3+Fval4)*(FValB2+FValB3+FValB4)+(F8val2+F8val3+F8val4)*(F8ValB2+F8ValB3+F8ValB4))/4>1/Coeff_GG
AND Date='27 Dec.'
Order by GG
;

Select Time, Date, Game, Coeff_NG, (Val1*(ValB1+ValB2+ValB3+ValB4)+ValB1*(Val2+Val3+Val4)+SVal1*(SValB1+SValB2+SValB3+SValB4)+SValB1*(SVal2+SVal3+SVal4)+FVal1*(FValB1+FValB2+FValB3+FValB4)+FValB1*(FVal2+FVal3+FVal4)+F8Val1*(F8ValB1+F8ValB2+F8ValB3+F8ValB4)+F8ValB1*(F8Val2+F8Val3+F8Val4))/4 as NG
From Games
Where (Val1*(ValB1+ValB2+ValB3+ValB4)+ValB1*(Val2+Val3+Val4)+SVal1*(SValB1+SValB2+SValB3+SValB4)+SValB1*(SVal2+SVal3+SVal4)+FVal1*(FValB1+FValB2+FValB3+FValB4)+FValB1*(FVal2+FVal3+FVal4)+F8Val1*(F8ValB1+F8ValB2+F8ValB3+F8ValB4)+F8ValB1*(F8Val2+F8Val3+F8Val4))/4>1/Coeff_NG
AND Date='27 Dec.'
Order By NG

Select Time, Date, Game, Coeff_O05, ((1-Val1*ValB1)+(1-Sval1*svalB1)+(1-Fval1*FvalB1)+(1-F8val1*F8valB1))/4 as Result_05
From Games
Where ((1-Val1*ValB1)+(1-Sval1*svalB1)+(1-Fval1*FvalB1)+(1-F8val1*F8valB1))/4>1/Coeff_O05
AND Date='27 Dec.'
Order by Result_05

Select Time, Date, Game, Coeff_O15, ((1-val1*(valB1+valB2)-val2*valB1)+(1-Sval1*(SvalB1+SvalB2)-Sval2*SvalB1)+(1-Fval1*(FvalB1+FvalB2)-Fval2*FvalB1)+(1-F8val1*(F8valB1+F8valB2)-F8val2*F8valB1))/4 as Result_15
From Games
Where ((1-val1*(valB1+valB2)-val2*valB1)+(1-Sval1*(SvalB1+SvalB2)-Sval2*SvalB1)+(1-Fval1*(FvalB1+FvalB2)-Fval2*FvalB1)+(1-F8val1*(F8valB1+F8valB2)-F8val2*F8valB1))/4>1/Coeff_O15
AND Date='27 Dec.'
Order by Result_15

Select Time, Date, Game, Coeff_O25, ((1-val1*(valB1+valB2+valB3)-val2*(valB1*valB2)-val3*valB1)+(1-Sval1*(SvalB1+SvalB2+SvalB3)-Sval2*(SvalB1*SvalB2)-Sval3*SvalB1)+(1-Fval1*(FvalB1+FvalB2+FvalB3)-Fval2*(FvalB1*FvalB2)-Fval3*FvalB1)+(1-F8val1*(F8valB1+F8valB2+F8valB3)-F8val2*(F8valB1*F8valB2)-F8val3*F8valB1))/4 as Result_O25
From Games
Where ((1-val1*(valB1+valB2+valB3)-val2*(valB1*valB2)-val3*valB1)+(1-Sval1*(SvalB1+SvalB2+SvalB3)-Sval2*(SvalB1*SvalB2)-Sval3*SvalB1)+(1-Fval1*(FvalB1+FvalB2+FvalB3)-Fval2*(FvalB1*FvalB2)-Fval3*FvalB1)+(1-F8val1*(F8valB1+F8valB2+F8valB3)-F8val2*(F8valB1*F8valB2)-F8val3*F8valB1))/4>1/Coeff_O25
AND Date='27 Dec.'
Order by Result_O25

Select Time, Date, Game, Coeff_U25, (val1*(valB1+valB2+valB3)+val2*(valB1*valB2)+val3*valB1+Sval1*(SvalB1+SvalB2+SvalB3)+Sval2*(SvalB1*SvalB2)+Sval3*SvalB1+Fval1*(FvalB1+FvalB2+FvalB3)+Fval2*(FvalB1*FvalB2)+Fval3*FvalB1+F8val1*(F8valB1+F8valB2+F8valB3)+F8val2*(F8valB1*F8valB2)+F8val3*F8valB1)/4 as Result_U25
From History
Where (val1*(valB1+valB2+valB3)+val2*(valB1*valB2)+val3*valB1+Sval1*(SvalB1+SvalB2+SvalB3)+Sval2*(SvalB1*SvalB2)+Sval3*SvalB1+Fval1*(FvalB1+FvalB2+FvalB3)+Fval2*(FvalB1*FvalB2)+Fval3*FvalB1+F8val1*(F8valB1+F8valB2+F8valB3)+F8val2*(F8valB1*F8valB2)+F8val3*F8valB1)/4>1/Coeff_U25
AND Date='27 Dec.'
Order by Result_U25

Select Time, Date, Game, Coeff_U35, (val1*(valB1+valB2+valB3+valB4)+val2*(valB1+valB2+valB3)+val3*(valB1+valB2)+val4*valB1+Sval1*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval2*(SvalB1+SvalB2+SvalB3)+Sval3*(SvalB1+SvalB2)+Sval4*SvalB1+Fval1*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval2*(FvalB1+FvalB2+FvalB3)+Fval3*(FvalB1+FvalB2)+Fval4*FvalB1+F8val1*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val2*(F8valB1+F8valB2+F8valB3)+F8val3*(F8valB1+F8valB2)+F8val4*F8valB1)/4 as Result_35
From Games
Where (val1*(valB1+valB2+valB3+valB4)+val2*(valB1+valB2+valB3)+val3*(valB1+valB2)+val4*valB1+Sval1*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval2*(SvalB1+SvalB2+SvalB3)+Sval3*(SvalB1+SvalB2)+Sval4*SvalB1+Fval1*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval2*(FvalB1+FvalB2+FvalB3)+Fval3*(FvalB1+FvalB2)+Fval4*FvalB1+F8val1*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val2*(F8valB1+F8valB2+F8valB3)+F8val3*(F8valB1+F8valB2)+F8val4*F8valB1)/4>1/Coeff_U35
AND Date='27 Dec.'
Order by Result_35

Select Time, Date, Game, Coeff_U45, (val1*(valB1+valB2+valB3+valB4)+val2*(valB1+valB2+valB3+valB4)+val3*(valB1+valB2+valB3)+val4*(valB1+valB2)+Sval1*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval2*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval3*(SvalB1+SvalB2+SvalB3)+Sval4*(SvalB1+SvalB2)+Fval1*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval2*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval3*(FvalB1+FvalB2+FvalB3)+Fval4*(FvalB1+FvalB2)+F8val1*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val2*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val3*(F8valB1+F8valB2+F8valB3)+F8val4*(F8valB1+F8valB2))/4 as Result_45
From Games
Where (val1*(valB1+valB2+valB3+valB4)+val2*(valB1+valB2+valB3+valB4)+val3*(valB1+valB2+valB3)+val4*(valB1+valB2)+Sval1*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval2*(SvalB1+SvalB2+SvalB3+SvalB4)+Sval3*(SvalB1+SvalB2+SvalB3)+Sval4*(SvalB1+SvalB2)+Fval1*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval2*(FvalB1+FvalB2+FvalB3+FvalB4)+Fval3*(FvalB1+FvalB2+FvalB3)+Fval4*(FvalB1+FvalB2)+F8val1*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val2*(F8valB1+F8valB2+F8valB3+F8valB4)+F8val3*(F8valB1+F8valB2+F8valB3)+F8val4*(F8valB1+F8valB2))/4>1/Coeff_U45
AND Date='27 Dec.'
Order by Result_45


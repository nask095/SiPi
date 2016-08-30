USE dbo_Games;
GO

Select Date, Game, [1], [2], Coeff_U25, HOver25, TOver25, AOver25, ATOver25
From Games
Where Coeff_O05/(((1-Val1*ValB1)+(1-Sval1*svalB1)+(1-Fval1*FvalB1)+(1-F8val1*F8valB1))/4)+Coeff_O15/(((1-val1*(valB1+valB2)-val2*valB1)+(1-Sval1*(SvalB1+SvalB2)-Sval2*SvalB1)+(1-Fval1*(FvalB1+FvalB2)-Fval2*FvalB1)+(1-F8val1*(F8valB1+F8valB2)-F8val2*F8valB1))/4)+Coeff_O25/(((1-val1*(valB1+valB2+valB3)-val2*(valB1*valB2)-val3*valB1)+(1-Sval1*(SvalB1+SvalB2+SvalB3)-Sval2*(SvalB1*SvalB2)-Sval3*SvalB1)+(1-Fval1*(FvalB1+FvalB2+FvalB3)-Fval2*(FvalB1*FvalB2)-Fval3*FvalB1)+(1-F8val1*(F8valB1+F8valB2+F8valB3)-F8val2*(F8valB1*F8valB2)-F8val3*F8valB1))/4)>10
--AND Coeff_U25>1.49
;

Select Date, Game, r1, r2, Coeff_U25, HOver25, TOver25, AOver25, ATOver25
From History
Where Coeff_O05/(((1-Val1*ValB1)+(1-Sval1*svalB1)+(1-Fval1*FvalB1)+(1-F8val1*F8valB1))/4)+Coeff_O15/(((1-val1*(valB1+valB2)-val2*valB1)+(1-Sval1*(SvalB1+SvalB2)-Sval2*SvalB1)+(1-Fval1*(FvalB1+FvalB2)-Fval2*FvalB1)+(1-F8val1*(F8valB1+F8valB2)-F8val2*F8valB1))/4)+Coeff_O25/(((1-val1*(valB1+valB2+valB3)-val2*(valB1*valB2)-val3*valB1)+(1-Sval1*(SvalB1+SvalB2+SvalB3)-Sval2*(SvalB1*SvalB2)-Sval3*SvalB1)+(1-Fval1*(FvalB1+FvalB2+FvalB3)-Fval2*(FvalB1*FvalB2)-Fval3*FvalB1)+(1-F8val1*(F8valB1+F8valB2+F8valB3)-F8val2*(F8valB1*F8valB2)-F8val3*F8valB1))/4)>10
--AND Coeff_U25>1.49
AND Date='3 Jan.'
;

Select Date, Game, r1, r2, Coeff_U25, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG
From History
Where Coeff_O05/(((1-Val1*ValB1)+(1-Sval1*svalB1)+(1-Fval1*FvalB1)+(1-F8val1*F8valB1))/4)+Coeff_O15/(((1-val1*(valB1+valB2)-val2*valB1)+(1-Sval1*(SvalB1+SvalB2)-Sval2*SvalB1)+(1-Fval1*(FvalB1+FvalB2)-Fval2*FvalB1)+(1-F8val1*(F8valB1+F8valB2)-F8val2*F8valB1))/4)+Coeff_O25/(((1-val1*(valB1+valB2+valB3)-val2*(valB1*valB2)-val3*valB1)+(1-Sval1*(SvalB1+SvalB2+SvalB3)-Sval2*(SvalB1*SvalB2)-Sval3*SvalB1)+(1-Fval1*(FvalB1+FvalB2+FvalB3)-Fval2*(FvalB1*FvalB2)-Fval3*FvalB1)+(1-F8val1*(F8valB1+F8valB2+F8valB3)-F8val2*(F8valB1*F8valB2)-F8val3*F8valB1))/4)>10
--AND Coeff_U25>1.49
AND Date='2 Jan.'
;
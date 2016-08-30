USE dbo_Games;
GO

 Select Time, Game, Result, Coeff, (Val1*(ValB1+ValB2)+Val2*(ValB1)) AS MULTY1, (Sval1*(SvalB1+SvalB2)+Sval2*(SvalB1)) AS MULTY2, (Fval1*(FvalB1+FvalB2)+Fval2*(FvalB1)) AS MULTY3, (F8val1*(F8valB1+F8valB2)+F8val2*(F8valB1)) AS MULTY4, 
		((Val1*(ValB1+ValB2)+Val2*(ValB1))+ (Sval1*(SvalB1+SvalB2)+Sval2*(SvalB1))+(Fval1*(FvalB1+FvalB2)+Fval2*(FvalB1))+(F8val1*(F8valB1+F8valB2)+F8val2*(F8valB1))) AS Total, 
		(((Val1*(ValB1+ValB2+ValB3)+Val2*(ValB1+valB2)+Val3*ValB1)+ (SVal1*(SValB1+SValB2+SValB3)+SVal2*(SValB1+SvalB2)+SVal3*SValB1)+(FVal1*(FValB1+FValB2+FValB3)+FVal2*(FValB1+FvalB2)+FVal3*FValB1)+(F8Val1*(F8ValB1+F8ValB2+F8ValB3)+F8Val2*(F8ValB1+F8valB2)+F8Val3*F8ValB1))/4) AS AVERAGE --Game, Val3, valB3, Sval3, SvalB3, Fval3, FvalB3, F8val3, F8valB3--Result, Val1, Val2, ValB1, ValB2, Sval1, Sval2, SvalB1, SvalB2, Fval1, Fval2, FvalB1, FvalB2, F8val1, F8val2, F8valB1, F8valB2
From Games
Where Bet='Under: 3'
		AND Date='19 Dec.'
		AND Coeff!=0
		--AND Result>4
		AND (((Val1*(ValB1+ValB2+ValB3)+Val2*(ValB1+valB2)+Val3*ValB1)+ (SVal1*(SValB1+SValB2+SValB3)+SVal2*(SValB1+SvalB2)+SVal3*SValB1)+(FVal1*(FValB1+FValB2+FValB3)+FVal2*(FValB1+FvalB2)+FVal3*FValB1)+(F8Val1*(F8ValB1+F8ValB2+F8ValB3)+F8Val2*(F8ValB1+F8valB2)+F8Val3*F8ValB1))/4)>0.7
Order By Time
 ;
GO

Select Time, Game, Result, Coeff
From Games
Where Bet='Over: 1.5' 
		AND Date='19 Dec.'
		AND ((Val1*(ValB1+ValB2)+Val2*ValB1)+(SVal1*(SValB1+SValB2)+SVal2*SValB1)+(FVal1*(FValB1+FValB2)+FVal2*FValB1)+(F8Val1*(F8ValB1+F8ValB2)+F8Val2*F8ValB1))/4<0.3
Order By Time
;


 Select Time, Game, Result, Coeff, (Val1*(ValB1+ValB2+valB3+valB4)+Val2*(ValB1+ValB2+ValB3)+Val3*(ValB1+ValB2)) AS MULTY1, (SVal1*(SValB1+SValB2+SvalB3+SvalB4)+SVal2*(SValB1+SValB2+SValB3)+SVal3*(SValB1+SValB2)) AS MULTY2, (FVal1*(FValB1+FValB2+FvalB3+FvalB4)+FVal2*(FValB1+FValB2+FValB3)+FVal3*(FValB1+FValB2)) AS MULTY3, (F8Val1*(F8ValB1+F8ValB2+F8valB3+F8valB4)+F8Val2*(F8ValB1+F8ValB2+F8ValB3)+F8Val3*(F8ValB1+F8ValB2)) AS MULTY4, 
		((Val1*(ValB1+ValB2+valB3+valB4)+Val2*(ValB1+ValB2+ValB3)+Val3*(ValB1+ValB2))+(SVal1*(SValB1+SValB2+SvalB3+SvalB4)+SVal2*(SValB1+SValB2+SValB3)+SVal3*(SValB1+SValB2))+(FVal1*(FValB1+FValB2+FvalB3+FvalB4)+FVal2*(FValB1+FValB2+FValB3)+FVal3*(FValB1+FValB2))+(F8Val1*(F8ValB1+F8ValB2+F8valB3+F8valB4)+F8Val2*(F8ValB1+F8ValB2+F8ValB3)+F8Val3*(F8ValB1+F8ValB2))) AS Total, 
		(((Val1*(ValB1+ValB2+valB3+valB4)+Val2*(ValB1+ValB2+ValB3)+Val3*(ValB1+ValB2))+(SVal1*(SValB1+SValB2+SvalB3+SvalB4)+SVal2*(SValB1+SValB2+SValB3)+SVal3*(SValB1+SValB2))+(FVal1*(FValB1+FValB2+FvalB3+FvalB4)+FVal2*(FValB1+FValB2+FValB3)+FVal3*(FValB1+FValB2))+(F8Val1*(F8ValB1+F8ValB2+F8valB3+F8valB4)+F8Val2*(F8ValB1+F8ValB2+F8ValB3)+F8Val3*(F8ValB1+F8ValB2)))/4) AS AVERAGE --Game, Val3, valB3, Sval3, SvalB3, Fval3, FvalB3, F8val3, F8valB3--Result, Val1, Val2, ValB1, ValB2, Sval1, Sval2, SvalB1, SvalB2, Fval1, Fval2, FvalB1, FvalB2, F8val1, F8val2, F8valB1, F8valB2
From Games
Where Bet='Under: 4'
		AND Date='19 Dec.'
		AND Coeff!=0
		--AND Result>4 
		AND ((Val1*(ValB1+ValB2+valB3+valB4)+Val2*(ValB1+ValB2+ValB3)+Val3*(ValB1+ValB2))+(SVal1*(SValB1+SValB2+SvalB3+SvalB4)+SVal2*(SValB1+SValB2+SValB3)+SVal3*(SValB1+SValB2))+(FVal1*(FValB1+FValB2+FvalB3+FvalB4)+FVal2*(FValB1+FValB2+FValB3)+FVal3*(FValB1+FValB2))+(F8Val1*(F8ValB1+F8ValB2+F8valB3+F8valB4)+F8Val2*(F8ValB1+F8ValB2+F8ValB3)+F8Val3*(F8ValB1+F8ValB2)))/4>0.7
Order By Time
 ;


 Select Date,Game,Result
 From Games
 Where Val1<0.2 AND Sval1<0.2 AND Fval1<0.2 AND F8val1<0.2
		AND Date='17 Dec.'
 ;

 Select Date,Game,Result
 From Games
 Where ValB1<0.2 AND SvalB1<0.2 AND FvalB1<0.2 AND F8valB1<0.2
		AND Date='17 Dec.'

 ;
USE dbo_Games;
GO

INSERT INTO History
(Date,Time,Game, Bet,Result, r1, r2, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG, Val1, Val2, Val3, Val4, ValB1, valB2, ValB3, ValB4,Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4,Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_1, Coeff_X, Coeff_2, Coeff_GG, Coeff_NG, Coeff_O05, Coeff_O15, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45)
Select Date, Time, Game, Bet,Result, [1], [2], HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG, Val1, Val2, Val3, Val4, ValB1, valB2, ValB3, ValB4,Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4,Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_1, Coeff_X, Coeff_2, Coeff_GG, Coeff_NG, Coeff_O05, Coeff_O15, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45
 from Games
 where date='23 Jan.';

 /*
 INSERT INTO Games
(Date,Time,Game, Bet,Result, [1], [2], HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG, Val1, Val2, Val3, Val4, ValB1, valB2, ValB3, ValB4,Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4,Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_1, Coeff_X, Coeff_2, Coeff_GG, Coeff_NG, Coeff_O05, Coeff_O15, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45)
Select Date, Time, Game, Bet,Result, r1, r2, HOver25, TOver25, AOver25, ATOver25, HGG, TGG, AGG, ATGG, Val1, Val2, Val3, Val4, ValB1, valB2, ValB3, ValB4,Sval1, Sval2, Sval3, Sval4, SvalB1, SvalB2, SvalB3, SvalB4,Fval1, Fval2, Fval3, Fval4, FvalB1, FvalB2, FvalB3, FvalB4, F8val1, F8val2, F8val3, F8val4, F8valB1, F8valB2, F8valB3, F8valB4, Coeff_1, Coeff_X, Coeff_2, Coeff_GG, Coeff_NG, Coeff_O05, Coeff_O15, Coeff_O25, Coeff_U25, Coeff_U35, Coeff_U45
 from History
 Where Date='3 Jan.';
 */
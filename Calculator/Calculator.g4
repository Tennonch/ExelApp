grammar Calculator;

// Parser rules

compileUnit : expression EOF;

expression :
	operatorToken=(MOD | DIV) LPAREN expression COMMA expression RPAREN #ParenthesizedExpr
	| operatorToken=(INC | DEC) LPAREN expression RPAREN #ParenthesizedExprOneArg
	| expression EXPONENT expression #ExponentialExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
	; 

/*
 * Lexer Rules
 */

NUMBER : INT ('.' INT)?; 

MOD : 'mod' | 'MOD';
DIV : 'div' | 'DIV';
INC : 'inc' | 'INC';
DEC : 'dec' | 'DEC';

IDENTIFIER : [a-zA-Z]+[0-9]+;

INT : ('0'..'9')+;

EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
COMMA : ',';

WS : [ \t\r\n] -> channel(HIDDEN);

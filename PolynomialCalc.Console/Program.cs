﻿
using PolynomialCalc.Applicatiob;
using PolynomialCalc.Console;
using PolynomialCalc.Core;
using PolynomialCalc.Parsers;
using PolynomialCalc.Presenters;

Console.WriteLine("Welcome to Polynomial Calculator!");

//2x^3 + 5x^2 + 7y^2 - 3x - 5
Console.Write("Enter W1: ");
var firstPolynomialText = Console.ReadLine();
//4x^3 + 7x^2 - 5y^2 + 6x - 52
Console.Write("Enter W2: ");
var secondPolynomialText = Console.ReadLine();

var polynomialService = new PolynomialService(new PolynomialRegexParser(), new PolynomialCalculator());

var addingResult = polynomialService
        .SetOperation(OperationChooser.ChooseOperation('+'))
        .ExecuteOperation(firstPolynomialText, secondPolynomialText);

var subtractingResult = polynomialService
        .SetOperation(OperationChooser.ChooseOperation('-'))
        .ExecuteOperation(firstPolynomialText, secondPolynomialText);
        
var presenter = new PolynomialPresenter();

Console.WriteLine("Start calculation.");
Console.WriteLine();

Console.Write("W1 + W2 = ");
Console.WriteLine(presenter.RepresentAsString(addingResult));

Console.Write("W1 - W2 = ");
Console.WriteLine(presenter.RepresentAsString(subtractingResult));
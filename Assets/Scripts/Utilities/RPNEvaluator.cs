using UnityEngine;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System;


public class RPN
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int applyOperator(string token, int b, int a)
    {
       if (token == "+") {
			return a + b;
	   }
	   else if (token == "-") {
			return a - b;
	   }
	   else if (token == "*") {
			return a * b;
	   } else if (token == "/") {
	   		return a / b;
	   } else if (token == "%") {
			return a % b;
	   } else{
			return 0;
	   }
    }

    // Update is called once per frame
    public int evaluateRPN (Dictionary <string, int> variables, string expression) // add variables dict with expression
    {
		string[] operators = {"+", "-", "*", "/", "%"};
        Stack<int> RPNStack = new Stack<int>();
		foreach (string token in expression.Split(" ")) {
			if (variables.ContainsKey(token)){	// push to stack if int
				RPNStack.Push(variables[token]);
			}
			else if (token.Contains(token)) { // pop top two numbers if operator
				int a = RPNStack.Pop();
				int b = RPNStack.Pop();
				RPNStack.Push(applyOperator(token, b, a));
			} else {
				RPNStack.Push(int.Parse(token));
			}

		}

		return RPNStack.Pop();
    }
}

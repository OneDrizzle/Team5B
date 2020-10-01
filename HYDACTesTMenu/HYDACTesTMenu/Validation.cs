using System;
using System.Collections.Generic;
using System.Text;

namespace Valdation
{
    public class Valdation
    {
        private bool _returnBool;
        private int _returnValue;
        private int _MenuLength;
        string _returnMessage;
        public bool MenuInputValdation(string userInput, int MenuLength)
        {
            _MenuLength = MenuLength;

            if (int.TryParse(userInput, out int parseInput))
            {
                for (int i = 0; i < _MenuLength; i++)
                {
                    if (i > 1 || i < _MenuLength)
                    {
                        _returnMessage = "Forkert input! 1 - " + MenuLength + " Prøv igen.";
                        _returnBool = false;
                    }
                    else
                    {
                        _returnValue = parseInput;
                        _returnBool = true;
                    }
                }

            }
            else
            {
                _returnMessage = "Forkert input! Prøv igen.";
                _returnBool = false;
            }
            return _returnBool;

        }
        public int ReturnValue()
        {
            return _returnValue;
        }
        public string ReturnMessage()
        {
            return _returnMessage;
        }

    }
}


/*
 * InputValdationClass validate = new InputValdationClass();
 * if (validate.MenuInputValdation(Console.ReadLine(), 6))
 *      {      
 *          switch (validate.ReturnValue())
 *          {
 *              case 1:
 *                  Console.WriteLine("Menu 1")
 *                  Break;
 *              defualt:
 *                  Break;
 *          }
 *      }
 *      else
 *      {
 *      Console.WriteLine(validate.ReturnMessage());
 *      }
*/

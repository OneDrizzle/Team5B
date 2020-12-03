using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PinsameGUI
{
    public static class ValidatorExtensions
    {
        //This one checks if the entered string is an Email.
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            
            return (regex.IsMatch(s) && s.Contains("@")) ? true : false;


        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static string ProcessText(string input)
    {
        //Split the string on ""
        //put the strings into an array
        //go through the array and do try parse for each,
        //if it works increment a number

        //Determine whether user has input a word or a number,

        string phrase = "These are a bunch of words";
        string[] words = phrase.Split(' ');

        double total = 0;
        double average;

        
            foreach (string a in words)
            {
                total += a.Length;
            }

            if (words.Length > 0)
            {
                average = total / words.Length;
            }
        
        return input;

        string[] words = 
    }
}

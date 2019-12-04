using System;
using System.Globalization;

public class Utilities2
//The following example tries to convert each string in an array to a Double value. 
//It first tries to parse the string by using a format provider that reflects the conventions 
//of the English (United States) culture. If this operation throws a FormatException, it tries 
//to parse the string by using a format provider that reflects the conventions of the French (France) culture..
{
    public static void Main()
    {
        string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
        double number;
        CultureInfo culture = null;

        foreach (string value in values)
        {
            try
            {
                culture = CultureInfo.CreateSpecificCulture("en-US");
                number = Double.Parse(value, culture);
                Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0}: Unable to parse '{1}'.",
                                  culture.Name, value);
                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                try
                {
                    number = Double.Parse(value, culture);
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}: Unable to parse '{1}'.",
                                      culture.Name, value);
                }
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    en-US: 1,304.16 --> 1304.16
//    
//    en-US: Unable to parse '$1,456.78'.
//    fr-FR: Unable to parse '$1,456.78'.
//    
//    en-US: 1,094 --> 1094
//    
//    en-US: 152 --> 152
//    
//    en-US: Unable to parse '123,45 €'.
//    fr-FR: Unable to parse '123,45 €'.
//    
//    en-US: Unable to parse '1 304,16'.
//    fr-FR: 1 304,16 --> 1304.16
//    
//    en-US: Unable to parse 'Ae9f'.
//    fr-FR: Unable to parse 'Ae9f'.



public class Example
{
    public static void Main()
    {
        string value = "1,304";
        int number;
        IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
        if (Int32.TryParse(value, out number))
            Console.WriteLine("{0} --> {1}", value, number);
        else
            Console.WriteLine("Unable to convert '{0}'", value);

        if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                          provider, out number))
            Console.WriteLine("{0} --> {1}", value, number);
        else
            Console.WriteLine("Unable to convert '{0}'", value);
    }
}
// The example displays the following output:
//       Unable to convert '1,304'
//       1,304 --> 1304



public class Example
//The following example uses the Int32.Parse method to parse strings that consist 
//of digits in different writing systems. As the output from the example shows, the 
//attempt to parse the basic Latin digits succeeds, but the attempt to parse the Fullwidth, 
//Arabic-Indic, and Bangla digits fails.
{
    public static void Main()
    {
        string value;
        // Define a string of basic Latin digits 1-5.
        value = "\u0031\u0032\u0033\u0034\u0035";
        ParseDigits(value);

        // Define a string of Fullwidth digits 1-5.
        value = "\uFF11\uFF12\uFF13\uFF14\uFF15";
        ParseDigits(value);

        // Define a string of Arabic-Indic digits 1-5.
        value = "\u0661\u0662\u0663\u0664\u0665";
        ParseDigits(value);

        // Define a string of Bangla digits 1-5.
        value = "\u09e7\u09e8\u09e9\u09ea\u09eb";
        ParseDigits(value);
    }

    static void ParseDigits(string value)
    {
        try
        {
            int number = Int32.Parse(value);
            Console.WriteLine("'{0}' --> {1}", value, number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Unable to parse '{0}'.", value);
        }
    }
}
// The example displays the following output:
//       '12345' --> 12345
//       Unable to parse '１２３４５'.
//       Unable to parse '١٢٣٤٥'.
//       Unable to parse '১২৩৪৫'.



//The String.Split method creates an array of substrings by splitting the input
//string based on one or more delimiters. It is often the easiest way to separate 
//a string on word boundaries. It is also used to split strings on other specific characters or strings.
string phrase = "The quick brown fox jumps over the lazy dog.";
string[] words = phrase.Split(' ');

foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//Every instance of a separator character produces a value in the returned array. 
//Consecutive separator characters produce the empty string as a value in the returned array. 
//You can see this in the following example, which uses space as a separator:
string phrase = "The quick brown    fox     jumps over the lazy dog.";
string[] words = phrase.Split(' ');

foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//String.Split can use multiple separator characters. The following example uses spaces, commas, 
//periods, colons, and tabs, all passed in an array containing these separating characters, to Split. 
//The loop at the bottom of the code displays each of the words in the returned array.
char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

string text = "one\ttwo three:four,five six seven";
System.Console.WriteLine($"Original text: '{text}'");

string[] words = text.Split(delimiterChars);
System.Console.WriteLine($"{words.Length} words in text:");

foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//Consecutive instances of any separator produce the empty string in the output array:
char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

string text = "one\ttwo :,five six seven";
System.Console.WriteLine($"Original text: '{text}'");

string[] words = text.Split(delimiterChars);
System.Console.WriteLine($"{words.Length} words in text:");

foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//String.Split can take an array of strings (character sequences that act as separators for parsing 
//the target string, instead of single characters).
string[] separatingStrings = { "<<", "..." };

string text = "one<<two......three<four";
System.Console.WriteLine($"Original text: '{text}'");

string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
System.Console.WriteLine($"{words.Length} substrings in text:");

foreach (var word in words)
{
    System.Console.WriteLine(word);
}

//The following example demonstrates both successful and unsuccessful calls to Parse and TryParse.
public class StringConversion
{
    public static void Main()
    {
        string input = String.Empty;
        try
        {
            int result = Int32.Parse(input);
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{input}'");
        }
        // Output: Unable to parse ''

        try
        {
            int numVal = Int32.Parse("-105");
            Console.WriteLine(numVal);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        // Output: -105

        if (Int32.TryParse("-105", out int j))
            Console.WriteLine(j);
        else
            Console.WriteLine("String could not be parsed.");
        // Output: -105

        try
        {
            int m = Int32.Parse("abc");
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        // Output: Input string was not in a correct format.

        string inputString = "abc";
        if (Int32.TryParse(inputString, out int numValue))
            Console.WriteLine(inputString);
        else
            Console.WriteLine($"Int32.TryParse could not parse '{inputString}' to an int.");
        // Output: Int32.TryParse could not parse 'abc' to an int.
    }
}

//The following example illustrates one a approach to parsing a string that is expected to include 
//leading numeric characters (including hexadecimal characters) and trailing non-numeric characters. 
//It assigns valid characters from the beginning of a string to a new string before calling the TryParse 
//method. Because the strings to be parsed contain a small number of characters, the example calls 
//the String.Concat method to assign valid characters to a new string. For a larger string, the StringBuilder 
//class can be used instead.
public class StringConversion
{
    public static void Main()
    {
        var str = "  10FFxxx";
        string numericString = String.Empty;
        foreach (var c in str)
        {
            // Check for numeric characters (hex in this case) or leading or trailing spaces.
            if ((c >= '0' && c <= '9') || (Char.ToUpperInvariant(c) >= 'A' && Char.ToUpperInvariant(c) <= 'F') || c == ' ')
            {
                numericString = String.Concat(numericString, c.ToString());
            }
            else
            {
                break;
            }
        }
        if (int.TryParse(numericString, System.Globalization.NumberStyles.HexNumber, null, out int i))
            Console.WriteLine($"'{str}' --> '{numericString}' --> {i}");
        // Output: '  10FFxxx' --> '  10FF' --> 4351

        str = "   -10FFXXX";
        numericString = "";
        foreach (char c in str)
        {
            // Check for numeric characters (0-9), a negative sign, or leading or trailing spaces.
            if ((c >= '0' && c <= '9') || c == ' ' || c == '-')
            {
                numericString = String.Concat(numericString, c);
            }
            else
                break;
        }
        if (int.TryParse(numericString, out int j))
            Console.WriteLine($"'{str}' --> '{numericString}' --> {j}");
        // Output: '   -10FFXXX' --> '   -10' --> -10
    }
}

//The following example calls the Convert.ToInt32(String) method to convert an input string to an int. 
//The example catches the two most common exceptions that can be thrown by this method, FormatException 
//and OverflowException. If the resulting number can be incremented without exceeding Int32.MaxValue, 
//the example adds 1 to the result and displays the output.

public class ConvertStringExample1
{
    static void Main(string[] args)
    {
        int numVal = -1;
        bool repeat = true;

        while (repeat)
        {
            Console.Write("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive): ");

            string input = Console.ReadLine();

            // ToInt32 can throw FormatException or OverflowException.
            try
            {
                numVal = Convert.ToInt32(input);
                if (numVal < Int32.MaxValue)
                {
                    Console.WriteLine("The new value is {0}", ++numVal);
                }
                else
                {
                    Console.WriteLine("numVal cannot be incremented beyond its current value");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
            }

            Console.Write("Go again? Y/N: ");
            string go = Console.ReadLine();
            if (go.ToUpper() != "Y")
            {
                repeat = false;
            }
        }
    }
}
// Sample Output:
//   Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive): 473
//   The new value is 474
//   Go again? Y/N: y
//   Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive): 2147483647
//   numVal cannot be incremented beyond its current value
//   Go again? Y/N: y
//   Enter a number between -2,147,483,648 and +2,147,483,647 (inclusive): -1000
//   The new value is -999
//   Go again? Y/N: n


/////////////////////////////////////////week 2/////////////////////////////////////////
//variable scope

    if(meaningOfLife == 42) //if-block 
    {
        bool inScope = true;
    }

//structures
    struct Point2D //defines a 2D point that contains two properties.
{
    public int x;
    public int y;
}

//big difference between a structure and a class is how they are handled in memory. a structure
// is a value type, whereas a class is a reference type. a value type exists in the stack,
//whereas a reference type exists in the heap.


    // Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public Transform prefab;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}


//Instantiate is most commonly used to instantiate projectiles, AI Enemies, particle 
//explosions or wrecked object replacements.

using UnityEngine;

public class Example : MonoBehaviour
{
    // Instantiate a rigidbody then set the velocity

    Rigidbody projectile;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
    }
}

//Instantiate can also clone script instances directly. The entire game object hierarchy will 
//be cloned and the cloned script instance will be returned.

using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public int timeoutDestructor;

    // ...other code...
}


public class ExampleClass : MonoBehaviour
{
    // Instantiate a Prefab with an attached Missile script
    public Missile projectile;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Missile clone = (Missile)Instantiate(projectile, transform.position, transform.rotation);

            // Set the missiles timeout destructor to 5
            clone.timeoutDestructor = 5;
        }
    }
}
//After cloning an object you can also use GetComponent to set properties on a specific component 
//attached to the cloned object.




//You can also use Generics to instantiate objects.See the Generic Functions page for more details.

//In this example, we instantiate our Missile object again, but by using Generics we don't need to cast the result:

using UnityEngine;

public class Missile : MonoBehaviour
{
    // ...other code...
}

public class InstantiateGenericsExample : MonoBehaviour
{
    public Missile missile;

    void Start()
    {
        Missile missileCopy = Instantiate<Missile>(missile);
    }
}
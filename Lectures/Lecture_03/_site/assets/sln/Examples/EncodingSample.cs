using System;
using System.Text;

namespace Examples
{
    public class EncodingSample
    {
        public static void Main()
        {
            var unicodeString = "This string contains the unicode character Pi (\u03a0)";

            // Create two different encodings.
            var ascii = Encoding.ASCII;
            var unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            var unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            var asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            var asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            var asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine($"Original string: {unicodeString}");
            Console.WriteLine($"Ascii converted string: {asciiString}");

            // The example displays the following output:
            //    Original string: This string contains the unicode character Pi (Π)
            //    Ascii converted string: This string contains the unicode character Pi (?)
        }
    }
}
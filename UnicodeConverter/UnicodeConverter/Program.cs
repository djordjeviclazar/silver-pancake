//Microsoft (R) Visual C# Compiler version 3.4.0-beta4-19562-05 (ff930dec)
//Copyright (C) Microsoft Corporation. All rights reserved.

/*
 * Implementation is based on SO answers:
 * https://stackoverflow.com/questions/38533903/set-c-sharp-console-application-to-unicode-output
 * https://stackoverflow.com/a/2556329/13448436
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set console:
            // From SO: https://stackoverflow.com/questions/38533903/set-c-sharp-console-application-to-unicode-output
            Console.OutputEncoding = Encoding.Unicode;

            // Converter code:
            string actionToPerform = args[0].ToLower(); // encode / decode
            bool removeWhitespaces = args[1].ToLower() == "y"; // y - remove all whitespaces ; leave as it is
            string encodingType = args[2]; // BigEndianUnicode, Unicode, UTF7, UTF8, UTF32
            string inputValue = removeWhitespaces ? Regex.Replace(args[3], @"\s+", "") : args[3]; // input

            switch (actionToPerform)
            {
                case "encode":
                    Console.WriteLine(Encode(inputValue, encodingType));
                    break;
                case "decode":
                    Console.WriteLine(Decode(inputValue, encodingType));
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }

        static public string Encode(string word, string type)
        {
            if (String.IsNullOrEmpty(word))
                return "";

            Encoding enc = GetEncoding(type);

            byte[] wordBytes = enc.GetBytes(word);
            return GetBytesToString(wordBytes);
        }

        static public string Decode(string value, string type)
        {
            if (String.IsNullOrEmpty(value))
                return "";

            Encoding enc = GetEncoding(type);

            byte[] wordBytes = GetStringToBytes(value);
            return enc.GetString(wordBytes);
        }

        static public Encoding GetEncoding(string type)
        {
            switch (type)
            {
                case "BigEndianUnicode":
                    return Encoding.BigEndianUnicode;
                case "UTF32d":
                    return Encoding.UTF32;
                case "Unicode":
                    return Encoding.Unicode;
                case "UTF8":
                    return Encoding.UTF8;
                case "UTF7":
                    return Encoding.UTF7;
                default:
                    return Encoding.UTF8;
            }
        }

        /*
        From SO: https://stackoverflow.com/a/2556329/13448436
        */
        static public byte[] GetStringToBytes(string value)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }

        static public string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        }

    }
}
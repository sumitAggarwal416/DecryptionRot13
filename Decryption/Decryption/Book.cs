/*
 * I, Sumit Aggarwal, 000793607, certify that all code submitted is my own code and that I have not copied it from anywhere else.
 * I also certify that I have not allowed anyone to copy my code either.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Decryption
{
    /// <summary>
    /// creates a Book class which inherits its properties from Media class and IEncryptable Interface
    /// 
    /// reference: https://www.dotnetperls.com/rot13
    /// </summary>
    class Book:Media, IEncryptable
    {
        public string Author { get; private set; } // author of the book
        public string Summary { get; private set; } // summary of the book

        public Book(string title, int year,string author, string summary)
            :base(title,year)
        {
            Author = author;
            Summary = summary;
        }

        public override string ToString()
        {
            return "BOOK | " + base.ToString() + 
                $" | {Author} | {Decrypt()}"
                ;
        }

        public string Encrypt()
        {
            return "";
        }

        /// <summary>
        /// deciphers the rot13 algorithm to find the meaning behind the encrypted summary
        /// </summary>
        /// <returns>a decrypted summary which is read by the compiler while reading the file</returns>
        public string Decrypt()
        {
            char[] array = Summary.ToCharArray(); // converts the summary into an array of individual characters
            for (int i = 0; i < array.Length; i++) //iterates through the array until the last character is reached
            {
                int number = array[i];
                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

    }
}

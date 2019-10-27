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
    /// creates a Movie class which inherits its properties from Media class and IEncryptable Interface
    /// 
    /// reference: https://www.dotnetperls.com/rot13
    /// </summary>
    class Movie :Media, IEncryptable
    {
        public string Director { get; private set; } //director of the movie
        public string Summary { get; private set; } // summary of the movie

        public Movie(string title, int year, string director, string summary)
            :base(title, year)
        {
            Director = director;
            Summary = summary;
        }

        public override string ToString()
        {
            return "MOVIE | " + base.ToString() + 
                $" | {Director} | {Decrypt()}"
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
            char[] array = Summary.ToCharArray();// converts the summary into an array of individual characters
            for (int i=0; i < array.Length; i++) //iterates through the array until the last character is reached
            {
                int number = (int)array[i];
                if(number>='a' && number <= 'z'){
                    if (number > 'm'){
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if(number>='A' && number <= 'Z')
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

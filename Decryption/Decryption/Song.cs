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
    /// creates a Song class that inherits its properties from Media class
    /// </summary>
    class Song:Media
    {
        public string Album { get; private set; } //album of the song
        public string Artist { get; private set; } //artist of the song

        public Song(string title, int year, string album, string artist)
            :base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        public override string ToString()
        {
            return "SONG | " +  base.ToString()+
                $" | {Album} | {Artist}"
                ;
        }
    }
}

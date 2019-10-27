/*
 * I, Sumit Aggarwal, 000793607, certify that all code submitted is my own code and that I have not copied it from anywhere else.
 * I also certify that I have not allowed anyone to copy my code either.
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Decryption
{
    /// <summary>
    /// main method of the program
    /// </summary>
    class Program
    {
        private static int option;
        static List<Book> books = new List<Book>(); //list of all the books in the Data.txt
        static List<Song> songs = new List<Song>(); //list of all the songs in the Data.txt
        static List<Movie> movies = new List<Movie>(); //list of all the movies in the Data.txt
        static void Main(string[] args)
        {
            List<Media> media = new List<Media>(); //list of all the media in the Data.txt


            media = ReadData(media); //reads the file and stores the data in the media list

            bool isRunning = true; //loop control variable
            try
            {
                while (isRunning)
                {
                    Console.WriteLine("Sumit's Media Collection \n ===========================");
                    Console.WriteLine("1. List All Books\n" +
                        "2. List All Movies\n" +
                        "3. List All Songs\n" +
                        "4. List All Media\n" +
                        "5. Search All Media by Title\n" +
                        "6. Exit Program \n");

                    Console.WriteLine("Choose an option: ");
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            foreach (Book b in books) //iterates through every single item in the books list
                            {
                                if (b is Book) //confirms if b is a book or not
                                {
                                    Console.WriteLine(b + "\n");// overrides the ToString() and prints all the books
                                }
                                else
                                    break;
                            }
                            break;
                        case 2:
                            foreach (Movie m in movies) //iterates through every single item in the movies list
                            {
                                if (m is Movie) //confirms if m is a movie or not
                                {
                                    Console.WriteLine(m + "\n"); // overrides the ToString() and prints all the movies
                                }
                                else
                                    break;
                            }
                            break;
                        case 3:
                            foreach (Song s in songs) //iterates through every single item in the songs list
                            {
                                if (s is Song) //confirms if s is a song or not
                                {
                                    Console.WriteLine(s + "\n"); // overrides the ToString() and prints all the songs
                                }
                                else
                                    break;
                            }
                            break;
                        case 4:
                            foreach (Media m in media) //iterates through every single item in the media list
                            {
                                if (m is Media) //confirms if m is a media or not
                                {
                                    Console.WriteLine(m + "\n"); // overrides the ToString() and prints everything
                                }
                                else
                                    break;
                            }
                            break;
                        case 5:
                            Console.WriteLine("What is the title? \n"); //prompts the user to give a title
                            string input = Console.ReadLine();// stores what the user types
                            foreach(Media item in media) //iterates through every single Media item in the media list
                            {
                                if (item.Search(input)) //if the title is found, returns true and prints the item
                                {
                                    Console.WriteLine(item + "\n");
                                    break;
                                }
                                else 
                                {
                                    Console.WriteLine("Not Found");
                                }
                            }
                            break;
                        case 6:
                            isRunning = false; //exits the program
                            break;
                        default:
                            Console.WriteLine("Invalid Option. Please re-enter!");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// reads the data in the file and then stores it into the list
        /// </summary>
        /// <param name="array"> list of type Media</param>
        /// <returns></returns>
        static List<Media> ReadData(List<Media> array)
        {
            try
            {
                StreamReader fileInput = new StreamReader("Data.txt"); //opens the file

                while (!fileInput.EndOfStream) //while the compiler does not reach the end of the file
                {
                    string text = fileInput.ReadLine(); //reads the contents of file
                    string[] fields = text.Split('|'); //creates an array and stores the data based on where the '|' is
                    string summaryLine;
                    string completeSummary = "";
                    while (true)
                    {
                        summaryLine = fileInput.ReadLine();
                        if (summaryLine == "-----") // checks if the summary has ended and the next element has began or not
                            break;//gets out of the loop
                        completeSummary += summaryLine; // if not then adds the line to the end of the string
                    }
                    if (fields[0] == "BOOK") //if the first word of the line is "BOOK", then stores the data in books list as well as the array list which later becomes the media list
                    {
                        Media newBook = new Book(fields[1], int.Parse(fields[2]), fields[3], completeSummary);
                        array.Add(newBook);
                        books.Add((Book)newBook);
                    }
                    if (fields[0] == "MOVIE")//if the first word of the line is "MOVIE", then stores the data in movies list as well as the array list which later becomes the media list
                    {
                        Media newMovie = new Movie(fields[1], int.Parse(fields[2]), fields[3], completeSummary);
                        array.Add(newMovie);
                        movies.Add((Movie)newMovie);
                    }
                    if (fields[0] == "SONG") //if the first word of the line is "SONG", then stores the data in songs list as well as the array list which later becomes the media list
                    {
                        Media newSong = new Song(fields[1], int.Parse(fields[2]), fields[3], fields[4]);
                        array.Add(newSong);
                        songs.Add((Song)newSong);
                    }    
                }

                fileInput.Close(); // closes the file
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return array;
        }
    }
}

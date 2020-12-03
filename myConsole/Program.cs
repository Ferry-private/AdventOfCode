﻿using System;
using AoC;

namespace myConsole
{
    class Program
    {
        // https://adventofcode.com/
    
        static void Main(string[] args)
        {            
            AoC.Day1 day1 = new Day1();
            System.Console.WriteLine("Solution day 1, part 1: "+ day1.Problem1());
            System.Console.WriteLine("Solution day 1, part 2: "+ day1.Problem2());

            AoC.Day2 day2 = new Day2();
            System.Console.WriteLine("Solution day 2, part 1: "+ day2.Problem1());
            System.Console.WriteLine("Solution day 2, part 2: "+ day2.Problem2());

            AoC.Day3 day3 = new Day3();
            System.Console.WriteLine("Solution day 3, part 1: "+ day3.Problem1());
            System.Console.WriteLine("Solution day 3, part 2: "+ day3.Problem2());            
        }
    }
}
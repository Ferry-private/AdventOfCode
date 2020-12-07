using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC
{

    public class Shared
    {
        public static List<string> ReadFromFile(string filename)
        {
            string line;  
            List<string> inputFromFile = new List<string>();
                        
            // Read the file
            System.IO.StreamReader file = new System.IO.StreamReader(filename);  
            while((line = file.ReadLine()) != null)  
            {  
               inputFromFile.Add(line);
            }              
            file.Close(); 

            return inputFromFile;
        }
            
    }
    public class Day1
    {
        
        List<int> inputDay1 = new List<int> {2010,1856,1905,1786,1557,1995,1830,1971,1909,1500,1806,1846,2003,1839,1943,1977,1537,689,1861,1886,1815,1763,1834,1881,1952,1853,1775,1835,1874,1948,1978,347,1672,885,1709,1826,1911,1644,1064,1561,1966,1352,1347,1928,1756,615,1513,1932,1968,1762,1842,1475,1921,1716,1533,1975,1924,1850,1456,1783,1587,1913,1908,1502,1993,1635,1691,1706,1871,1857,1915,1604,1618,1902,1860,1648,1933,1999,1960,1389,1858,1793,1609,1484,1735,1535,1891,1879,1517,1766,1926,1668,1495,1585,1831,1308,1767,1479,1638,1600,710,1685,1818,1859,1822,1844,1550,1872,1719,1863,1987,199,1840,1817,1752,1612,1983,1838,1504,1997,716,1862,1931,1356,1645,1962,1574,1914,1869,1919,1487,1961,1728,1867,1177,1757,1316,1875,1991,1646,700,1972,2004,1577,118,1954,1483,1516,2007,1506,1588,1698,1725,2006,179,1849,1894,1695,1399,1726,1658,1920,1825,1837,1878,1591,1611,1409,1553,1705,1845,1718,1732,1639,1885,1929,1887,1787,1541,1946,1391,1884,1938,1496,1720,1669,1965,1967,1890,1743,1889,1970,1866,1912,1785,1998,1708,1810,1939,2005};

       

        public string Problem1()
        {
            //Done with Excel. Answer 157059
            for (int i = 0; i < inputDay1.Count; i++)
            {
                //Eerste nummer
                int firstNumber = inputDay1[i];
                for (int j = 0; j < inputDay1.Count; j++)
                {
                    int secondNumber = inputDay1[j];
                    if ((firstNumber + secondNumber) == 2020 )
                    {
                        return (firstNumber * secondNumber).ToString();                    }
                }
                
            }
            return "None Found";
        }

        public string Problem2()
        {
            for (int i = 0; i < inputDay1.Count; i++)
            {
                //Eerste nummer
                int firstNumber = inputDay1[i];
                for (int j = 0; j < inputDay1.Count; j++)
                {
                    int secondNumber = inputDay1[j];
                    for (int k = 0; k < inputDay1.Count; k++)
                    {
                        int thirdNumber = inputDay1[k];
                        if ((firstNumber + secondNumber + thirdNumber) == 2020 )
                        {
                            return (firstNumber * secondNumber * thirdNumber).ToString();                  
                        }
                    }   
                }                
            }
            return "No solution Found";
        }
    }

    public class Day2
    {
        public string Problem1()
        {
            int numberOfLines = 0;  
            int validPasswords = 0;
            string line;  
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"Day2input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                //System.Console.WriteLine(line); 
                string passwd = line.ToString();
                if (passwd.Split(":").Length > 2)  
                {
                    System.Console.WriteLine("Solution invalid! Error with passwd: " + line); 
                }

                if (IsValidOldPolicyPassword(passwd))
                {
                    validPasswords++;
                };

                numberOfLines++;  
            }              
            file.Close();  
            //System.Console.WriteLine("There were {0} passwords of which {1} were valid", numberOfLines, validPasswords);  
            return validPasswords.ToString();
        }

        public string Problem2()
        {
            int numberOfLines = 0;  
            int validPasswords = 0;
            string line;  
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"Day2input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                //System.Console.WriteLine(line); 
                string passwd = line.ToString();
                if (passwd.Split(":").Length > 2)  
                {
                    System.Console.WriteLine("Solution invalid! Error with passwd: " + line); 
                }

                if (IsValidNewPolicyPassword(passwd))
                {
                    validPasswords++;
                };

                numberOfLines++;  
            }  
            
            file.Close();  
            //System.Console.WriteLine("There were {0} passwords of which {1} were valid", numberOfLines, validPasswords);  
            return validPasswords.ToString();
        }
      
        private Boolean IsValidOldPolicyPassword(string passwdCheck)
        {
            var tempArray1 = passwdCheck.Split(":");
            string actualPassword = tempArray1[1];
            string rules = tempArray1[0];

            var tempArray2 = tempArray1[0].Split("-");
            var minimumOcc = Int32.Parse(tempArray2[0]);
            var maximumOcc = Int32.Parse(tempArray2[1].Split(" ")[0]);
            var charOcc = tempArray2[1].Split(" ")[1];

            var numberOcc = actualPassword.Split(charOcc).Length -1;

            return ((numberOcc >= minimumOcc) && (numberOcc <= maximumOcc));            
        }

        private Boolean IsValidNewPolicyPassword(string passwdCheck)
        {
            var tempArray1 = passwdCheck.Split(":");
            string actualPassword = tempArray1[1];
            string rules = tempArray1[0];

            var tempArray2 = tempArray1[0].Split("-");
            var firstOcc = Int32.Parse(tempArray2[0]);
            var secondOcc = Int32.Parse(tempArray2[1].Split(" ")[0]);
            var charOcc = tempArray2[1].Split(" ")[1];

            if (actualPassword.Length > secondOcc)
            {
                return ((actualPassword[firstOcc].ToString() == charOcc) ^ (actualPassword[secondOcc].ToString() == charOcc));
            }
            else if (actualPassword.Length > firstOcc)
            {
                return ((actualPassword[firstOcc].ToString() == charOcc));
            }
            else
            {
                return false;
            }                       
        }
    }

    public class Day3
    {
        public string Problem1()
        {          
            return numberOfTrees(1,3).ToString();
        }

        public string Problem2()
        {
          double solution;
          solution = numberOfTrees(1,1);
          solution *= numberOfTrees(1,3);
          solution *= numberOfTrees(1,5);
          solution *= numberOfTrees(1,7);
          solution *= numberOfTrees(2,1);

          return solution.ToString();
        }

        int numberOfTrees(int down, int right)
        {             
            string line;  
            string treeChar = "#";           
            
            int counter = 0;
            int numberOfTrees = 0;
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"Day3input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                for (int i = 1; i < down; i++)
                {
                    file.ReadLine();
                }

                if (line[counter].ToString() == treeChar)
                {
                    numberOfTrees++;
                } 
                counter = (counter + right) % line.Length;
            }  
            
            file.Close();  
            
            return numberOfTrees;
        }
    }

    public class Day4
    {
        public string Problem1()
        {        
            string line; 
            int validPassports = 0;
            //List<string> req = new List<string> {"byr","iyr","eyr","hgt","hcl","ecl","pid"};
            Dictionary<string,string> req = new Dictionary<string,string>();
            req["byr"] = "x";
            req["iyr"] = "x";
            req["eyr"] = "x";
            req["hgt"] = "x";
            req["hcl"] = "x";
            req["pid"] = "x";
            req["ecl"] = "x";


            System.IO.StreamReader file = new System.IO.StreamReader(@"Day4input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                if (line.Replace(" ","") == String.Empty) 
                {
                    //Done with Passport check
                    if (req.Count == 0)
                    {
                        validPassports++;
                    }
                    //init for new passportcheck
                    req["byr"] = "x";
                    req["iyr"] = "x";
                    req["eyr"] = "x";
                    req["hgt"] = "x";
                    req["hcl"] = "x";
                    req["pid"] = "x";
                    req["ecl"] = "x";
                }

                var fields = line.Split(" ");
                foreach (var field in fields)
                {
                    string found = field.Split(":")[0];
                    req.Remove(found);
                }               
            } 

            if (req.Count == 0)
            {
                validPassports++;
            } 
            
            file.Close();  
            
            return validPassports.ToString();
        }

        public string Problem2()
        {        
            string line; 
            int validPassports = 0;
            Boolean isValid = false;
            //List<string> req = new List<string> {"byr","iyr","eyr","hgt","hcl","ecl","pid"};
            Dictionary<string,string> req = new Dictionary<string,string>();
            req["byr"] = "x";
            req["iyr"] = "x";
            req["eyr"] = "x";
            req["hgt"] = "x";
            req["hcl"] = "x";
            req["pid"] = "x";
            req["ecl"] = "x";


            System.IO.StreamReader file = new System.IO.StreamReader(@"Day4input.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                if (line.Replace(" ","") == String.Empty) 
                {                  
                    //init for new passportcheck
                    req = new Dictionary<string,string>();
                    req["byr"] = "x";
                    req["iyr"] = "x";
                    req["eyr"] = "x";
                    req["hgt"] = "x";
                    req["hcl"] = "x";
                    req["pid"] = "x";
                    req["ecl"] = "x";
                    continue;
                }

                var fields = line.Split(" ");
                foreach (var field in fields)
                {
                    isValid = false;
                    var splitFields = field.Split(":");
                    string fieldName = splitFields[0];
                    string fieldValue = splitFields[1];
                    int fieldValueInt = 0;
                    Int32.TryParse(fieldValue,out fieldValueInt);

                    //Is value of field valid?
                    if (fieldName == "byr")
                    {
                        isValid = ((fieldValueInt >= 1920)&&(fieldValueInt <=2002)&&(fieldValue.Length==4));
                        
                    } 
                    else if (fieldName == "iyr")
                    {
                        isValid = ((fieldValueInt >= 2010)&&(fieldValueInt <=2020)&&(fieldValue.Length==4));
                    }
                    else if (fieldName == "eyr")
                    {
                        isValid = ((fieldValueInt >= 2020)&&(fieldValueInt <=2030)&&(fieldValue.Length==4));
                    }
                    else if (fieldName == "hgt")
                    {
                        if (fieldValue.EndsWith("cm"))
                        {
                            fieldValueInt = Int32.Parse(fieldValue.Substring(0,fieldValue.Length-2));
                            isValid = ((fieldValueInt >= 150)&&(fieldValueInt <=193));
                            
                        }
                        else if (fieldValue.EndsWith("in"))
                        {
                            fieldValueInt = Int32.Parse(fieldValue.Substring(0,fieldValue.Length-2));
                            isValid = ((fieldValueInt >= 59)&&(fieldValueInt <=76));
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    else if (fieldName == "hcl")
                    {
                        string pattern = @"^\#[a-f0-9]{6}$";
                        isValid = Regex.IsMatch(fieldValue,pattern);
                    }
                    else if (fieldName == "ecl")
                    {
                        string pattern = @"^(amb|blu|brn|gry|grn|hzl|oth)$";
                        isValid = Regex.IsMatch(fieldValue,pattern);
                    }
                    else if (fieldName == "pid")
                    {
                        string pattern = @"^[0-9]{9}$";
                        isValid = Regex.IsMatch(fieldValue,pattern);                        
                    }                    

                    if (isValid) 
                    {
                        req.Remove(fieldName);
                        //Done with Passport check?
                        if (req.Count == 0)
                        {
                            validPassports++;
                        }
                    }
                }                
            } 
            
            file.Close();  
            
            return validPassports.ToString();
        }


    }

  public class Day5
  {
      public string Problem1()
      {
          SortedList sl = new SortedList();
          string line;

          System.IO.StreamReader file = new System.IO.StreamReader(@"Day5input.txt");  
          while((line = file.ReadLine()) != null)  
            {  
                int seatId = CalculateSeatId(line);
                sl.Add(seatId,seatId);
            } 
            file.Close();  
            return sl.GetByIndex(sl.Count-1).ToString();
      }

      public string Problem2()
      {
          SortedList sl = new SortedList();
          string line;

          System.IO.StreamReader file = new System.IO.StreamReader(@"Day5input.txt");  
          while((line = file.ReadLine()) != null)  
            {  
                int seatId = CalculateSeatId(line);
                sl.Add(seatId,seatId);
            } 
            file.Close();  
            //Filled sorted list with SeatId's.
            //Loop through it to differ by 2

            int prevSeatId = 0;
            foreach (int item in sl.Values)
            {
                if (item - prevSeatId == 2)
                {
                    //Console.WriteLine($"Found my seat! {item-1}");
                    return (item-1).ToString();
                }
                prevSeatId = item;
            }
        
            return "No Seat found";
      }

      int CalculateSeatId(string boardingpass)
      {
        int minRow = 0;
        int maxRow = 127;
        int minSeat = 0;
        int maxSeat = 7;

        for (int i = 0; i < boardingpass.Length; i++)
        {
            if (boardingpass[i].ToString() == "B")
            {
                minRow = minRow+((maxRow-minRow+1)/2);
            }
            else if (boardingpass[i].ToString() == "F")
            {
                maxRow = maxRow-(maxRow-minRow+1)/2;
            }
            else if (boardingpass[i].ToString() == "L")        
            {
                maxSeat = maxSeat-((maxSeat-minSeat+1)/2);
            }
            else if (boardingpass[i].ToString() == "R")
            {
                minSeat = minSeat+((maxSeat-minSeat+1)/2);
            }     
        }

      return (minRow*8)+minSeat;
      }  
  }
  
    public class Day6
 {   
        public string Problem1()
        {
            var inputArray = Shared.ReadFromFile("Day6input.txt");
            List<string> uniqueList = new List<string>();
            int totalRightUniqueAnswers = 0;
            string uniqueThisGroup = String.Empty;

            foreach (var line in inputArray)
            {
                if (line.Trim().Length > 0)
                {
                    //get line and parse it
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (!(uniqueThisGroup.Contains(line[i])))
                        {
                            uniqueThisGroup += line[i];
                        }               
                        
                    }
                    uniqueList.Add(uniqueThisGroup);
                }
                else
                {
                    //Lege regel, dus groep afsluiten en volgende groep
                    totalRightUniqueAnswers += uniqueThisGroup.Length;
                    uniqueThisGroup = String.Empty;
                }
                
            }

            totalRightUniqueAnswers += uniqueThisGroup.Length;

            return totalRightUniqueAnswers.ToString();
        }

        public string Problem2()
        {
            List<string> input = Shared.ReadFromFile("Day6input.txt");
            string matchingAnswers = String.Empty;
            int solutionSum = 0;

            for (int i = 0; i < input.Count; i++)
            {
                //First line of group
                if ((i==0) || (input[i-1].Trim()==String.Empty))
                {
                    //Eerste regel van een group.
                    matchingAnswers = input[i];
                }
                else if (input[i].Trim().Length ==0)
                {        
                    //Group divider            
                    continue;
                } 
                else
                {
                    //Niet de eerste regel van een group
                    string prevMatchingAnswers = matchingAnswers;
                    matchingAnswers = String.Empty;
                    for (int j = 0; j < prevMatchingAnswers.Length; j++)
                    {
                        if (input[i].Contains(prevMatchingAnswers[j]))
                        {
                            matchingAnswers += prevMatchingAnswers[j];
                        }
                    }   
                }

                //Last line of group
                if ((i == (input.Count-1)) || (input[i+1].Trim()==String.Empty))
                {
                    //Laatste regel van deze group
                    solutionSum += matchingAnswers.Length;
                    //Console.WriteLine($"{matchingAnswers}: {matchingAnswers.Length}");
                    matchingAnswers = String.Empty;
                }
            }
            return solutionSum.ToString();
        }
    } //Close class Day6


    
   
} //Close Namespace
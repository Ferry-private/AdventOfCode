using System;
using System.Collections;
using System.Collections.Generic;

namespace AoC
{
    public class Day1
    {
        
        List<int> inputDay1 = new List<int> {1632,1438,1811,1943,1883,1698,1976,1972,1794,1726,1850,1789,1524,1701,1454,1594,1655,1018,1828,1867,1959,1541,1596,1998,1916,1894,1727,1812,1800,1897,1534,1712,1825,1629,1827,81,1855,1621,1694,1663,1793,1685,1616,1899,1688,1652,1719,1589,1649,1742,1905,922,1695,1747,1989,1968,1678,1709,1938,1920,1429,1556,2005,1728,1484,1746,1702,1456,1917,1670,1433,1538,1806,1667,1505,963,1478,2003,1955,1689,1490,1523,1615,1784,1624,583,1465,1443,1489,1873,1485,1773,1704,352,505,1705,1844,1599,1778,1846,1533,1535,1965,1987,828,1755,1823,1639,1981,1763,1758,1819,1569,1580,358,1786,1964,1604,1805,1822,1941,1993,1939,1975,1966,1852,1310,1687,1718,641,1715,1995,1603,1444,1641,1961,1536,1771,1267,1749,1944,1519,1445,1818,1558,1922,1452,1901,1915,1957,1840,1785,1946,1683,1918,1847,1690,1716,1627,1571,1985,1455,435,1856,1527,1660,1555,1557,1591,1906,1646,1656,1620,1618,1598,1606,1808,1509,1551,1723,1835,1610,1820,1942,1767,1549,1607,1781,1612,1864,2007,1908,1650,1449,1886,1878,1895,1869,1469,1507};

       

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
    
}
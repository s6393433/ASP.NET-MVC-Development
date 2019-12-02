using System;

// Задача: реализовать метод FindMinMax, который должен возвращать минимальное и максимальное значение в массиве вложенных массивов (jagged array).
//   * Метод должен возвращать true, если он содержит хотя бы одно числовое значение.
//   * Метод должен пропускать null значения в массиве.
//   * Метод должен выбрасывать исключение ArgumentNullException в случае, если в метод передали null.
//   * В решении разрешается использовать только конструкции языка. Использовать LINQ запрещено.

public class Program
{
    public static bool FindMinMax(int[][] array, out int min, out int max)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        bool start = true;
        bool ret;
        int minValue, maxValue;
        minValue = 0;
        maxValue = 0;
        ret = false;
        if (array.Length > 0 && array[0]!=null)
        {
            int i = 0;
            int j = 0;
            foreach (int[] subarray in array)
            {
                if (subarray!=null)
                {
                    foreach (int iVal in subarray)
                    {
                        if (array[i][j] * 0 == 0)
                        {
                            if (start)
                            {
                                ret = true;
                                minValue = array[i][j];
                                maxValue = array[i][j];
                                start = false;
                            }
                            else
                            {
                                ret = true;
                                if (minValue > iVal)
                                {
                                    minValue = (int)iVal;
                                }
                                if (maxValue < iVal)
                                {
                                    maxValue = (int)iVal;
                                }
                            }

                        }
                        j++;
                    }
                }
                i++;
            }
        }
        if (ret)
        {
            min = minValue;
            max = maxValue;
            return true;
        }
        min = 0;
        max = 0;
        return false;
    }
	// ДОБАВЬТЕ НОВЫЕ МЕТОДЫ, ЕСЛИ НЕОБХОДИМО

	// ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

	public static void Main()
	{
		Console.WriteLine("Task is done when all test cases are correct:");
		
		int testCaseNumber = 1;

		TestReturnedValues(testCaseNumber++, new int[][] { }, false, 0, 0);
		TestReturnedValues(testCaseNumber++, new int[][] { null }, false, 0, 0);
		TestReturnedValues(testCaseNumber++, new int[][] { new int[] { } }, false, 0, 0);
		TestReturnedValues(testCaseNumber++, new int[][] { new int[] { 1 } }, true, 1, 1);
		TestReturnedValues(testCaseNumber++, new int[][] { null, new int[] { } }, false, 0, 0);
		TestReturnedValues(testCaseNumber++, new int[][] { new int[] { }, null }, false, 0, 0);
		TestReturnedValues(testCaseNumber++, new int[][] { new int[] { 2 }, new int[] { 1 } }, true, 1, 2);
		TestReturnedValues(testCaseNumber++, new int[][]
			{
				new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
				new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
				new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
				new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
			} , true, 1, 14);
		TestReturnedValues(testCaseNumber++, new int[][]
			{
				new int[] { 7, 395, 1, 9, 6, 62, 71, 80, 918 },
				new int[] { 102, 72, 84, 41, 89, 382, 7, 36, 53, 10, 1101, 93, 23, 1401 },
				new int[] { 942, 29, 3, 346, 53, 6, 73, 897, 384, 052, 3, 501 },
				new int[] { 39, 83, 11, 28, 385, 0, 5, 482, 947, 143 }
			} , true, 0, 1401);
		TestException<ArgumentNullException>(testCaseNumber++, null);

		if (correctTestCaseAmount == testCaseNumber - 1)
		{
			Console.WriteLine("Task is done.");
		}
		else
		{
			Console.WriteLine("TASK IS NOT DONE.");
		}
	}
	
	private static void TestReturnedValues(int testCaseNumber, int[][] array, bool expectedResult, int expectedMin, int expectedMax)
	{
		try
		{
			int min, max;
			var result = FindMinMax(array, out min, out max);
			
			if (result == expectedResult && expectedMin == min && expectedMax == max)
			{
				Console.WriteLine(correctCaseTemplate, testCaseNumber);
				correctTestCaseAmount++;
			}
			else
			{
				Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
			}
		}
		catch(Exception)
		{
			Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
		}
	}

	private static void TestException<T>(int testCaseNumber, int[][] array) where T : Exception
	{
		try
		{
			int min, max;
			var result = FindMinMax(array, out min, out max);
			Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
		}
		catch (ArgumentException)
		{
			Console.WriteLine(correctCaseTemplate, testCaseNumber);
			correctTestCaseAmount++;
		}
		catch (Exception)
		{
			Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
		}
	}

	private static string correctCaseTemplate = "Case #{0} is correct.";
	private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
	private static int correctTestCaseAmount = 0;
}

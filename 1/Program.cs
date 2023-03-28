using System;

class Program
{
	static void Main()
	{
		int x = 100, y = 1000;
		for (int i = x; i <= y; i++)
		{
			if (IsPrime(i))
			{
				Console.WriteLine(i);
			}
		}
	}

	static bool IsPrime(int n)
	{
		if (n < 2) return false;
		if (n == 2) return true;
		if (n % 2 == 0) return false;
		for (int i = 3; i <= Math.Sqrt(n); i += 2)
		{
			if (n % i == 0) return false;
		}
		return true;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PairsumoniousNumbers
{
	public class Program
	{
		// Find all elements in sum that dont have conflict into the pair
		private static List<int> FilterConflict(int smallest, List<int> sum)
		{
			List<int> parameters = new List<int>();
			parameters.Add(smallest);

			while (sum.Count > 0)
			{
				int next = sum[0] - parameters[0];
				for (int i = 0; i < parameters.Count; i++)
				{
					var removeIndex = sum.IndexOf(next + parameters[i]);
					if (removeIndex >= 0) {
						sum.RemoveAt(removeIndex);
						sum.TrimExcess();
					}
					else
					{
						parameters.Clear();
						return parameters;
					}
				}
				parameters.Add(next);
			}
			return parameters;
		}

		// Enumerate the array P[2] to P[N+1] as A[1] + A[2], if they are pair-able
		private static string CalculatePairsumonious(List<int> sum, int capacity)
		{
			// Sort in crescent order, start from the smallest
			sum.Sort();
			string result = "";
			bool found = false;
			for (int i = 2; i < (capacity); i++)
			{
				List<int> answer;

				int tmp = sum[0] + sum[1] - sum[i];
				// Its pair-able
				if (tmp % 2 == 1) continue;

				// Filter any conflicts given half of the smallest
				answer = FilterConflict(tmp / 2, sum);
				result = String.Join(" ", answer.ToArray());
				if (answer.Count > 0)
				{
					for (int j = 0; j < answer.Count; j++)
					{
						Console.Write(answer[j]);
						if (j < (answer.Count - 1)) Console.Write(" ");
					}
					Console.Write('\n');
					found = true;
					break;
				}
			}
			if (!found) Console.WriteLine("Impossible");

			//result = result.Substring(0, result.Length - 1);
			result += "\n";
			return result;
		}

		public static string EntrancePoint(string userInput)
		{
			var inputAux = userInput.Split(' ');
			int capacity = Convert.ToInt32(inputAux[0]);
			int counter = 0;
			List<int> sum = new List<int>();

			capacity = (capacity * (capacity - 1) / 2);
			sum.Clear();

			foreach (var tmp in inputAux.Skip(1))
			{
				int value = Convert.ToInt32(tmp);
				sum.Add(value);
			}

			string result = CalculatePairsumonious(sum, capacity);
			if (result == "\n") result = "Impossible\n";
			return result;
		}

		//static void Main(string[] args)
		//{
		//	string userInput = "5 79950 79936 79942 79962 79954 79972 79960 79968 79924 79932";

		//	string result = EntrancePoint(userInput);


		//	var inputAux = userInput.Split(' ');
		//	int capacity = Convert.ToInt32(inputAux[0]);
		//	int counter = 0;
		//	List<int>sum = new List<int>();

		//	capacity = (capacity * (capacity - 1) / 2);
		//	sum.Clear();

		//	foreach(var tmp in inputAux.Skip(1))
		//	{
		//		int value = Convert.ToInt32(tmp);
		//		sum.Add(value);
		//	}

		//	CalculatePairsumonious(sum, capacity);
		//}
	}
}

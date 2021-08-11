using System;
public class NumStr
{
	 public static bool CheckValidNumStr(string val, bool allow_zero, int max_length=int.MaxValue)
    {
		foreach(char c in val)
        {
			if (c < '0' || c > '9') return false;
			int r =(int) (c - '0');
			if (r == 0 && !allow_zero) return false;
			if (val.Length > max_length) return false;
        }
		return true;
    }
	 public static int[] Str2IntList(string str)
	{
		char[] ca = str.ToCharArray();
		int[] p = new int[ca.Length];
		for(int i = 0;i < ca.Length; i++)
        {
			p[i] = ca[i] - '0';
        }
		return p;
	}

	public static float[] Str2floatList(string str)
	{
		char[] ca = str.ToCharArray();
		float[] p = new float[ca.Length];
		for (int i = 0; i < ca.Length; i++)
		{
			p[i] = (float) (ca[i] - '0');
		}
		return p;
	}

	public static void Str2floatList(string str, float[,] p, int index)
    {
		for (int i = 0; i < str.Length; i++)
		{
			p[index, i] = (float)(str[i] - '0');
		}
	}

	public static string IntList2Str(int[] input)
    {
		string result = "";
		for(int i=0;i<input.Length;i++)
        {
			result += (char)(input[i] + '0');
        }
		return result;
    }

	public static string FloatList2Str(float[] input)
    {
		string result = "";
		for (int i = 0; i < input.Length; i++)
		{
			result += (char)(Math.Round(input[i]) + '0');
		}
		return result;
	}

	public static string FloatList2Str(float[,] input, int index)
	{
		string result = "";
		for (int i = 0; i < input.GetLength(1); i++)
		{
			result += (char)(Math.Round(input[index, i]) + '0');
		}
		return result;
	}

	public static int GetMaxIntFromStr(string str)
    {
		int max_val = str[0] - '0';
		foreach (char c in str)
		{
			if (max_val < c - '0')
            {
				max_val = c - '0';
            }
		}
		return max_val;
	}
}

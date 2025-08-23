namespace Leetcode.Problems
{
    static class LongestCommonPrefix
    {
        public static string Implementation(string[] strs)
        {

            if (strs == null || strs.Length == 0) return "";

            var commonPrefix = strs[0];

            //using byte for memory saving, as strs.length <= 200 && strs[i].length <= 200
            for (byte i = 1; i < strs.Length && commonPrefix.Length > 0; i++)
            {
                var nextWord = strs[i];
                byte j = 0;


                while (j < nextWord.Length && j < commonPrefix.Length && commonPrefix[j] == nextWord[j]){
                    j++; //instead of just substring, calculate the total diff and then substring. This solves case ["a", "ab"]
                }

                commonPrefix = commonPrefix.Substring(0, j);
            }

            return commonPrefix;
        }

        public static string SugarCoatImplementation(string[] strs){
            for (byte i = 1; i < strs.Length && strs[0].Length > 0; i++)
            {
                byte j = 0;
                while (j < strs[i].Length && j < strs[0].Length && strs[0][j] == strs[i][j]) j++;
                strs[0] = strs[0].Substring(0, j);
            }

            return strs[0];
        }
    }
}

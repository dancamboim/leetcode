namespace LeetcodeExercices
{
    class LongestCommonPrefix
    {
        public string Implementation(string[] strs)
        {
            var commonPrefix = strs[0];

            for (var i = 1; i < strs.Length || commonPrefix.Length == 0; i++)
            {
                for (var j = 0; j < commonPrefix.Length; j++)
                {
                    if (commonPrefix[j] != strs[i][j])
                        commonPrefix = commonPrefix.Substring(0, j);
                }
            }

            return commonPrefix;
        }
    }
}

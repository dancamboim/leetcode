public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        //O(n²)
        // for (var i = 0; i < nums.Length; i++)
        // {
        //     for (var j = i + 1; j < nums.Length; j++)
        //     {
        //         if ((nums[i] + nums[j]) == target)
        //         {
        //             return new int[] { i, j };
        //         }
        //     }
        // }
        // return new int[0];

        //O(n)
         var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++){
            int complement = target - nums[i];

            if(map.ContainsKey(complement)) {
                return new int[] {map[complement], i};
            }

            if (map.ContainsKey(nums[i]) == false){
                map[nums[i]] = i;
            }
        }

        return new int[0];
    }
}
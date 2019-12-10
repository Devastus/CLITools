namespace CLITools
{
    static class Util
    {
        /// <summary>
        /// Slice and return a given range from an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">Array to slice</param>
        /// <param name="start">Range start index</param>
        /// <param name="end">Range end index, defaults to the length of the array</param>
        /// <returns></returns>
        public static T[] Slice<T>(this T[] self, int start, int end = -1)
        {
            if (self == null || end == 0) return null;
            if (end < 0) end = self.Length;

            int length = end - start; 
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                int index = i + start;
                result[i] = self[index];
            }
            return result;
        }

    }
}

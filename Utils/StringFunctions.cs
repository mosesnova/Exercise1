using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class StringFunctions
    {
        public static int CountPrecedingSpaces(string? text)
        {
            if (text == null) return 0;
            int spacesCount = 0;
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ') spacesCount++;
                if (text[i] != ' ') break;
            }
            return spacesCount;
        }

        public static int CountTrailingSpaces(string? text)
        {
            if (text == null) return 0;
            int spacesCount = 0;
            for (int i = text.Length -1; i >= 0; i--)
            {
                if (text[i] == ' ') spacesCount++;
                if (text[i] != ' ') break;
            }
            return spacesCount;
        }
    }
}

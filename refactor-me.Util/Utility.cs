using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Util
{
    public static class Utility
    {
        public static string RemoveAccents(this string text)
        {
            if (text != null)
            {
                StringBuilder sbReturn = new StringBuilder();
                var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();

                foreach (char letter in arrayText)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                        sbReturn.Append(letter);
                }
                return sbReturn.ToString();
            }

            return String.Empty;
        }

        public static bool IsEmpty(this String str)
        {
            return String.IsNullOrEmpty(str) || (String.IsNullOrWhiteSpace(str));
        }

        public static String Normalize(this String str)
        {
            return str.Trim().RemoveAccents().ToUpper();
        }

        public static bool CompareInsensitive(object obj, string strCompare, bool removeAccents = false)
        {
            if (!strCompare.IsEmpty())
            {
                if (obj != null && Convert.ToString(obj).IsEmpty())
                    return false;

                if (obj == null)
                    return false;

                strCompare = strCompare.Normalize();

                return removeAccents
                    ? (obj ?? strCompare).ToString().Normalize().Contains(strCompare)
                    : (obj ?? strCompare).ToString().Trim().ToUpper().Contains(strCompare);

            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

    }
}

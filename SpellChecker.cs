using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP
{
    class SpellChecker
    {
   // ***************************Start (Function Multiple Minimum edit Distance)********************//
        // ***************************Start (Function Multiple Minimum edit Distance) *******************//
        // ***************************Start (Function Multiple Minimum edit Distance) *******************//
        public int getMinEditDistance(string target, string source)
        {
            // insert # before target word
            char[] tmp = target.ToArray();
            List<char> forTarget = new List<char>(tmp);
            forTarget.Insert(0, '#');
            char[] targetArray = forTarget.ToArray();

            // insert # before source word
            char[] tmp1 = source.ToArray();
            List<char> forSource = new List<char>(tmp1);
            forSource.Insert(0, '#');
            char[] sourceArray = forSource.ToArray();

            int sub_const;
            int n = targetArray.Length;           // n is target length & m is source length
            int m = sourceArray.Length;
            int[,] distance = new int[n, m];
            distance[0, 0] = 0;
            for (int i = 1; i < n; i++)
                distance[i, 0] = distance[i - 1, 0] + 1;

            for (int j = 1; j < m; j++)
                distance[0, j] = distance[0, j - 1] + 1;

            for (int i = 1; i < n; i++) // i in actual is denoting rows
            {
                for (int j = 1; j < m; j++) // j in actual denoting columns
                {
                    if (targetArray[i] == sourceArray[j]) // to understand order of target[i] and source[j] is very critical to understand
                        sub_const = 0;
                    else
                        sub_const = 2;

                    int a = Math.Min(distance[i - 1, j] + 1, distance[i - 1, j - 1] + sub_const);
                    distance[i, j] = Math.Min(a, distance[i, j - 1] + 1);
                }
            }
            return distance[n - 1, m - 1];// we created of this size
        }

        // ***************************End (Function Multiple Minimum edit Distance) *******************//
        // ***************************End (Function Multiple Minimum edit Distance) *******************//
        // ***************************End (Function Multiple Minimum edit Distance) *******************//


        // ********************************Start (function Soundex)*******************************//
        // ********************************Start (function Soundex)*******************************//
        // ********************************Start (function Soundex)*******************************//

        public char[] soundex(string forSoundex)
        {
            char[] for_soundex = forSoundex.ToCharArray();
            List<char> tmp = new List<char>(for_soundex);

            char[] code = new char[5] { '0', '0', '0', '0', '0' };
            int m = 0;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (i == 0)
                {
                    if (tmp[i] == '\u062b' || tmp[i] == '\u0633' || tmp[i] == '\u0635' || tmp[i] == '\u0634')
                        code[m] = '1';
                    else if (tmp[i] == '\u062a' || tmp[i] == '\u0637' || tmp[i] == '\u0679' || tmp[i] == '\u0629')
                        code[m] = '2';
                    else if (tmp[i] == '\u0632' || tmp[i] == '\u0636' || tmp[i] == '\u0638' || tmp[i] == '\u0630')
                        code[m] = '3';
                    else if (tmp[i] == '\u062c' || tmp[i] == '\u0686')
                        code[m] = '4';
                    else if (tmp[i] == '\u0628' || tmp[i] == '\u067e' || tmp[i] == '\u0641' || tmp[i] == '\u0648')
                        code[m] = '5';
                    else if (tmp[i] == '\u062e' || tmp[i] == '\u06a9' || tmp[i] == '\u0642')
                        code[m] = '6';
                    else if (tmp[i] == '\u062f' || tmp[i] == '\u0688' || tmp[i] == '\u0631' || tmp[i] == '\u0691')
                        code[m] = '7';
                    else if (tmp[i] == '\u0646' || tmp[i] == '\u06ba' || tmp[i] == '\u0645')
                        code[m] = '8';
                    else if (tmp[i] == '\u06af' || tmp[i] == '\u063a')
                        code[m] = '9';
                    else if (tmp[i] == '\u0644')
                        code[m] = 'a';
                    else if (tmp[i] == '\u0698' || tmp[i] == '\u06cc')
                        code[m] = 'b';
                    else if (tmp[i] == '\u06c1' || tmp[i] == '\u062d' || tmp[i] == '\u06be')
                        code[m] = 'c';
                    else if (tmp[i] == '\u0627' || tmp[i] == '\u0622' || tmp[i] == '\u0639') // for alef, alef-madda, and aaen
                        code[m] = 'd';
                    else if (tmp[i] == '\u0648') // for vao
                        code[m] = 'e';

                }
                if (i > 0 && m < 5) // it is very important to mention (m<5).
                {
                    if (tmp[i] == '\u062b' || tmp[i] == '\u0633' || tmp[i] == '\u0635' || tmp[i] == '\u0634')
                    { if (code[m - 1] != '1') code[m] = '1'; }
                    else if (tmp[i] == '\u062a' || tmp[i] == '\u0637' || tmp[i] == '\u0679' || tmp[i] == '\u0629')
                    { if (code[m - 1] != '2')  code[m] = '2'; }
                    else if (tmp[i] == '\u0632' || tmp[i] == '\u0636' || tmp[i] == '\u0638' || tmp[i] == '\u0630')
                    { if (code[m - 1] != '3')   code[m] = '3'; }
                    else if (tmp[i] == '\u062c' || tmp[i] == '\u0686')
                    { if (code[m - 1] != '4')   code[m] = '4'; }
                    else if (tmp[i] == '\u0628' || tmp[i] == '\u067e' || tmp[i] == '\u0641' || tmp[i] == '\u0648')
                    { if (code[m - 1] != '5')    code[m] = '5'; }
                    else if (tmp[i] == '\u062e' || tmp[i] == '\u06a9' || tmp[i] == '\u0642')
                    { if (code[m - 1] != '6')   code[m] = '6'; }
                    else if (tmp[i] == '\u062f' || tmp[i] == '\u0688' || tmp[i] == '\u0631' || tmp[i] == '\u0691')
                    { if (code[m - 1] != '7')    code[m] = '7'; }
                    else if (tmp[i] == '\u0646' || tmp[i] == '\u06ba' || tmp[i] == '\u0645')
                    { if (code[m - 1] != '8')   code[m] = '8'; }
                    else if (tmp[i] == '\u06af' || tmp[i] == '\u063a')
                    { if (code[m - 1] != '9')    code[m] = '9'; }
                    else if (tmp[i] == '\u0644')
                    { if (code[m - 1] != 'a')   code[m] = 'a'; }
                    else if (tmp[i] == '\u0698' || tmp[i] == '\u06cc')
                    { if (code[m - 1] != 'b')   code[m] = 'b'; }
                    else if (tmp[i] == '\u06c1' || tmp[i] == '\u062d' || tmp[i] == '\u06be')
                    { if (code[m - 1] != 'c')    code[m] = 'c'; }
                    else if (tmp[i] == '\u0627' || tmp[i] == '\u0622' || tmp[i] == '\u0639')
                    { if (code[m - 1] != 'd')    code[m] = 'd'; }
                    else if (tmp[i] == '\u0648')
                    { if (code[m - 1] != 'e')    code[m] = 'e'; }
                } if (m < 5 && code[m] != '0') m++;

            } // end parent for-loop
            return code;
        } //end function soundex()

        // ********************************End (function Soundex)*******************************//
        // ********************************End (function Soundex)*******************************//


        // ******************************Start (Function shapex) **************************//
        // ******************************Start (Function shapex) **************************//

        public char[] shapex(string forShapex)
        {
            char[] for_shapex = forShapex.ToCharArray();
            List<char> tmp = new List<char>(for_shapex);
            char[] code = new char[5] { '0', '0', '0', '0', '0' };
            int m = 0;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (m < 5)
                {
                    if (tmp[i] == '\u0627' || tmp[i] == '\u0622' || tmp[i] == '\u0644')
                        code[m] = '1';
                    else if (tmp[i] == '\u0628' || tmp[i] == '\u067e' || tmp[i] == '\u06c1' || tmp[i] == '\u06cc')
                        code[m] = '2';
                    else if (tmp[i] == '\u062a' || tmp[i] == '\u0679' || tmp[i] == '\u062b' || tmp[i] == '\u0646')
                        code[m] = '3';
                    else if (tmp[i] == '\u062d' || tmp[i] == '\u062e' || tmp[i] == '\u062c' || tmp[i] == '\u0686')
                        code[m] = '4';
                    else if (tmp[i] == '\u062f' || tmp[i] == '\u0688' || tmp[i] == '\u0630' || tmp[i] == '\u0631'
                        || tmp[i] == '\u0691' || tmp[i] == '\u0632' || tmp[i] == '\u0698' || tmp[i] == '\u0648')
                        code[m] = '5';
                    else if (tmp[i] == '\u0635' || tmp[i] == '\u0636')
                        code[m] = '6';
                    else if (tmp[i] == '\u0637' || tmp[i] == '\u0638')
                        code[m] = '7';
                    else if (tmp[i] == '\u0641' || tmp[i] == '\u0642')
                        code[m] = '8';
                    else if (tmp[i] == '\u06a9' || tmp[i] == '\u06af')
                        code[m] = '9';
                    else if (tmp[i] == '\u0633' || tmp[i] == '\u0634')
                        code[m] = 'a';
                    else if (tmp[i] == '\u0639' || tmp[i] == '\u063a')
                        code[m] = 'b';
                    else if (tmp[i] == '\u0645')
                        code[m] = 'c';
                }
                if (m < 5 && code[m] != '0') m++;
            } //end for-loop
            return code;
        } // end function shapex()

        // ******************************End (Function shapex) **************************//
        // ******************************End (Function shapex) **************************//
        // ******************************End (Function shapex) **************************//
    }
}
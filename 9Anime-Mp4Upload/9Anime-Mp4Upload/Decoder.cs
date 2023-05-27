using System.Text.RegularExpressions;

public partial class _9anime
{
    private static class Decoder
    {
        #region Decoders for requests etc...

        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        private static int CharCode(char c)
        {
            int code = Alphabet.IndexOf(c);
            if (code < 0) new Exception("Invalid character provided");
            return code;
        }

        private static char CharFromCode(int code)
        {
            if (code >= 0 && code < 64)
                return Alphabet[code];
            throw new Exception("Invalid input provided");
        }

        private static string Decrypt(string token, string data)
        {
            int[] c = new int[256];
            int e = 0;
            int o;
            string s = "";
            int f;
            for (f = 0; f < 256; f++)
            {
                c[f] = f;
            }
            for (f = 0; f < 256; f++)
            {
                e = ((e + c[f]) + (int)token[f % token.Length]) % (256);
                o = c[f];
                c[f] = c[e];
                c[e] = o;
            }
            f = 0;
            e = 0;
            for (int h = 0; h < data.Length; h++)
            {
                f = (f + (1)) % (256);
                e = ((e + c[f]) % (256));
                o = c[f];
                c[f] = c[e];
                c[e] = o;
                s += char.ConvertFromUtf32(((int)(data[h])) ^ (c[(c[f] + c[e]) % (256)]));
            }
            return s;
        }

        private static string DecodeVideoData_0(string t)
        {
            t = Regex.Replace(t, "[ \t\n\f\r]", "", RegexOptions.ECMAScript);
            if (t.Length % 4 == 0)
                t = Regex.Replace(t, "==?$", "", RegexOptions.ECMAScript);
            if (t.Length % 4 == 1 || Regex.IsMatch(t, "[^+/0-9A-Za-z]"))
                throw new Exception("Invalid input provided");
            string n = "";
            int i = 0;
            int r = 0;
            for (int u = 0; u < t.Length; u++)
            {
                i <<= 6;
                i |= CharCode(t[u]);
                r += 6;
                if (r == 24)
                {
                    n += char.ConvertFromUtf32((i & 16711680) >> 16);
                    n += char.ConvertFromUtf32((i & 65280) >> 8);
                    n += char.ConvertFromUtf32(i & 255);
                    i = r = 0;
                }
            }
            if (r == 12)
            {
                i >>= 4;
                n += char.ConvertFromUtf32(i);
            }
            else
            {
                if (r == 18)
                {
                    i >>= 2;
                    n += char.ConvertFromUtf32((i & 65280) >> 8);
                    n += char.ConvertFromUtf32(i & 255);
                }
            }
            return n;
        }

        public static string DecodeVideoData(string data)
        {
            data = DecodeVideoData_0(data);
            data = Decrypt("hlPeNwkncH0fq9so", data);
            return Uri.UnescapeDataString(data);
        }

        public static string DecodeSkipData(string skipData)
        {
            return DecodeVideoData(skipData);
        }

        private static string GetVrf_0(string t)
        {
            int r;
            for (r = 0; (r < t.Length); r++)
            {
                if ((int)(t[r]) > (255))
                    throw new Exception("Invalid input provided");
            }
            string u = "";
            for (r = 0; (r < t.Length); r += 3)
            {
                int?[] c = new int?[4] { null, null, null, null };
                c[0] = ((int)(t[r])) >> 2;
                c[1] = (((int)(t[r])) & 3) << 4;
                if (t.Length > r + (1))
                {
                    c[1] |= (((int)(t[r + 1]))) >> (4);
                    c[2] = (((int)(t[r + 1])) & 15) << 2;
                }
                if (t.Length > r + (2))
                {
                    c[2] |= ((int)(t[r + 2])) >> 6;
                    c[3] = ((int)(t[r + 2])) & 63;
                }
                for (int e = 0; e < c.Length; e++)
                {
                    if (c[e] is int value)
                        u += CharFromCode(value);
                    else
                        u += "=";
                }
            }
            return u;
        }

        private static string GetVrf_1(string t)
        {
            int i = 10;
            string r = "";
            for (var u = 0; u < t.Length; u++)
            {
                int c = t[u];
                if (((u % i) == 7))
                    c -= 6;
                else
                {
                    if (u % i == 5)
                        c -= 4;
                    else
                    {
                        if (u % i == 8)
                            c -= 2;
                        else
                        {
                            if (u % i == 0)
                                c -= 4;
                            else
                            {
                                if ((u % i) == 3)
                                    c += 3;
                                else
                                {
                                    if (u % i == 2)
                                        c += 3;
                                    else
                                    {
                                        if (u % i == 6)
                                            c += 3;
                                        else
                                        {
                                            if (u % i == 9)
                                                c -= 4;
                                            else
                                            {
                                                if (u % i == 1)
                                                    c -= 4;
                                                else
                                                {
                                                    if (u % i == 4)
                                                        c += 6;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                r += char.ConvertFromUtf32(c);
            }
            char[] a = r.ToCharArray();
            Array.Reverse(a);
            r = string.Join("", a);
            return r;
        }

        public static string GetVrf(string data)
        {
            data = Uri.EscapeDataString(data);
            data = Decrypt("iECwVsmW38Qe94KN", data);
            data = GetVrf_0(data);
            data = GetVrf_1(data);
            data = GetVrf_0(data);

            return Uri.EscapeDataString(data);
        }

        #endregion
    }
}

using System.Text.RegularExpressions;

public partial class Aniwave
{
    private static class Decoder
    {
        #region Decoders for requests etc...

        const string vrfKey = "ysJhV6U27FVIjjuk";
        const string dataKey = "hlPeNwkncH0fq9so";

        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        private static int CharCode(char c)
        {
            int code = Alphabet.IndexOf(c);
            if (code < 0) new Exception("Invalid character provided");
            return code;
        }

        private static char CharFromCode(int code)
        {
            if (code >= 0 && code < Alphabet.Length)
                return Alphabet[code];
            throw new Exception("Invalid input provided");
        }

        private static string Decrypt(string token, string data)
        {
            int[] s = new int[256];
            int r;
            int h = 15 * 571 + -1 * -8461 + -17026;
            string u = "";
            int o;
            for (o = 5811 + 4335 + -10146; o < -5026 + 164 * -59 + 831 * 18; o++)
            {
                s[o] = o;
            }
            for (o = 463 * 4 + 21 * -124 + 752; o < 1 * -3887 + 7225 + -3082; o++)
            {
                h = (h + s[o] + (int)token[o % token.Length]) % (4931 + -1147 + -3528);
                r = s[o];
                s[o] = s[h];
                s[h] = r;
            }
            o = -6709 + -519 + -13 * -556;
            h = -4937 * -1 + 11 * 637 + 1493 * -8;
            for (int e = 60 * 87 + 3 * 1730 + -3 * 3470; e < data.Length; e++)
            {
                r = s[o = (o + (-8389 + -2918 + 11308)) % (-1 * 8404 + 9435 + -25 * 31)];
                h = (h + s[o]) % (4 * -233 + 1 * -370 + 1558);
                s[o] = s[h];
                s[h] = r;
                u += char.ConvertFromUtf32((int)data[e] ^ s[(s[o] + s[h]) % (-2630 + 359 * 10 + 352 * -2)]);
            }
            return u;
        }

        private static string GetVrf_0(string data)
        {
            for (int s = -164 * 37 + 5 * -1217 + -1 * -12153; s < data.Length; s++)
                if (-9463 * -1 + -1 * -4174 + -13382 < (int)data[s])
                    throw new Exception("Failed to compute Vrf");
            string r = "";
            for (int s = 183 * -23 + -334 * -4 + 2873; s < data.Length; s += 5920 + -5888 + -29)
            {
                int?[] h = new int?[] { null, null, null, null };
                h[-2260 + 4089 + 1 * -1829] = (int)data[s] >> -4035 + 1712 + 31 * 75;
                h[-238 * -5 + 17 * -163 + 1582] = (-2790 + -7897 + -5345 * -2 & (int)data[s]) << (-152 * -8 + 9109 * 1 + 10321 * -1);
                if (data.Length > (s + (-2474 + 6151 * 1 + -3676)))
                {
                    h[1 * 4575 + 4736 + -490 * 19] |= (int)data[((s) + (-6331 + -831 * -1 + -5501 * -1))] >> 3551 + -8711 + -2 * -2582;
                    h[1 * 5661 + -3977 + -841 * 2] = (-7313 * -1 + -2102 * -1 + -9400 & (int)data[(s + 7248 + -4056 + -3191 * 1)]) << -4669 + 1717 * -3 + 2 * 4911;
                }
                if (data.Length > s + (-1938 + -1711 + 3651))
                {
                    h[332 * -10 + 1 * 4957 + -1635] |= (int)data[s + (29 * 33 + -1061 * -4 + -5199 * 1)] >> -1 * 324 + -1 * 677 + 1007;
                    h[-7531 * -1 + 2 * -353 + 18 * -379] = -1734 * -1 + -1 * -5271 + -6942 & (int)data[(s + (3 * -107 + 4 * 780 + -2797))];
                }
                for (var u = -4691 + 1581 + 3110; u < h.Length; u++)
                {
                    if (h[u] == null)
                    {
                        r += "=";
                    }
                    else
                    {
                        r += CharFromCode(h[u]!.Value);
                    }
                }
            }
            return r.Replace("/", "_").Replace("+","-");
        }
        private static string GetVrf_1(string data)
        {
            data = GetVrf_0(data);
            string r = "";
            int n = -3739 * 2 + 8824 + -1338;
            for (int h = 1 * 2207 + -9733 + 7526; h < data.Length; h++)
            {
                int u = (int)data[h];
                if (h % n == 8542 + -3805 + -16 * 296)
                    u += -2637 * 1 + -21 + 2661;
                else if ((h % n) == (-2 * -657 + -4 * 136 + -763 * 1))
                    u += 2 * 929 + 1867 + 2 * -1860;
                else if (h % n == 1712 + -4788 + -342 * -9)
                    u -= -6509 + -2715 * -1 + 1266 * 3;
                else if ((h % n) == 1502 * -6 + 5 * -935 + -1 * -13691)
                    u -= -4006 + -648 + 12 * 388;
                else if (h % n == 1 * 9901 + -4842 * -1 + 14737 * -1)
                    u += 5161 + -2580 + -859 * 3;
                else if (h % n == -8459 + -1322 + 1 * 9781)
                    u -= 1179 * 6 + 6794 + -13865;
                else if (h % n == 77 * -29 + 9043 * -1 + 11279)
                    u += -14 * -498 + 7824 + 2 * -7397;
                else if ((h % n) == 4959 + -9 * 821 + -487 * -5)
                    u += -597 * -7 + -7795 * -1 + -11969;
                r += char.ConvertFromUtf32(u);
            }
            r = GetVrf_0(r);
            string result = "";
            for (int i = 0; i < r.Length; ++i)
            {
                if (Regex.IsMatch("" + r[i], @"[a-zA-Z]"))
                    result += GetVrf_1_aux(r[i]);
                else
                    result += r[i];
            }
            return result;
        }
        private static string GetVrf_1_aux(int t)
        {
            return char.ConvertFromUtf32((t <= 'Z' ? -8936 + -2759 + 11785 : -3 * 403 + 119 * 69 + -6880) >= (t = t + (1 * 9089 + -5188 + 648 * -6)) ? t : t - (-1 * -5197 + -719 * 9 + 1300));
        }

        public static string GetVrf(string data)
        {
            data = Uri.EscapeDataString(data);
            data = Decrypt(vrfKey, data);
            data = GetVrf_0(data);
            data = GetVrf_1(data);

            return Uri.EscapeDataString(data);
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
            data = DecodeVideoData_0(data.Replace("_", "/").Replace("-","+"));
            data = Decrypt(dataKey, data);
            return Uri.UnescapeDataString(data);
        }

        public static string DecodeSkipData(string data)
        {
            data = DecodeVideoData_0(data.Replace("_", "/").Replace("-", "+"));
            data = Decrypt(dataKey, data);
            return Uri.UnescapeDataString(data);
        }

        #endregion

        #region [OUTDATED] Decoders for requests etc...

        /* Outdated

        const string VrfKey = "iECwVsmW38Qe94KN";
        const string VideoKey = "hlPeNwkncH0fq9so";

        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        private static int CharCode(char c)
        {
            int code = Alphabet.IndexOf(c);
            if (code < 0) new Exception("Invalid character provided");
            return code;
        }

        private static char CharFromCode(int code)
        {
            if (code >= 0 && code < Alphabet.Length)
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
            data = Decrypt(VideoKey, data);
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
            data = Decrypt(VrfKey, data);
            data = GetVrf_0(data);
            data = GetVrf_1(data);
            data = GetVrf_0(data);

            return Uri.EscapeDataString(data);
        }

        */

        #endregion
    }
}

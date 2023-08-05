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
            for (int s = 0; s < data.Length; s++)
                if (255 < data[s])
                    throw new Exception("Failed to compute Vrf");
            string r = "";
            for (int s = 0; s < data.Length; s += 3)
            {
                int?[] h = new int?[] { null, null, null, null };
                h[0] = data[s] >> 2;
                h[1] = (3 & data[s]) << 4;
                if (data.Length > s + 1)
                {
                    h[1] |= data[s + 1] >> 4;
                    h[2] = (15 & data[s + 1]) << 2;
                }
                if (data.Length > s + 2)
                {
                    h[2] |= data[s + 2] >> 6;
                    h[3] = 63 & data[s + 2];
                }
                for (var u = 0; u < h.Length; u++)
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
            for (int h = 0; h < data.Length; h++)
            {
                int u = data[h];
                switch (h % 8)
                {
                    case 0:
                        u -= 3;
                        break;
                    case 1:
                        u += 3;
                        break;
                    case 2:
                        u -= 4;
                        break;
                    case 3:
                        u += 2;
                        break;
                    case 4:
                        u -= 2;
                        break;
                    case 5:
                        u += 5;
                        break;
                    case 6:
                        u += 4;
                        break;
                    case 7:
                        u += 5;
                        break;
                    default:
                        throw new Exception("Unreachable");
                }
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
            return char.ConvertFromUtf32((t <= 'Z' ? 'Z' : 'z') >= (t = t + 13) ? t : t - 26);
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

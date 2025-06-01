using System.Text;

// TODO(ranodmuserhi): Should map Rune -> Rune not Rune -> string
// TODO(randomuserhi): Make API better
// TODO(randomuserhi): Create a way to handle website that use multiple encoded fonts
public class FontMapping {
    private Dictionary<Rune, string> mapping = new Dictionary<Rune, string>();

    public static string CommonCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890\"\"?.:;&#\'\'-[]{}()%$£!~@/\\ ,*";

    public string Convert(string original) {
        int i = 0;

        StringBuilder sb = new StringBuilder();

        foreach (Rune rune in original.EnumerateRunes()) {
            if (mapping.ContainsKey(rune)) {
                sb.Append(mapping[rune]);
            } else {
                sb.Append(rune.ToString());

                if (!CommonCharacters.Contains(rune.ToString())) {
                    Console.WriteLine($"Unknown rune: U+{rune.Value:X} '{rune.ToString()}' at rune {i} within '{original}'.");
                }
            }
            ++i;
        }

        return sb.ToString();
    }

    public void CreateFromExisting(string encoded, string text) {
        Rune[] runes = encoded.EnumerateRunes().ToArray();
        Rune[] textRunes = text.EnumerateRunes().ToArray();

        if (runes.Length != textRunes.Length) throw new Exception("Text lengths dont match.");

        for (int i = 0; i < runes.Length; ++i) {
            Add(runes[i].ToString(), textRunes[i].ToString());
        }
    }

    public void Add(string rune, string value) {
        Rune r = new Rune();
        int count = 0;

        foreach (Rune _r in rune.EnumerateRunes()) {
            if (count != 0) throw new Exception("Rune string contained more than 1 rune.");
            r = _r;
            ++count;
        }

        if (count != 1) throw new Exception("Rune string must contain a rune.");

        if (mapping.ContainsKey(r)) {
            if (mapping[r] != value) {
                throw new Exception($"Mismatch of '{mapping[r].ToString()}' and '{value}' for rune '{r.ToString()}'");
            }
        } else {
            mapping.Add(r, value);
        }
    }
}

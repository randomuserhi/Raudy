Use the encoded font to read the text

## HTML conversion

The converter preserves block elements, inline formatting, source whitespace, and inline CSS `white-space` declarations. Adjacent spans remain inline; paragraphs and explicit breaks retain their HTML meaning. For `pre-wrap`, blank lines and spacing in text nodes are preserved by the output's whitespace rule. Other styling comes from the EPUB stylesheet; external page stylesheets are not copied.

## Reuse your browser session

1. Open the chapter on `https://novellunar.com` in your browser, log in if necessary, and complete any Cloudflare challenge manually.
2. In Chrome or Edge, open DevTools (`F12`), select **Network**, and reload the chapter. Select the successful chapter document request.
3. Under **Headers > Request Headers**, copy the **Cookie** value (such as `cf_clearance=...; session=...`) and the **User-Agent** value from that same request. Copy the request's Cookie header, not the response's Set-Cookie header. Keep cookie values encoded as shown.
4. From PowerShell in this directory, enter the values at the prompts and run:

   ```powershell
   $env:NOVELLUNAR_COOKIE = Read-Host 'Paste the Cookie request header value'
   $env:NOVELLUNAR_USER_AGENT = Read-Host 'Paste the User-Agent request header value'
   try {
       dotnet run --project .\novellunar\novellunar.csproj
   } finally {
       Remove-Item Env:NOVELLUNAR_COOKIE, Env:NOVELLUNAR_USER_AGENT -ErrorAction SilentlyContinue
   }
   ```

The prompts keep the cookie out of the command text saved in shell history, but the pasted value is visible in the terminal. Treat it like a password: keep it local, and don't paste it into chat, commit it, or share terminal logs. The values apply to processes launched from this PowerShell window; an already open Visual Studio instance will not inherit them.

Alternatively, find `cf_clearance` under **Application > Storage > Cookies > https://novellunar.com** and enter `cf_clearance=YOUR_VALUE`. The site may also need its own login cookies. See [Chrome's cookie inspector](https://developer.chrome.com/docs/devtools/application/cookies/).

The scraper imports cookies for HTTPS requests to `novellunar.com` only, including same-host images. It does not forward imported cookies to other hosts. Update the chapter URLs and output directory in `novellunar/Program.cs` before running; the existing output is XHTML and images for your custom EPUB workflow.

Cookie reuse is not a guaranteed Cloudflare bypass. [`cf_clearance` is tied to the visitor and device](https://developers.cloudflare.com/cloudflare-challenges/concepts/clearance/), and it expires. A matching User-Agent does not make `HttpClient` identical to your browser. If reuse fails, use a browser-based capture or save the rendered chapter HTML for conversion. The scraper stops on challenges, HTTP errors, or missing article content instead of writing an empty chapter or continuing through the download list. Challenge detection uses Cloudflare's [`cf-mitigated: challenge` response header](https://developers.cloudflare.com/cloudflare-challenges/challenge-types/challenge-pages/detect-response/).

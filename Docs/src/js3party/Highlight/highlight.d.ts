interface hljs
{
    highlightElement(el: HTMLElement): void;
}

declare var hljs: hljs;

interface Window
{
    hljs: hljs;
}
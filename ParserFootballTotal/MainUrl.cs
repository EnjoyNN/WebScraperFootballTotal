namespace ParserFootballTotal
{
    class MainUrl
    {
        public MainUrl(string url, int countSerie)
        {
            this.Url = url;
            this.countSerie = countSerie;
        }

        public string Url { get; }
        public int countSerie { get; }
    }
}

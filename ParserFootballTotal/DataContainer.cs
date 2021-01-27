namespace ParserFootballTotal
{ 
    //этот класс служит для получения дата контейнеров сайта для дальнейшего парсинга этого в формдату
class DataContainer
    {
        //это можно было бы вывести под абстрактный класс вместо трех конструкторов,
        //только для того чтобы немножко изменить количество переменных в каждом экземпляре, но в данной программе смысла от этого нет
        //нужно будет переписывать логику для получения матчей с тоталов и забьет\пропускает и т.д.

        //конструтор для создания дата контейнера с раздела не забивает/не пропускает
        public DataContainer(string nameSerie, string url, int countSerie, int divAllMatchOrHalf, int divAllHomeAway)
        {
            this.nameSerie = nameSerie;
            this.url = url;
            this.countSerie = countSerie;
            this.divAllMatchOrHalf = divAllMatchOrHalf;
            this.divAllHomeAway = divAllHomeAway;
        }

        //конструктор для создания дата контейнера с раздела тоталов
        public DataContainer(string nameSerie, string url, int countSerie, int divAllMatchOrHalf, int divAllHomeAway, int divTotals)
        {
            this.nameSerie = nameSerie;
            this.url = url;
            this.countSerie = countSerie;
            this.divAllMatchOrHalf = divAllMatchOrHalf;
            this.divAllHomeAway = divAllHomeAway;
            this.divTotals = divTotals;
        }

        //конструктор для создания дата контейнера с разделами обе не забьют
        public DataContainer(string nameSerie, int countSerie, int divAllMatchOrHalf, int divAllHomeAway)
        {
            this.nameSerie = nameSerie;
            this.countSerie = countSerie;
            this.divAllMatchOrHalf = divAllMatchOrHalf;
            this.divAllHomeAway = divAllHomeAway;
        }

        public string url { get; }
        public int countSerie { get; }
        public int divAllMatchOrHalf { get; }
        public int divTotals { get; }
        public int divAllHomeAway { get; }
        public string nameSerie { get;  }
    }
}

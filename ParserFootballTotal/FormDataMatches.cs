using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserFootballTotal
{
    //этот класс служит для хранения уже сформированной даты матчей для парсинга уже самих счетов и дальнейшей выгрузки в эксель
    class FormDataMatches
    {
        public FormDataMatches(string nameLeague, string nextMatch, string nameCommand, string nameSerie, int countSerie, string urlCommand)
        {
            this.nameLeague = nameLeague;
            this.nextMatch = nextMatch;
            this.nameCommand = nameCommand;
            this.nameSerie = nameSerie;
            this.countSerie = countSerie;
            this.urlCommand = urlCommand;
        }

        public string nameCommand { get; }
        public string nameLeague { get; }
        public int countSerie { get; }
        public string nameSerie { get; }
        public string urlCommand { get; }

        //это контейнер следующего матча формата 30.02.2019 Леванте - Вальядолид
        //серии собранные через datacontainer имеют вкладку с такой инфой, а серии через обе не забьют нужно смотреть по тем матчам, котоыре играют в текущий день
        public string nextMatch { get; }

    }
}

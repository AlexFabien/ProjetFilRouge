using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Utils
{
    //[Serializable]
    public class ReponseBody
    {
        public bool Resultat { get; set; }
        public string Message { get; set; }
        public ReponseBody(bool resultat, string message)
        {
            Resultat = resultat;
            Message = message;
        }
    }

}

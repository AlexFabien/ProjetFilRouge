using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Utils
{
    [Serializable]
    internal class RessourceException : Exception
    {
        public int Statut { get; set; }

        public RessourceException(int statut, string message) : base(message)
        {
            this.Statut = statut;
        }

    }

}

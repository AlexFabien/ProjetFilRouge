namespace QuizApi.Dtos
{
    public class ReponseCandidatDto
    {
        public ReponseCandidatDto(){}

        public ReponseCandidatDto(string libelle, int? idReponseCandidat = null)
        {
            Libelle = libelle;
            IdReponseCandidat = idReponseCandidat;
        }

        public int? IdReponseCandidat { get; set; }
        public string Libelle { get; set; }
    }
}

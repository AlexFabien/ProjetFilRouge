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

        /// <summary>
        /// Fonction qui transforme un ReponseCandidat(DTO) en ReponseCandidat(Models) automatiquement
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator quiz.ReponseCandidat(ReponseCandidatDto dto)
        {
            return new quiz.ReponseCandidat(dto.Libelle, dto.IdReponseCandidat);
        }
    }
}

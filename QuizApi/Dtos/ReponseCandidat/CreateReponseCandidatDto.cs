namespace QuizApi.Dtos.ReponseCandidat
{
    public class CreateReponseCandidatDto
    {
        public CreateReponseCandidatDto() { }

        public CreateReponseCandidatDto(string libelle)
        {
            Libelle = libelle;
        }

        public string Libelle { get; set; }
    }
}

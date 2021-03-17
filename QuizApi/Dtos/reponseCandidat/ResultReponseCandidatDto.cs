namespace QuizApi.Dtos
{
    public class ResultReponseCandidatDto
    {
        public ResultReponseCandidatDto()
        {
        }

        public ResultReponseCandidatDto(string libelle, int? total, string couleur)
        {
            Libelle = libelle;
            Total = total;
            Couleur = couleur;
        }

        public string Libelle { get; set; }
        public int? Total { get; set; }
        public string Couleur { get; set; }
    }
}

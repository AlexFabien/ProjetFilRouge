namespace QuizApi.Dtos.Role
{
    public class QuestionDto
    {
        public QuestionDto(){}

        public QuestionDto(int? idQuestion, string libelle, string explicationReponse, int? idNiveau, int? idTypeQuestion)
        {
            IdQuestion = idQuestion;
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
            IdNiveau = idNiveau;
            IdTypeQuestion = idTypeQuestion;
        }

        public int? IdQuestion { get; set; }
        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
        public int? IdNiveau { get; set; }
        public int? IdTypeQuestion { get; set; }
    }
}

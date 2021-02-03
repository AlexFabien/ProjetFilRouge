namespace QuizApi.Dtos.Role
{
    public class CreateQuestionDto
    {
        public CreateQuestionDto(){}

        public CreateQuestionDto(string libelle, string explicationReponse)
        {
            Libelle = libelle;
            ExplicationReponse = explicationReponse;
        }

        public string Libelle { get; set; }
        public string ExplicationReponse { get; set; }
    }
}

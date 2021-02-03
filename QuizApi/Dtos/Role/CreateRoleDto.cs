namespace QuizApi.Dtos
{
    public class CreateRoleDto
    {
        public CreateRoleDto(){}
        public CreateRoleDto(string nom)
        {
            Nom = nom;
        }

        public string Nom { get; set; }
    }
}

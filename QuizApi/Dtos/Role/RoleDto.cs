namespace QuizApi.Dtos
{
    public class RoleDto
    {
        public RoleDto(){}

        public RoleDto(string nom, int? idRole = null)
        {
            Nom = nom;
            IdRole = idRole;
        }

        public int? IdRole { get; set; }
        public string Nom { get; set; }
    }
}

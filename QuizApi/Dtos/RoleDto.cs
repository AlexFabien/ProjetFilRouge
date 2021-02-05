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

        //public virtual ICollection<Acteur> Acteur { get; set; }

        /// <summary>
        /// Fonction qui transforme un Role(DTO) en Role(Models) automatiquement
        /// </summary>
        /// <param name="RoleDto"></param>
        public static implicit operator quiz.Role(RoleDto dto)
        {
            return new quiz.Role(dto.Nom, dto.IdRole);
        }
    }
}

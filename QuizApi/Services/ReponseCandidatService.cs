using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Services
{
    public class ReponseCandidatService : IService<ReponseCandidatDto>
    {
        private IRepository<ReponseCandidat> repository;

        public ReponseCandidatService(IRepository<ReponseCandidat> repository)
        {
            this.repository = repository;
        }
        public ReponseCandidatDto Ajouter(ReponseCandidatDto obj)
        {
            return this.repository.Insert(obj);
        }

        public void Modifier(ReponseCandidatDto obj)
        {
            this.repository.Update(obj);
        }

        public void Supprimer(int id)
        {
            this.repository.Delete(id);
        }

        public ReponseCandidatDto TrouverParId(int id)
        {
            return this.repository.FindById(id);
        }

        public IEnumerable<ReponseCandidatDto> TrouverTout()
        {
            return ConvertDtoEntity.ConvertListReponseCandidatToListReponseCandidatDto(this.repository?.FindAll()?.ToList());
        }
    }
}

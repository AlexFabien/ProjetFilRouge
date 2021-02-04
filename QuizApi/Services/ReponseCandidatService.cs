using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System.Collections.Generic;

namespace QuizApi.Services
{
    public class ReponseCandidatService
    {
        private ReponseCandidatRepository reponseCandidatRepository;

        public ReponseCandidatService()
        {
            this.reponseCandidatRepository = new ReponseCandidatRepository(new QueryBuilder());
        }

        internal List<ReponseCandidatDto> FindAll()
        {
            List<ReponseCandidat> rcList = reponseCandidatRepository.FindAll();
            List<ReponseCandidatDto> allDtos = new List<ReponseCandidatDto>();
            rcList.ForEach(entity => { allDtos.Add(entity); });
            return allDtos;
        }

        internal ReponseCandidatDto Find(int id)
        {
            ReponseCandidat rc = reponseCandidatRepository.Find(id);
            return rc;
        }

        internal ReponseCandidatDto PostRole(CreateReponseCandidatDto createDto)
        {
            ReponseCandidat rc = ConvertDtoToEntity(createDto);
            ReponseCandidat rcConverted = reponseCandidatRepository.Create(rc);
            return rcConverted;
        }

        internal ReponseCandidatDto UpdateRole(int id, CreateReponseCandidatDto newDto)
        {
            ReponseCandidat rc = ConvertDtoToEntity(newDto);
            ReponseCandidat newRc = reponseCandidatRepository.Update(id, rc);
            return newRc;
        }
        internal int Delete(int id)
        {
            return reponseCandidatRepository.Delete(id);
        }
        
        private ReponseCandidat ConvertDtoToEntity(CreateReponseCandidatDto dto)
        {
            ReponseCandidat rcConverted = new ReponseCandidat();
            rcConverted.Libelle = dto.Libelle;
            return rcConverted;
        }
    }
}

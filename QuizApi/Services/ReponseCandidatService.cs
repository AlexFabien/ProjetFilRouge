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
            rcList.ForEach(entity => { allDtos.Add(ConvertEntityToDto(entity)); });
            return allDtos;
        }

        internal ReponseCandidatDto Find(int id)
        {
            ReponseCandidat rc = reponseCandidatRepository.Find(id);
            ReponseCandidatDto allDto = ConvertEntityToDto(rc);
            return allDto;
        }

        internal ReponseCandidatDto PostRole(CreateReponseCandidatDto createDto)
        {
            ReponseCandidat rc = ConvertDtoToEntity(createDto);
            ReponseCandidat rcConverted = reponseCandidatRepository.Create(rc);
            return ConvertEntityToDto(rcConverted);
        }

        internal ReponseCandidatDto UpdateRole(int id, CreateReponseCandidatDto newDto)
        {
            ReponseCandidat rc = ConvertDtoToEntity(newDto);
            ReponseCandidat newRc = reponseCandidatRepository.Update(id, rc);
            return ConvertEntityToDto(newRc);
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

        private ReponseCandidatDto ConvertEntityToDto(ReponseCandidat rc)
        {
            return new ReponseCandidatDto(rc.Libelle, rc.IdReponseCandidat);
        }
    }
}

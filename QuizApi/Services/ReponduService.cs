using QuizApi.Dtos.Repondu;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class ReponduService
    {
        private ReponduRepository reponduRepository;

        public ReponduService()
        {
            this.reponduRepository = new ReponduRepository(new QueryBuilder());
        }

        internal List<AllReponduDto> FindAll()
        {
            List<Repondu> reponduEntities = reponduRepository.FindAll();
            List<AllReponduDto> allReponduDtos = new List<AllReponduDto>();
            reponduEntities.ForEach(reponduEntity => { allReponduDtos.Add(ConvertEntityToDto(reponduEntity)); });
            return allReponduDtos;
        }

        internal AllReponduDto Find(int id)
        {
            Repondu reponduEntity = this.reponduRepository.Find(id);
            AllReponduDto allReponduDtos = ConvertEntityToDto(reponduEntity);
            return allReponduDtos;
        }

        private AllReponduDto ConvertEntityToDto(Repondu reponduEntity)
        {
            return new AllReponduDto(reponduEntity.Libelle, reponduEntity.IdEtatReponse);
        }

        internal AfterCreateReponduDto PostReponduEntity(CreateReponduDto reponduEntity)
        {
            Repondu newtRepondu = transformDtoToEntity(reponduEntity);
            Repondu newtReponduCreated = this.reponduRepository.Create(newtRepondu);
            return transformEntityToAfterCreateDto(newtReponduCreated, true);
        }

        internal long Delete(int id)
        {
            return this.reponduRepository.Delete(id);
        }

        internal AfterCreateReponduDto PutReponduEntity(int id, CreateReponduDto newRepondu)
        {
            Repondu newtRepondu = transformDtoToEntity(newRepondu);
            Repondu newtReponduUpdated = this.reponduRepository.Update(id, newtRepondu);
            return transformEntityToAfterCreateDto(newtReponduUpdated, true);
        }

        private AfterCreateReponduDto transformEntityToAfterCreateDto(Repondu reponduEntity, bool isCreated)
        {
            return new AfterCreateReponduDto(reponduEntity.Libelle, isCreated, reponduEntity.IdEtatReponse);
        }

        private Repondu transformDtoToEntity(CreateReponduDto reponduEntity)
        {
            //return new Repondu(reponduEntity.Libelle);
            return null;
        }
    }
}


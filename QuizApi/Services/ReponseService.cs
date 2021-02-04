using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class ReponseService
    {
        private ReponseRepository reponseRepository;

        public ReponseService(ReponseRepository reponseRepository)
        {
            this.reponseRepository = reponseRepository;
        }

        internal List<AllReponseDto> FindAll()
        {
            List<Reponse> reponseEntities = reponseRepository.FindAll();
            List<AllReponseDto> allReponseDtos = new List<AllReponseDto>();
            reponseEntities.ForEach(reponduEntity => { allReponseDtos.Add(ConvertEntityToDto(reponduEntity)); });
            return allReponseDtos;
        }

        internal AllReponseDto Find(int id)
        {
            Reponse reponseEntity = this.reponseRepository.Find(id);
            AllReponseDto allReponseDtos = ConvertEntityToDto(reponseEntity);
            return allReponseDtos;
        }

        private AllReponseDto ConvertEntityToDto(Reponse reponseEntity)
        {
            return new AllReponseDto(reponseEntity.Libelle, reponseEntity.IdReponse, reponseEntity.ReponseCorrecte, reponseEntity.IdQuestion);
        }

        internal AfterCreateReponseDto PostReponseEntity(CreateReponseDto reponseEntity)
        {
            Reponse newtReponse = transformDtoToEntity(reponseEntity);
            Reponse newtReponseCreated = this.reponseRepository.Create(newtReponse);
            return transformEntityToAfterCreateDto(newtReponseCreated, true);
        }

        internal long Delete(int id)
        {
            return this.reponseRepository.Delete(id);
        }

        internal AfterCreateReponseDto PutReponseEntity(int id, CreateReponseDto newReponse)
        {
            Reponse newtReponse = transformDtoToEntity(newReponse);
            Reponse newtReponseUpdated = this.reponseRepository.Update(id, newtReponse);
            return transformEntityToAfterCreateDto(newtReponseUpdated, true);
        }

        private AfterCreateReponseDto transformEntityToAfterCreateDto(Reponse reponseEntity, bool isCreated)
        {
            return new AfterCreateReponseDto(reponseEntity.Libelle, isCreated, reponseEntity.IdReponse, reponseEntity.ReponseCorrecte, reponseEntity.IdQuestion);
        }

        private Reponse transformDtoToEntity(CreateReponseDto reponseEntity)
        {
            return new Reponse(reponseEntity.Libelle,reponseEntity.ReponseCorrecte);
        }
    }
}


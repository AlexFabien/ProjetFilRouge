using QuizApi.Dtos;
using QuizApi.Entities;
using QuizApi.Repositories;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class TechnologieService
    {
        private TechnologieRepository technologieRepository;

        public TechnologieService()
        {
            this.technologieRepository = new TechnologieRepository(new QueryBuilder());
        }

        internal List<AllTechnologieDto> FindAll()
        {
            List<TechnologieEntity> technologieEntities = technologieRepository.FindAll();
            List<AllTechnologieDto> allTechnologieDtos = new List<AllTechnologieDto>();
            technologieEntities.ForEach(technologieEntity => { allTechnologieDtos.Add(ConvertEntityToDto(technologieEntity)); });
            return allTechnologieDtos;
        }

        internal AllTechnologieDto Find(int id)
        {
            TechnologieEntity technologieEntity = this.technologieRepository.Find(id);
            AllTechnologieDto allTechnologieDtos = ConvertEntityToDto(technologieEntity);
            return allTechnologieDtos;
        }

        private AllTechnologieDto ConvertEntityToDto(TechnologieEntity technologieEntity)
        {
            return new AllTechnologieDto(technologieEntity.Libelle, technologieEntity.Id_Technologie);
        }

        internal AfterCreateTechnologieDto PostTechnologieEntity(CreateTechnologieDto technologieEntity)
        {
            TechnologieEntity newtTechnologieEntity = transformDtoToEntity(technologieEntity);
            TechnologieEntity newtTechnologieEntityCreated = this.technologieRepository.Create(newtTechnologieEntity);
            return transformEntityToAfterCreateDto(newtTechnologieEntityCreated, true);
        }

        internal long Delete(int id)
        {
            return this.technologieRepository.Delete(id);
        }

        internal AfterCreateTechnologieDto PutTechnologeEntity(int idTechnologie, CreateTechnologieDto newTechnologieEntity)
        {
            TechnologieEntity newtTechnologieEntity = transformDtoToEntity(newTechnologieEntity);
            TechnologieEntity newtTechnologieEntitylUpdated = this.technologieRepository.Update(idTechnologie, newtTechnologieEntity);
            return transformEntityToAfterCreateDto(newtTechnologieEntitylUpdated, true);
        }

        private AfterCreateTechnologieDto transformEntityToAfterCreateDto(TechnologieEntity technologieEntity, bool isCreated)
        {
            return new AfterCreateTechnologieDto(technologieEntity.Libelle, isCreated,technologieEntity.Id_Technologie);
        }

        private TechnologieEntity transformDtoToEntity(CreateTechnologieDto technologieEntity)
        {
            return new TechnologieEntity(technologieEntity.Libelle);
        }
    }
}

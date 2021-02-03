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
    public class NiveauService
    {
        private NiveauRepository niveauRepository;

        public NiveauService()
        {
            this.niveauRepository = new NiveauRepository(new QueryBuilder());
        }

        internal List<NiveauDto> FindAll()
        {
            List<Niveau> niveau = niveauRepository.FindAll();
            List<NiveauDto> niveauxDtos = new List<NiveauDto>();
            niveau.ForEach(n => { niveauxDtos.Add(ConvertEntityToDto(n)); });
            return niveauxDtos;
        }

        internal NiveauDto Find(int id)
        {
            Niveau niveau = niveauRepository.Find(id);
            NiveauDto niveauDto = ConvertEntityToDto(niveau);
            return niveauDto;
        }

        internal NiveauDto PostNiveau(CreateNiveauDto dto)
        {
            Niveau niveau = ConvertDtoToEntity(dto);
            Niveau niveauConverted = niveauRepository.Create(niveau);
            return ConvertEntityToDto(niveauConverted);
        }

        internal NiveauDto UpdateNiveau(int id, CreateNiveauDto newDto)
        {
            Niveau niveau = ConvertDtoToEntity(newDto);
            Niveau newNiveau = niveauRepository.Update(id, niveau);
            return ConvertEntityToDto(newNiveau);
        }
        internal int Delete(int id)
        {
            return niveauRepository.Delete(id);
        }

        private Niveau ConvertDtoToEntity(CreateNiveauDto dto)
        {
            Niveau roleConverted = new Niveau();
            roleConverted.Libelle = dto.Libelle;
            return roleConverted;
        }

        private NiveauDto ConvertEntityToDto(Niveau niveau)
        {
            return new NiveauDto(niveau.IdNiveau, niveau.Libelle);
        }
    }
}

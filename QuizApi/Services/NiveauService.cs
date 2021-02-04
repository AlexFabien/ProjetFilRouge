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
            niveau.ForEach(n => { niveauxDtos.Add(n); });
            return niveauxDtos;
        }

        internal NiveauDto Find(int id)
        {
            Niveau niveau = niveauRepository.Find(id);
            return niveau;
        }

        internal NiveauDto PostNiveau(CreateNiveauDto dto)
        {
            Niveau niveau = ConvertDtoToEntity(dto);
            Niveau niveauConverted = niveauRepository.Create(niveau);
            return niveauConverted;
        }

        internal NiveauDto UpdateNiveau(int id, CreateNiveauDto newDto)
        {
            Niveau niveau = ConvertDtoToEntity(newDto);
            Niveau newNiveau = niveauRepository.Update(id, niveau);
            return newNiveau;
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
    }
}

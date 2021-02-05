using QuizApi.Dtos;
using QuizApi.quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Utils
{
    static class ConvertDtoEntity
    {
        public static List<ActeurHasQuestion> ConvertListActeurHasQuestionDtoToListActeurHasQuestion(ICollection<ActeurHasQuestionDto> collectionActeurHasQuestionDto)
        {
            List<ActeurHasQuestion> listActeurHasQuestion = null;
            if (collectionActeurHasQuestionDto != null)
            {
                listActeurHasQuestion = new List<ActeurHasQuestion>();
                foreach (ActeurHasQuestionDto acteurHasQuestionDto in collectionActeurHasQuestionDto)
                {
                    listActeurHasQuestion.Add(acteurHasQuestionDto);
                }
            }
            return listActeurHasQuestion;
        }

        internal static ICollection<ActeurHasQuestionDto> ConvertListActeurHasQuestionToListActeurHasQuestionDto(ICollection<ActeurHasQuestion> collectionActeurHasQuestion)
        {
            List<ActeurHasQuestionDto> listActeurHasQuestionDto = null;
            if (collectionActeurHasQuestion != null)
            {
                listActeurHasQuestionDto = new List<ActeurHasQuestionDto>();
                foreach (ActeurHasQuestion acteurHasQuestion in collectionActeurHasQuestion)
                {
                    listActeurHasQuestionDto.Add(acteurHasQuestion);
                }
            }
            return listActeurHasQuestionDto;
        }

        public static List<ActeurHasQuiz> ConvertListActeurHasQuizDtoToListActeurHasQuiz(ICollection<ActeurHasQuizDto> collectionActeurHasQuizDto)
        {
            List<ActeurHasQuiz> listActeurHasQuiz = null;
            if (collectionActeurHasQuizDto != null)
            {
                listActeurHasQuiz = new List<ActeurHasQuiz>();
                foreach (ActeurHasQuizDto acteurHasQuizDto in collectionActeurHasQuizDto)
                {
                    listActeurHasQuiz.Add(acteurHasQuizDto);
                }
            }
            return listActeurHasQuiz;
        }

        internal static ICollection<ActeurHasQuizDto> ConvertListActeurHasQuizToListActeurHasQuizDto(ICollection<ActeurHasQuiz> collectionActeurHasQuiz)
        {
            List<ActeurHasQuizDto> listActeurHasQuizDto = null;
            if (collectionActeurHasQuiz != null)
            {
                listActeurHasQuizDto = new List<ActeurHasQuizDto>();
                foreach (ActeurHasQuiz acteurHasQuiz in collectionActeurHasQuiz)
                {
                    listActeurHasQuizDto.Add(acteurHasQuiz);
                }
            }
            return listActeurHasQuizDto;
        }

        public static List<Question> ConvertListQuestionDtoToListQuestion(ICollection<QuestionDto> collectionQuestionDto)
        {
            List<Question> listQuestion = null;
            if (collectionQuestionDto != null)
            {
                listQuestion = new List<Question>();
                foreach (QuestionDto questionDto in collectionQuestionDto)
                {
                    listQuestion.Add(questionDto);
                }
            }
            return listQuestion;
        }

        internal static ICollection<QuestionDto> ConvertListQuestionToListQuestionDto(ICollection<Question> collectionQuestion)
        {
            List<QuestionDto> listQuestionDto = null;
            if (collectionQuestion != null)
            {
                listQuestionDto = new List<QuestionDto>();
                foreach (Question question in collectionQuestion)
                {
                    listQuestionDto.Add(question);
                }
            }
            return listQuestionDto;
        }

        public static List<Quiz> ConvertListQuizDtoToListQuiz(ICollection<QuizDto> collectionQuizDto)
        {
            List<Quiz> listQuiz = null;
            if (collectionQuizDto != null)
            {
                listQuiz = new List<Quiz>();
                foreach (QuizDto quizDto in collectionQuizDto)
                {
                    listQuiz.Add(quizDto);
                }
            }
            return listQuiz;
        }

        internal static ICollection<QuizDto> ConvertListQuizToListQuizDto(ICollection<Quiz> collectionQuiz)
        {
            List<QuizDto> listQuizDto = null;
            if (collectionQuiz != null)
            {
                listQuizDto = new List<QuizDto>();
                foreach (Quiz quiz in collectionQuiz)
                {
                    listQuizDto.Add(quiz);
                }
            }
            return listQuizDto;
        }

        public static List<Ventillation> ConvertListVentillationDtoToListVentillation(ICollection<VentillationDto> collectionVentillationDto)
        {
            List<Ventillation> listVentillation = null;
            if (collectionVentillationDto != null)
            {
                listVentillation = new List<Ventillation>();
                foreach (VentillationDto ventillationDto in collectionVentillationDto)
                {
                    listVentillation.Add(ventillationDto);
                }
            }
            return listVentillation;
        }

        internal static ICollection<VentillationDto> ConvertListVentillationToListVentillationDto(ICollection<Ventillation> collectionVentillation)
        {
            List<VentillationDto> listVentillationDto = null;
            if (collectionVentillation != null)
            {
                listVentillationDto = new List<VentillationDto>();
                foreach (Ventillation ventillation in collectionVentillation)
                {
                    listVentillationDto.Add(ventillation);
                }
            }
            return listVentillationDto;
        }

        public static List<Reponse> ConvertListReponseDtoToListReponse(ICollection<ReponseDto> collectionReponseDto)
        {
            List<Reponse> listReponse = null;
            if (collectionReponseDto != null)
            {
                listReponse = new List<Reponse>();
                foreach (ReponseDto reponseDto in collectionReponseDto)
                {
                    listReponse.Add(reponseDto);
                }
            }
            return listReponse;
        }

        internal static ICollection<ReponseDto> ConvertListReponseToListReponseDto(ICollection<Reponse> collectionReponse)
        {
            List<ReponseDto> listReponseDto = null;
            if (collectionReponse != null)
            {
                listReponseDto = new List<ReponseDto>();
                foreach (Reponse reponse in collectionReponse)
                {
                    listReponseDto.Add(reponse);
                }
            }
            return listReponseDto;
        }

        public static List<Niveau> ConvertListNiveauDtoToListNiveau(ICollection<NiveauDto> collectionNiveauDto)
        {
            List<Niveau> listNiveau = null;
            if (collectionNiveauDto != null)
            {
                listNiveau = new List<Niveau>();
                foreach (NiveauDto niveauDto in collectionNiveauDto)
                {
                    listNiveau.Add(niveauDto);
                }
            }
            return listNiveau;
        }

        internal static ICollection<NiveauDto> ConvertListNiveauToListNiveauDto(ICollection<Niveau> collectionNiveau)
        {
            List<NiveauDto> listNiveauDto = null;
            if (collectionNiveau != null)
            {
                listNiveauDto = new List<NiveauDto>();
                foreach (Niveau niveau in collectionNiveau)
                {
                    listNiveauDto.Add(niveau);
                }
            }
            return listNiveauDto;
        }

        public static List<ReponseCandidat> ConvertListReponseCandidatDtoToListReponseCandidat(ICollection<ReponseCandidatDto> collectionReponseCandidatDto)
        {
            List<ReponseCandidat> listReponseCandidat = null;
            if (collectionReponseCandidatDto != null)
            {
                listReponseCandidat = new List<ReponseCandidat>();
                foreach (ReponseCandidatDto reponseCandidatDto in collectionReponseCandidatDto)
                {
                    listReponseCandidat.Add(reponseCandidatDto);
                }
            }
            return listReponseCandidat;
        }

        internal static ICollection<ReponseCandidatDto> ConvertListReponseCandidatToListReponseCandidatDto(ICollection<ReponseCandidat> collectionReponseCandidat)
        {
            List<ReponseCandidatDto> listReponseCandidatDto = null;
            if (collectionReponseCandidat != null)
            {
                listReponseCandidatDto = new List<ReponseCandidatDto>();
                foreach (ReponseCandidat reponseCandidat in collectionReponseCandidat)
                {
                    listReponseCandidatDto.Add(reponseCandidat);
                }
            }
            return listReponseCandidatDto;
        }

        public static ICollection<Acteur> ConvertListActeurDtoToListActeur(ICollection<ActeurDto> collectionActeurDto)
        {
            List<Acteur> listActeur = null;
            if (collectionActeurDto != null)
            {
                listActeur = new List<Acteur>();
                foreach (ActeurDto acteurDto in collectionActeurDto)
                {
                    listActeur.Add(acteurDto);
                }
            }
            return listActeur;
        }
        internal static ICollection<ActeurDto> ConvertListActeurToListActeurDto(ICollection<Acteur> collectionActeur)
        {
            List<ActeurDto> listActeurDto = null;
            if (collectionActeur != null)
            {
                listActeurDto = new List<ActeurDto>();
                foreach (Acteur acteur in collectionActeur)
                {
                    listActeurDto.Add(acteur);
                }
            }
            return listActeurDto;
        }

        public static ICollection<Role> ConvertListRoleDtoToListRole(ICollection<RoleDto> collectionRoleDto)
        {
            List<Role> listRole = null;
            if (collectionRoleDto != null)
            {
                listRole = new List<Role>();
                foreach (RoleDto roleDto in collectionRoleDto)
                {
                    listRole.Add(roleDto);
                }
            }
            return listRole;
        }
        internal static ICollection<RoleDto> ConvertListRoleToListRoleDto(ICollection<Role> collectionRole)
        {
            List<RoleDto> listRoleDto = null;
            if (collectionRole != null)
            {
                listRoleDto = new List<RoleDto>();
                foreach (Role role in collectionRole)
                {
                    listRoleDto.Add(role);
                }
            }
            return listRoleDto;
        }

        public static ICollection<Repondu> ConvertListReponduDtoToListRole(ICollection<ReponduDto> collectionReponduDto)
        {
            List<Repondu> listRepondu = null;
            if (collectionReponduDto != null)
            {
                listRepondu = new List<Repondu>();
                foreach (ReponduDto reponduDto in collectionReponduDto)
                {
                    listRepondu.Add(reponduDto);
                }
            }
            return listRepondu;
        }
        internal static ICollection<ReponduDto> ConvertListReponduToListReponduDto(ICollection<Repondu> collectionRepondu)
        {
            List<ReponduDto> listReponduDto = null;
            if (collectionRepondu != null)
            {
                listReponduDto = new List<ReponduDto>();
                foreach (Repondu repondu in collectionRepondu)
                {
                    listReponduDto.Add(repondu);
                }
            }
            return listReponduDto;
        }
    }
}

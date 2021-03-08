using MySql.Data.MySqlClient;
using QuizApi.Dtos;
using QuizApi.quiz;
using QuizApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace QuizApi.Repositories
{
    public class ActeurRepository : IRepository<Acteur>
    {
        private QuizContext context;
        private readonly AppSettings _appSettings;
        private bool disposedValue;

        public ActeurRepository(QuizContext context, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this._appSettings = appSettings.Value;
        }

        public void Delete(int id)
        {
            Acteur obj = FindById(id);
            if (obj != null)
            {
                context.Acteur.Remove(obj);
                Save();
            }
            else throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurRepository.Delete : l'élément {id} n'a pas été trouvé ");
        }

        public IEnumerable<Acteur> FindAll()
        {
            return context.Acteur;
        }

        public Acteur FindById(int id)
        {
            Acteur obj = context.Acteur.Find(id);
            if (obj == null)
                throw new RessourceException(StatusCodes.Status404NotFound, $"ActeurRepository.FindById : l'élément {id} n'a pas été trouvé ");
            return obj;
        }
                
        public Acteur Insert(Acteur obj)
        {
            //validation
            if (string.IsNullOrWhiteSpace(obj.Password))
                throw new RessourceException(404, "Erreur de saisie de mot de passe");
            if(!IsValidEmail(obj.Email))
                throw new RessourceException(404, "L'email \"" + obj.Email + "\" n'est pas valide.");
            if (context.Acteur.Any(x =>x.Email == obj.Email))
                throw new RessourceException(404, "L'email \""+ obj.Email + "\" est déjà utilisé.");
            if(!IsValidPassword(obj.Password))           
                throw new RessourceException(404, "Le password n''a pas au moins 8 caractères, une majuscule et une minuscule.");
            //TODO: crypter le password en System.Security.Cryptography.HMACSHA512
            //byte[] passwordHash, passwordSalt;
            //CreatePasswordHash(obj.Password, out passwordHash, out passwordSalt);
            //obj.PasswordHash = passwordHash;
            //obj.PasswordSalt = passwordSalt;

            context.Acteur.Add(obj);
            Save();
            return obj;
        }

        public ConnectedActeurDto Authenticate(ConnectActeurDto connectActeurDto)
        {
            if (string.IsNullOrEmpty(connectActeurDto.Email) || string.IsNullOrEmpty(connectActeurDto.Password))
                return null;

            var acteur = context.Acteur.SingleOrDefault(x => x.Email == connectActeurDto.Email);            
            
            // check if username exists
            if (acteur == null)
                return null;

            // TODO : check if password is correct
            //if (!VerifyPasswordHash(connectActeurDto.Password, acteur.PasswordHash, acteur.PasswordSalt))
            //    return null;
            if (acteur.Password != connectActeurDto.Password)
                return null;

            //Create token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, acteur.IdActeur.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // authentication successful
            return new ConnectedActeurDto(
            acteur.Nom,
            acteur.Prenom,
            acteur.Email,
            acteur.Password,
            tokenString
            );
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Acteur obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.Password) && !IsValidEmail(obj.Email))
                throw new RessourceException(404, "L'email \"" + obj.Email + "\" n'est pas valide.");
            if (!string.IsNullOrWhiteSpace(obj.Password) && !IsValidPassword(obj.Password))
                throw new RessourceException(404, "Le password n''a pas au moins 8 caractères, une majuscule et une minuscule.");
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    context.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~ActeurRepository()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // TODO : méthode utils privée
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new RessourceException(404, "Le mot de passe ne peut ni être vide ni contenire uniquement des espaces.");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Le mot de passe ne peut ni être vide ni contenire uniquement des espaces.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Taille du password hash invalide (64 bytes attendu).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Taille du password salt (128 bytes attendu).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (Regex.IsMatch(email, pattern))
                return true;
            else
                return false;
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8
               || !password.Any<char>(char.IsUpper)
               || !password.Any<char>(char.IsLower)
               || !password.Any(char.IsDigit))
                return false;
            return true;
        }
    }
}

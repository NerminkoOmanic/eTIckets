using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using eTickets.Model.Requests;
using System.Security.Cryptography;
using System.Text;
using eTicketsAPI.Filters;


namespace eTicketsAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;
        public KorisnikService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<eTickets.Model.Korisnik> Get(KorisnikSearchRequest search = null)
        {
            var dbSet = Context.Korisnik.AsQueryable();

            if (search?.UlogaId != 0) 
            {
                    dbSet = dbSet.Where(x => x.UlogaId == search.UlogaId);

            }
            if (!String.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                    dbSet = dbSet.Where(x => x.KorisnickoIme.Contains(search.KorisnickoIme));
            }
            if (!String.IsNullOrWhiteSpace(search?.KorisnickoImeValidacija))
            {
                    dbSet = dbSet.Where(x => x.KorisnickoIme.Equals(search.KorisnickoImeValidacija));
            }
            if (!String.IsNullOrWhiteSpace(search?.EmailValidacija))
            {
                    dbSet = dbSet.Where(x => x.KorisnickoIme.Equals(search.EmailValidacija));
            }
            if (search?.IncludeList?.Length > 0)
            {
                foreach(var item in search.IncludeList)
                {
                    dbSet = dbSet.Include(item);
                }
            }

            var list = dbSet.ToList();
            return _mapper.Map<List<eTickets.Model.Korisnik>>(list);

        }

        public eTickets.Model.Korisnik GetById(int id)
        {
            var dbSet = Context.Korisnik.Where(x => x.KorisnikId == id)
                                                .Include(x => x.Grad)
                                                .Include(x => x.Spol)
                                                .FirstOrDefault();
            return _mapper.Map<eTickets.Model.Korisnik>(dbSet);
        }

        public eTickets.Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            try
            {
                var entity = _mapper.Map<Database.Korisnik>(request);

                Context.Korisnik.Add(entity);

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

                Context.SaveChanges();

                entity = Context.Korisnik.FirstOrDefault(x => x.KorisnikId == entity.KorisnikId);
                return _mapper.Map<eTickets.Model.Korisnik>(entity);
            }
            catch (Exception e)
            {
                throw new UserException("Username or email is already taken");
            }
            
        }

        public eTickets.Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var entity = Context.Korisnik.Find(id);

            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                request.LozinkaSalt = GenerateSalt();
                request.LozinkaHash = GenerateHash(request.LozinkaSalt, request.Lozinka);
            }
            else
            {
                request.LozinkaSalt = entity.LozinkaSalt;
                request.LozinkaHash = entity.LozinkaHash;
            }


            _mapper.Map(request, entity);

            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new UserException("Email is already taken");

            }


            return _mapper.Map<eTickets.Model.Korisnik>(entity);
        }

        public async Task<eTickets.Model.Korisnik> Login(string username, string password)
        {
            var entity = await Context.Korisnik
                                                .Include(x=>x.Uloga)
                                                .FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if (hash != entity.LozinkaHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<eTickets.Model.Korisnik>(entity);
        }

        public eTickets.Model.Korisnik Profil()
        {

            var entity =  Context.Korisnik
                .Include(x => x.Grad)
                .Include(x => x.Spol)
                .Include(x=>x.Uloga)
                .FirstOrDefault(x => x.KorisnikId == Security.BasicAuthenticationHandler.User.KorisnikId);


            return _mapper.Map<eTickets.Model.Korisnik>(entity);


        }

        #region Password

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        #endregion
    }
}

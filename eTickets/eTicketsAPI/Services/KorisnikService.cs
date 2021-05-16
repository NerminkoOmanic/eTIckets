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


namespace eTicketsAPI.Services
{
    public class KorisnikService : BaseCrudService<eTickets.Model.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {
        public KorisnikService(IB3012Context context, IMapper mapper) : base(context,mapper)
        {
        }

        public override IEnumerable<eTickets.Model.Korisnik> Get(KorisnikSearchRequest search = null)
        {
                var dbSet = Context.Korisnik.AsQueryable();

                if (!String.IsNullOrWhiteSpace(search?.KorisnickoIme))
                {
                    dbSet = dbSet.Where(x => x.KorisnickoIme.Contains(search.KorisnickoIme));
                }

                var list = dbSet.ToList();
                return _mapper.Map<List<eTickets.Model.Korisnik>>(list);

        }

        public override eTickets.Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            Context.Korisnik.Add(entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            Context.SaveChanges();

            return _mapper.Map<eTickets.Model.Korisnik>(entity);
        }

        public override eTickets.Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var entity = Context.Korisnik.Find(id);
            _mapper.Map(request, entity);

            Context.SaveChanges();

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

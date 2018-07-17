using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Repositorio
{
    public class CandidatoRepositorio : BaseRepository<Candidato>, ICandidatoRepositorio
    {

        private readonly IHttpContextAccessor contextAccessor;

        public CandidatoRepositorio(ApplicationContext contexto) : base(contexto)
        {
            
        }


        public void Adicionar(BaseModel baseModel)
        {        
             contexto.Add(baseModel);
             contexto.SaveChanges();
           
        }

        public void Remover(BaseModel baseModel)
        {
            contexto.Remove(baseModel);
            contexto.SaveChanges();
        }

        public Candidato Retornar(string email)
        {
            return contexto.Candidato.Find(email);
        }

        public IList<BaseModel> RetornarTodos()
        {
            IQueryable<BaseModel> retorno = contexto.Set<Candidato>();
            return retorno.ToList();
        }
    }
}

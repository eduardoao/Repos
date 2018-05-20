using System;
using System.Collections.Generic;
using System.Linq;
using WebLocadoras.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebLocadoras.Data
{
    public class AcessoDados 
    {
        private readonly DbContexto _contexto;       

        public AcessoDados(DbContexto contexto)
        {
            _contexto = contexto;           
        }

        #region Clientes
        public void AdicionarCliente(EntidadeCliente cliente)
        {
            if (cliente.Nome != null && cliente.Id == 0)
            {
                _contexto.DataCliente.Add(cliente);
            }
            else
            {
                var clienteexistente = _contexto.DataCliente.Find(cliente.Id);
                clienteexistente.Nome = cliente.Nome;
                clienteexistente.Cpf = cliente.Cpf;               
            }

            _contexto.DataCliente.Add(cliente);
            _contexto.SaveChanges();
        }

        public void AtualizarCliente(EntidadeCliente cliente)
        {
            _contexto.DataCliente.Update(cliente);
            _contexto.SaveChanges();
        }

        public void ExcluirCliente(int clienteId)
        {
            var entidadecliente = _contexto.DataCliente.First(t => t.Id == clienteId);
            _contexto.DataCliente.Remove(entidadecliente);
            _contexto.SaveChanges();
        }

        public EntidadeCliente RetornarClienteId(int clienteId)
        {
            return _contexto.DataCliente.First(t => t.Id == clienteId);
        }

        public List<EntidadeCliente> ListarClientes()
        {           
            return _contexto.DataCliente.ToList();
        }

        #endregion

        #region Filmes
        public void AdicionarFilme(EntidadeFilme filme)
        {
            if (filme.Filme != null && filme.Id == 0)
            {
                _contexto.DataFilme.Add(filme);
            }
            else
            {
                var filmeexistente = _contexto.DataFilme.Find(filme.Id);
                filmeexistente.Filme = filme.Filme;
                filmeexistente.Genero = filme.Genero;
            }

            _contexto.DataFilme.Add(filme);
            _contexto.SaveChanges();
        }

        public void AtualizarFilme(EntidadeFilme filme)
        {
            _contexto.DataFilme.Update(filme);
            _contexto.SaveChanges();
        }

        public void ExcluirFilme(int filmeId)
        {
            var entidadefilme = _contexto.DataFilme.First(t => t.Id == filmeId);
            _contexto.DataFilme.Remove(entidadefilme);
            _contexto.SaveChanges();
        }

        public EntidadeFilme RetornarFilmeId(int filmeId)
        {
            return _contexto.DataFilme.First(t => t.Id == filmeId);
        }

        public List<EntidadeFilme> ListarFilmes()
        {
            return _contexto.DataFilme.ToList();
        }
        #endregion

        #region Locacao
        public void AdicionarLocacao(EntidadeLocacao locacao)
        {
            if (locacao.Id == 0)
            {
                _contexto.DataLocacao.Add(locacao);
            }
            else
            {
                var locacaoexistente = _contexto.DataLocacao.Find(locacao.Id);
                locacaoexistente.Id = locacao.Id;
                locacaoexistente.Filme = locacao.Filme;
                locacaoexistente.Cliente = locacao.Cliente;
                locacaoexistente.DataLocacao = locacao.DataLocacao;
                locacaoexistente.DataDevolucao = locacao.DataDevolucao;
                _contexto.DataLocacao.Add(locacaoexistente);
            }
           
            _contexto.SaveChanges();
        }

        public void AtualizarLocacao(EntidadeLocacao locacao)
        {
            _contexto.DataLocacao.Update(locacao);
            _contexto.SaveChanges();
        }

        public void ExcluirLocacao(int locacaoId) 
        {
            var entidadelocacao = _contexto.DataLocacao.First(t => t.Id == locacaoId);
            _contexto.DataLocacao.Remove(entidadelocacao);
            _contexto.SaveChanges();
        }

        public EntidadeLocacao RetornarLocacaoId(int locacaoId)
        {
            return _contexto.DataLocacao.First(t => t.Id == locacaoId);
        }

        public List<EntidadeFilme> ListarLocacao(int locacaoId)
        {
            return _contexto.DataFilme.Where(l => l.Id == locacaoId).ToList();
        }

        #endregion




    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using Uniplac.Lavacao.Dados.Repositorios;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;

namespace Uniplac.Lavacao.Aplicacao
{
    public class PostServico : IPostServico
    {
        private IPostRepositorio _postRepositorio;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public PostServico()
        {
            _postRepositorio = new PostRepositorio();

            _consumerKey = "maZeqDAU3bExacDdwOcsvtx9F";
            _consumerSecret = "xqGcWc1vgcIqmvnMfKepo7oaWhiOX9xV8qx0TPNmdZvxYHm3Q6";
            _accessToken = "747549868156141569-IUNjhxphud2Jh4ebITVixE6lDP5uIzC";
            _accessTokenSecret = "ZpiWIRmf3nv8uSgQbBZ5TuLMfe4duMwI74ZuacijoR4DH";
            
        }

        public Post CriarOuAtualizar(Post post)
        {
            var service = GetAuthenticatedService();

            post.Validacao();

            var status = post.PostMensagem;
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });

            return _postRepositorio.CriarOuAtualizar(post);
        }

        public Post Retornar(long id)
        {
            return _postRepositorio.Retornar(id);
        }

        public IEnumerable<Post> RetornarTodos()
        {
            return _postRepositorio.RetornarTodos();
        }

        public void Deletar(Post post)
        {
            _postRepositorio.Deletar(post);
        }

        private TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }
    }
}

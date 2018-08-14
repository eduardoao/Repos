using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerFacebook
{
    public class NetCoders : Robo
    {
        /// <summary>
        /// Construtor para instânciar o Client
        /// </summary>
        public NetCoders()
        {
            RoboWebClient = new RoboWebClient();
        }

        /// <summary>
        /// Método onde é feito o crawler para carregar os posts.
        /// </summary>
        /// <returns>Lista de artigos ordenada por data.</returns>
        public List<artigo> CarregaPosts()
        {
            NameValueCollection parametros = new NameValueCollection();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //Carrega a página inicial do Blog.
            //Estou atribuindo o resultado ao HtmlAgilityPack para fazer o parse do HTML.
            this.RoboWebClient._allowAutoRedirect = false;
            var ret = this.HttpGet(@"http://netcoders.com.br/");

            //Capturando apenas as tags que estão definidas como article e ordenando pelo ID de cada Tag.
            var artigosOrdenados = ret.DocumentNode.Descendants().Where(n => n.Name == "article").OrderBy(d => d.Id).ToList();
            List<artigo> artigos = new List<artigo>();

            //Percorrendo os artigos que ja foram selecionados.
            foreach (var item in artigosOrdenados)
            {
                artigo art = new artigo();

                //Carregando o Html de cada artigo.
                doc.LoadHtml(item.InnerHtml);

                //Estou utilizando o HtmlAgilityPack.HtmlEntity.DeEntitize para fazer o HtmlDecode dos textos capturados de cada artigo.
                // Utilizo também o UTF8 para limpar o restante dos Encodes que estiverem na página.
                art.Titulo = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "post-title entry-title").InnerText));
                art.Data = Convert.ToDateTime(HtmlAgilityPack.HtmlEntity.DeEntitize(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Name == "span" && d.Attributes["class"].Value == "post-time").InnerText));
                art.Descricao = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "entry-content").InnerText));
                art.Autor = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "post-author").InnerText));
                artigos.Add(art);
            }

            return artigos.OrderBy(d => d.Data).ToList();
        }

        private string ConvertUTF(string texto)
        {
            // Convertendo o texto para o Enconding default e Array de bytes.
            byte[] data = Encoding.Default.GetBytes(texto);

            //Convertendo o texto limpo para UTF8.
            string ret = Encoding.UTF8.GetString(data);

            return ret;
        }

    }

    /// <summary>
    /// Classe espelho do artigo.
    /// </summary>
    public class artigo
    {
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
    }
}

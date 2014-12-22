using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using AulaWebApi.Models;


namespace ApresentacaoWebApi.View
{
    public partial class Default : System.Web.UI.Page
    {
        HttpClient client;
        Uri usuarioUri;


        public Default()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:1020");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/jason"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               getAll();
            }
        }

        private void getAll()
        {
          //Cmando a Api pela URL
            HttpResponseMessage response = client.GetAsync("api/usuarios").Result;

            //Se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //Pegando cabeçalho
                usuarioUri = response.Headers.Location;
                //Pegando os dados do Rest e armazenando na variável usuários
                var usuarios = response.Content.ReadAsAsync<IEnumerable<Usuario>>().Result;

                //preenchendo a lista com os dados retornados da variável
                GridUsuario.DataSource = usuarios;
                GridUsuario.DataBind();
            }
            else
            {
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
            }
        }


    }
}
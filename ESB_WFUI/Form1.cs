using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESB_WFUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //fucking Consulta
        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var json = n.DownloadString("http://localhost:8081/?comandosql=consultar&usuarioID=" + idTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(json);
                //debug
                Console.WriteLine(json);
                //Fazendo o parse com o Json.Net usando array
                usuarioSOA[] usuario_raw = JsonConvert.DeserializeObject<usuarioSOA[]>(json);
                usuarioSOA usuario = usuario_raw[0];
                //Esse metodo funcionaria se o MULE passasse um json apenas e não um array de objetos :/
                //usuarioSOA usuario = JsonConvert.DeserializeObject<usuarioSOA>(json);
                //Setando os campos da interface com os valores do Json
                nomeTexto.Text = usuario.nome;
                nascimentoTexto.Text = usuario.data_nasc;
                enderecoTexto.Text = usuario.endereco;
                numEndTexto.Text = usuario.numero_end.ToString();
                endCompTexto.Text = usuario.end_complemento;
                cepTexto.Text = usuario.cep.ToString();
                cidadeTexto.Text = usuario.cidade;
                estadoTexto.Text = usuario.UF;
                foneTexto.Text = usuario.telefone;
                celularTexto.Text = usuario.celular;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inserirBotao_Click(object sender, EventArgs e)
        {

        }


        private void apagaBotao_Click_1(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var text = n.DownloadString("http://localhost:8081/?comandosql=apagar&usuarioID=" + idTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(text);
                //debug
                Console.WriteLine(valorOriginal);
                //Fazendo o parse com o Json.Net usando array
                //usuarioSOA[] usuario_raw = JsonConvert.DeserializeObject<usuarioSOA[]>(json);
                //usuarioSOA usuario = usuario_raw[0];
                //Esse metodo funcionaria se o MULE passasse um json apenas e não um array de objetos :/
                //usuarioSOA usuario = JsonConvert.DeserializeObject<usuarioSOA>(json);
                //Mule sempre voltar quantas linhas foram apagadas no metodo Delete, como estamos procurando apenas UMA coluna
                //se ele achar a mesma o retorno no html será UM, se não 0.
                if (valorOriginal == "1")
                {
                    MessageBox.Show("Usuario Apagado");
                } else {
                    MessageBox.Show("Erro");
                }
            }
        }
        
        //Botao Alterar
        private void alteraBotao_Click_1(object sender, EventArgs e)
        {
            using (WebClient webClient = new System.Net.WebClient())
            {
                //criando conexão
                WebClient n = new WebClient();
                //URL do mule local
                var text = n.DownloadString("http://localhost:8081/?comandosql=apagar&usuarioID=" + idTexto.Text);
                //convertendo pra string just in case
                string valorOriginal = Convert.ToString(text);
                //debug
                Console.WriteLine(valorOriginal);
            }
        }
    }
}

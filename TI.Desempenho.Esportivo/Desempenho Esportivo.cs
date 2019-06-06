using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TI.Desempenho.Esportivo.Service;
using TI.Desempenho.Esportivo.Model;
using TI.Desempenho.Esportivo.Service.Interface;
using System.IO;

namespace TI.Desempenho.Esportivo
{
    public partial class Desempenho_Esportivo : Form
    {
        public Desempenho_Esportivo()
        {
            InitializeComponent();
        }
        string caminho = "";
        string caminho2 = "";
        Time defaultTeam = new Time("Default");

        private void Desempenho_Esportivo_Load(object sender, EventArgs e)
        {
            label4.Text = "" + defaultTeam.nome;
        }


        private void PreencheTime(Time time, StreamReader dados)
        {
            string[] informacoes;
            while (!dados.EndOfStream)
            {
                informacoes = dados.ReadLine().Split(';');
                if (informacoes.Length != 3)
                {
                    throw new ArgumentException(String.Format("Arquivo no formato errado"));
                }
                time.AddJogador(informacoes[1], Convert.ToInt32(informacoes[2]), Convert.ToInt32(informacoes[0]));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = textboz1_NovoNome.Text;
            defaultTeam.nome = textboz1_NovoNome.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (label5.Text == "Sem arquivo")
            {
                MessageBox.Show("Não há arquivo selecionado");
            }
            else
            {
                listView1.Items.Clear();
                foreach (var item in defaultTeam.jogadores)
                {
                    ListViewItem list = new ListViewItem(Convert.ToString(item.camisa), 0);
                    list.SubItems.Add(item.nome);
                    list.SubItems.Add(Convert.ToString(item.posicao));

                    listView1.Items.Add(list);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "TXT|*.txt";
            StreamReader DadosDoTime;

            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                caminho += arquivo.FileName;
                DadosDoTime = new StreamReader(caminho);
                try
                {
                    PreencheTime(defaultTeam, DadosDoTime);
                }
                catch (ArgumentException x)
                {
                    MessageBox.Show("" + x.Message);
                }
                finally
                {
                    label5.Text = "Sem arquivo";
                }

                DadosDoTime.Close();

                label5.Text = arquivo.SafeFileName;

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var numCamisa = Convert.ToInt32(listView1.SelectedItems[0].Text);

            var relatorio = defaultTeam.RelatorioJogadores();

            foreach (var item in relatorio)
            {
                if (item.numCamisa == numCamisa)
                {
                    label8.Text = string.Format("Media Time {0}\nMedia: {1} \n Status: {2}", defaultTeam.MediaPontosTime().ToString("F2"), item.pontos.ToString("F2"), item.status);
                }
            }
            foreach (var jogador in defaultTeam.jogadores)
            {
                if(jogador.camisa == numCamisa)
                {
                    richTextBox1.Clear();
                    richTextBox1.Text += jogador.listaJogadas();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ListaTimes_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PreencheJogadas(Time time, StreamReader dados)
        {
            string[] informacoes;
            while (!dados.EndOfStream)
            {
                informacoes = dados.ReadLine().Split(';');
                if (informacoes.Length == 2)
                {
                    foreach (var jogador in time.jogadores)
                    {
                        if (int.Parse(informacoes[0]) == jogador.camisa)
                        {
                            jogador.AddJogada(int.Parse(informacoes[1]), 1);
                        }
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "TXT|*.txt";
            StreamReader DadosDasPartidas;

            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                caminho2 += arquivo.FileName;
                DadosDasPartidas = new StreamReader(caminho2);
                try
                {
                    PreencheJogadas(defaultTeam, DadosDasPartidas);
                }
                catch (ArgumentException x)
                {
                    MessageBox.Show("" + x.Message);
                }
                finally
                {
                    label9.Text = "Sem arquivo";
                }

                DadosDasPartidas.Close();

                label9.Text = arquivo.SafeFileName;

                label7_pontuacaoTotal.Text += defaultTeam.PontosTotaisTime();
                label7.Text += defaultTeam.MediaPontosTime();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_pontuacaoTotal_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int posicao;

             posicao = comboBox1.SelectedIndex;

            defaultTeam.AddJogador(textBox1.Text, int.Parse(maskedTextBox1.Text),posicao);
            
        }
    }
}

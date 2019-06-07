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
                label14.Text = defaultTeam.ProcurarJogadorMaiorPontuacao().nome;
                listView1.Items.Clear();
                foreach (var item in defaultTeam.jogadores)
                {
                    if (item != null)
                    {
                        ListViewItem list = new ListViewItem(Convert.ToString(item.camisa), 0);
                        list.SubItems.Add(item.nome);
                        list.SubItems.Add(Convert.ToString(item.posicao));

                        listView1.Items.Add(list);
                    }
                    else
                    {
                        ListViewItem list = new ListViewItem("--", 0);
                        list.SubItems.Add("---------");
                        list.SubItems.Add("---");

                        listView1.Items.Add(list);
                    }
                   
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

            if (listView1.SelectedItems[0].Text != "--")
            {
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
                    if (jogador != null)
                    {

                        if (jogador.camisa == numCamisa)
                        {
                            richTextBox1.Clear();
                            richTextBox1.Text += jogador.listaJogadas();
                        }
                    }
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

        private void button5_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "TXT|*.txt";
            StreamReader DadosDasPartidas;
            
            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                caminho2 = "";
                caminho2 += arquivo.FileName;
                DadosDasPartidas = new StreamReader(caminho2);
                try
                {
                    int gols = 0;
                    int golsSofridos = 0;
                    int vitorias = 0;
                    int derrotas = 0;
                    int jogos = 0;

                    DadosDasPartidas = new StreamReader(caminho2);
                    string[] informacoes;
                    var idPartida = 0;
                    while (!DadosDasPartidas.EndOfStream)
                    {
                        informacoes = DadosDasPartidas.ReadLine().Split(';');
                        if (informacoes.Length == 4)
                        {
                            idPartida++;

                            ListViewItem list = new ListViewItem(Convert.ToString(informacoes[0]), 0);
                            list.SubItems.Add(informacoes[1] + " X " + informacoes[2]);
                            gols += Convert.ToInt32(informacoes[1]);
                            golsSofridos += Convert.ToInt32(informacoes[2]);

                            if (Convert.ToInt32(informacoes[1]) > Convert.ToInt32(informacoes[2]))
                            {
                                list.SubItems.Add(Convert.ToString("Vitória"));
                                vitorias++;
                            }
                            if (Convert.ToInt32(informacoes[1]) == Convert.ToInt32(informacoes[2]))
                            {
                                list.SubItems.Add(Convert.ToString("Empate"));
                            }
                            else
                            {
                                list.SubItems.Add(Convert.ToString("Derrota"));
                                derrotas++;
                            }
                            listView2.Items.Add(list);

                            jogos = listView2.Items.Count;
                            label21.Text = Convert.ToString(gols);
                            label22.Text = Convert.ToString(golsSofridos);
                            label23.Text = Convert.ToString(vitorias);
                            label24.Text = Convert.ToString(derrotas);
                            label25.Text = Convert.ToString(jogos);
                            label26.Text = Convert.ToString( jogos - vitorias - derrotas);

                        } else if (informacoes.Length == 2)
                        {
                            foreach (var jogador in defaultTeam.jogadores)
                            {
                                if (jogador != null)
                                {
                                    if (int.Parse(informacoes[0]) == jogador.camisa)
                                    {
                                        jogador.AddJogada(int.Parse(informacoes[1]), idPartida);
                                    }
                                }
                               
                            }                            
                        }
                    }
                    //RANCA TOCO FC; 1; 1; 48
                    DadosDasPartidas.Close();
                }
                catch (ArgumentException x)
                {
                    MessageBox.Show("" + x.Message);
                }
                finally
                {
                    label9.Text = "Sem arquivo";
                }
                label9.Text = arquivo.SafeFileName;

                label7_pontuacaoTotal.Text += defaultTeam.PontosTotaisTime().ToString("F2");
                label7.Text += defaultTeam.MediaPontosTime().ToString("F2");
                
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
            if (String.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Favor preencher todos os formulários");
            }
            else if ( String.IsNullOrEmpty(comboBox1.Text))
            {

                MessageBox.Show("Favor preencher todos os formulários");
            }
            else if (String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Favor preencher todos os formulários");
            }
            else
            {
                int posicao = comboBox1.SelectedIndex +1;

                defaultTeam.AddJogador(textBox1.Text,posicao, int.Parse(maskedTextBox1.Text));

                MessageBox.Show("Jogador criado com sucesso!");
            }
            
            
        }

       
        private void button7_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Favor preencher o formulario");
            }
            else
            {
                foreach (var item in defaultTeam.jogadores)
                {
                    if (item != null)
                    {
                        if (item.nome == textBox2.Text)
                        {
                            defaultTeam.RemoverJogador(item.nome);
                            MessageBox.Show("Jogador removido com sucesso!");
                            button3_Click(null, null);
                        }
                    }
                }
            }
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.Desempenho.Esportivo.Factory;

namespace TI.Desempenho.Esportivo.Service
{
    public class Jogador
    {
        #region Membros

        private JogadaFactory jogadaFactory;

        private string _nome;
        private Posicao _posicao;
        private int _numCamisa;
        private List<Jogada> _jogadas;

        #endregion

        #region Getters/Setters

        public string nome
        {
            get { return _nome; }
            set
            {
                if (value.Length != 0)
                    _nome = value;
                else
                    _nome = "Joaozin Perna de Pau";
            }
        }

        public Posicao posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }

        public int camisa
        {
            get { return _numCamisa; }
            set
            {
                if (value > 0)
                    _numCamisa = value;
                else
                {
                    Random rnd = new Random();
                    _numCamisa = rnd.Next(1, 200);
                }
            }
        }

        #endregion

        #region Construtor

        private void init(String nome, int posicao, int camisa)
        {
            this.nome = nome;
            this.posicao = new Posicao(posicao);
            this.camisa = camisa;
        }

        public Jogador()
        {
            this.init("Ricardo Jorge de Assis Jgdr EXE", 3, 21);
        }

        public Jogador(String nome, int posicao, int camisa)
        {
            this.init(nome, posicao, camisa);
        }

        #endregion

        public bool AddJogada(int codJogada)
        {
            var numJogadasAnterior = this._jogadas.Count;
            this._jogadas.Add(jogadaFactory.CriarJogada(codJogada, this.posicao.nomPosicao));
            if (!(numJogadasAnterior == this._jogadas.Count))
                return true;
            return false;
        }

    }
}

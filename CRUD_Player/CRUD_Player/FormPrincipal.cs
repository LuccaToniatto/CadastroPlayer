﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Player
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            List<Jogador> jogadores = jogador.listajogador();
            dgvPlayer.DataSource = jogadores;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            jogador.Inserir(txtNome.Text, txtCidade.Text, txtEmail.Text, txtCelular.Text);
            MessageBox.Show("Cadastro realizado com sucesso!");
            List<Jogador> jogadores = jogador.listajogador();
            dgvPlayer.DataSource = jogadores;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtID.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Localizar(Id);
            txtNome.Text = jogador.nome;
            txtCidade.Text = jogador.cidade;
            txtEmail.Text = jogador.email;
            txtCelular.Text = jogador.celular;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtID.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Atualizar(Id,txtNome.Text, txtCidade.Text, txtEmail.Text, txtCelular.Text);
            MessageBox.Show("Cadastro Atualizado com sucesso!");
            List<Jogador> jogadores = jogador.listajogador();
            dgvPlayer.DataSource = jogadores;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtID.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Excluir(Id);
            List<Jogador> jogadores = jogador.listajogador();
            dgvPlayer.DataSource = jogadores;
            MessageBox.Show("Cadastro excluido com sucesso");
            txtNome.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }
    }
}

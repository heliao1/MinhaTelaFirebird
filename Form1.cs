// Esta linha permite que o C# use os comandos do Firebird
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace MinhaTelaFirebird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Configure as informações do seu banco de dados local
            // ATENÇÃO: Altere o caminho C:\SeuBanco\dados.fdb para o caminho real do seu arquivo
            string caminhoBanco = @"C:\Users\Helio\Downloads\firebird\teknikao.fdb";

            string connString = $"DataSource=localhost;Database={caminhoBanco};User ID=SYSDBA;Password=masterkey;Dialect=3;";

            // 2. Escreva o comando SQL para buscar os dados
            // ATENÇÃO: Substitua CLIENTES pelo nome em MAIÚSCULO da sua tabela do Firebird
            string query = "SELECT * FROM EMPRESAS";

            // 3. Abre a conexão e busca os dados de forma segura
            using (FbConnection conexao = new FbConnection(connString))
            {
                try
                {
                    conexao.Open(); // Abre as portas do banco

                    // Cria um adaptador para ler os dados da query SQL
                    FbDataAdapter adapter = new FbDataAdapter(query, conexao);

                    // Cria uma tabela virtual na memória do computador
                    DataTable tabelaDados = new DataTable();

                    // Preenche essa tabela virtual com os dados do Firebird
                    adapter.Fill(tabelaDados);

                    // Joga os dados da tabela virtual para o componente Grid da sua tela
                    dataGridView1.DataSource = tabelaDados;

                    MessageBox.Show("Dados carregados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Caso dê algum erro (caminho errado, senha errada, etc), ele avisa aqui
                    MessageBox.Show("Erro ao conectar ou buscar dados: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {
          
        {
            // Configure as informações do seu banco de dados local (Lembre de ajustar o nome do arquivo .fdb)
            string caminhoBanco = @"C:\Users\Helio\Downloads\firebird\teknikao.fdb";
            string connString = $"DataSource=localhost;Database={caminhoBanco};User ID=SYSDBA;Password=masterkey;Dialect=3;";

                // 1. Criamos a consulta SQL base buscando da tabela EMPRESAS
                // Usamos 'WHERE NOME LIKE @termo' para filtrar o texto digitado
                // ATENÇÃO: Substitua 'NOME' pelo nome real da coluna de texto da sua tabela (ex: RAZAO_SOCIAL, NOME_FANTASIA)
                //string query = "SELECT * FROM EMPRESAS WHERE UPPER(NOME) LIKE UPPER(@termo)"; FUNCIONANDO
                string query = "SELECT  h.data AS data,\r\n    f.nome,\r\n    h.nota, \r\n    e.nome AS empresa, \r\n    e.estado AS ES,\r\n    e.cidade, \r\n    e.cnpj\r\nFROM empresas AS e\r\nINNER JOIN historicos AS h ON e.id_empresa = h.id_empresa\r\nINNER JOIN funcionarios AS f ON h.id_funcionario = f.id_funcionario\r\nWHERE e.nome CONTAINING COALESCE(NULLIF(:busca_nome, ''), e.nome)\r\n  AND e.cnpj = COALESCE(NULLIF(:busca_cnpj, ''), e.cnpj)\r\nORDER BY h.data DESC;";

                using (FbConnection conexao = new FbConnection(connString))
            {
                try
                {
                    conexao.Open();

                    // Usamos o FbCommand para injetar o texto de busca de forma segura (evita ataques de SQL Injection)
                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        // O símbolo '%' antes e depois faz com que o Firebird busque o texto em qualquer parte do nome
                        string termoBusca = "%" + txtBusca.Text + "%";
                        comando.Parameters.AddWithValue("@termo", termoBusca);

                        // Criamos o adaptador passando o comando configurado com o parâmetro
                        FbDataAdapter adapter = new FbDataAdapter(comando);
                        DataTable tabelaDados = new DataTable();
                        adapter.Fill(tabelaDados);

                        // Exibe os dados filtrados na tabela da tela
                        dataGridView1.DataSource = tabelaDados;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

        private void button2_Click(object sender, EventArgs e)
        {
            //private void button2_Click(object sender, EventArgs e)
        {
            // 1. Criamos uma "instância" (uma cópia) da nova tela na memória
            Form2 Busca = new Form2();

            // 2. Exibimos a nova tela
            Busca.Show();
        }

    }

        private void Form1_Load(object sender, EventArgs e)
        {
            //private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Criamos a instância do Form2
            Form2 telaAba = new Form2();

            // 2. IMPORTANTE: Avisamos que ele NÃO é uma janela independente
            telaAba.TopLevel = false;

            // 3. Removemos as bordas de janela (botões de fechar, maximizar, etc.)
            telaAba.FormBorderStyle = FormBorderStyle.None;

            // 4. Fazemos ele preencher todo o espaço da aba escolhida
            telaAba.Dock = DockStyle.Fill;

            // 5. Adicionamos o Form2 de fato dentro dos controles da tabPage2
            tabPage2.Controls.Add(telaAba);

            // 6. Mandamos o Form2 se desenhar e aparecer dentro da aba
            telaAba.Show();
        }

    }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

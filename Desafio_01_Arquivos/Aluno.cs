namespace Desafio_01_Arquivos
{
    public class Aluno : Pessoa
    {
        private static List<Aluno> listaAlunos = new List<Aluno>();
        private string codigoCurso, matricula, nomeCurso;

        public Aluno(string nome, string telefone, string cidade, string rg, string cpf, string matricula, string codigoCurso, string nomeCurso) : base(nome, telefone, cidade, rg, cpf)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cidade = cidade;
            this.rg = rg;
            this.cpf = cpf;
            this.matricula = matricula;
            this.codigoCurso = codigoCurso;
            this.nomeCurso = nomeCurso;
            listaAlunos.Add(this);
        }

        ///<summary>Exibe na tela todos os alunos registrados.</summary>
        public static void MostrarAlunos()
        {
            Console.Write("\n\n[MOSTRANDO ALUNOS CADASTRADOS]");
            foreach (var aluno in listaAlunos)
            {
                Console.Write($"\n\n[{listaAlunos.IndexOf(aluno) + 1}] Aluno(a): {aluno.nome}\n" +
                    $"       Curso: {aluno.nomeCurso} (código {aluno.codigoCurso})\n" +
                    $"   Matrícula: {aluno.matricula}");
            }
        }

        ///<summary>Verifica quantos alunos existem na lista de registros.</summary>
        ///<returns>Retorna a quantidade total de alunos registrados.</returns>
        public static int VerificarQuantidadeAlunos()
        {
            return listaAlunos.Count;
        }
    }
}
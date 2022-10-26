namespace Desafio_01_Arquivos
{
    public class Pessoa
    {
        private static List<Pessoa> listaPessoas = new List<Pessoa>();
        protected string cidade, cpf, nome, rg, telefone;

        public Pessoa(string nome, string telefone, string cidade, string rg, string cpf)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cidade = cidade;
            this.rg = rg;
            this.cpf = cpf;
            listaPessoas.Add(this);
        }

        ///<summary>Exibe na tela todas as pessoas registradas.</summary>
        public static void MostrarPessoas()
        {
            Console.Write("\n\n[MOSTRANDO PESSOAS CADASTRADAS]");
            foreach (var pessoa in listaPessoas)
            {
                Console.Write($"\n\n[{listaPessoas.IndexOf(pessoa) + 1}] Nome: {pessoa.nome}\n" +
                    $"Telefone: {pessoa.telefone}\n" +
                    $"  Cidade: {pessoa.cidade}\n" +
                    $"      RG: {pessoa.rg}\n" +
                    $"     CPF: {pessoa.cpf}");
            }
        }

        ///<summary>Verifica quantas pessoas existem na lista de registros.</summary>
        ///<returns>Retorna a quantidade total de pessoas registradas.</returns>
        public static int VerificarQuantidadePessoas()
        {
            return listaPessoas.Count;
        }
    }
}
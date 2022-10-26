/*
Desafio 01 (Arquivos):

- Criar as classes "Aluno" e "Pessoa", além de outras que achar necessário;
- "Aluno" herda os atributos e métodos de "Pessoa";
- Analisar o "Manual do Arquivo TXT" disponibilizado pelos professores para pensar nos métodos e atributos de cada classe;
- Ler o "Arquivo TXT" disponibilizado pelos professores, extraindo os dados e criando objetos a partir deles;
- Mostrar na tela quantos objetos do tipo "Pessoa" e quantos do tipo "Aluno" foram criados;
- Mostrar os cursos de cada "Aluno".

Arquivo TXT:

X-4565-486544
Z-Bernard Cornwell-5587849565-Recife-5458745982-04148562486
Y-1356-1313-Arqueologia Marinha
Z-Mary Shelley-5185695214-Santa Maria-5698547895-15478569840
Y-1797-1851-Enxertos
Z-Phillips Lovecraft-5584709655-Porto Alegre-5645895632-54898745625
Y-1917-1854-Variáveis Dimencionais
Z-Harlan Coben-5487965899-São Paulo-5485489652-36521478541
Z-Danelle Perry-1358485265-Caxias do Sul-5632144569-02654187490
Y-1152-3354-Contagiosidade
Z-William Peter Blatty-5532114587-Santa Maria-5102526547-01919647080
Y-666-1114-Demologia
Z-Suzanne Collins-4598562321-Florianopolis-6587878841-02587412369

Manual do Arquivo TXT:

- "-" é o caractere delimitador, separando os dados de uma mesma linha.
- A "Linha Y" sempre vem depois de uma "Linha Z", logo, a "Linha Y" é sobre o curso do(a) aluno(a) da "Linha Z".
- Se não houver uma "Linha Y" depois da "Linha Z", significa que é apenas uma pessoa, e não um(a) aluno(a).
- Linha X → Cabeçalho do arquivo (a dica é ignorá-la).
- Linha Z → Dados de pessoas, com a seguinte sintaxe: Z-[Nome]-[Telefone]-[Cidade]-[RG]-[CPF].
- Linha Y → Dados de alunos(as), com a seguinte sintaxe: Y-[Matrícula]-[Código do Curso]-[Nome do Curso].
*/

namespace Desafio_01_Arquivos
{
    public class Program
    {
        static void Main()
        {
            List<string> dadosIndividuaisBrutos = new List<string>();
            StreamWriter escritor = new StreamWriter("Informações Pessoais.txt");
            string cidade, codigoCurso, cpf, dadosColetivos, matricula, nome, nomeCurso, rg, telefone;
            escritor.Write("X-4565-486544\n" +
                "Z-Bernard Cornwell-5587849565-Recife-5458745982-04148562486\n" +
                "Y-1356-1313-Arqueologia Marinha\n" +
                "Z-Mary Shelley-5185695214-Santa Maria-5698547895-15478569840\n" +
                "Y-1797-1851-Enxertos\n" +
                "Z-Phillips Lovecraft-5584709655-Porto Alegre-5645895632-54898745625\n" +
                "Y-1917-1854-Variáveis Dimencionais\n" +
                "Z-Harlan Coben-5487965899-São Paulo-5485489652-36521478541\n" +
                "Z-Danelle Perry-1358485265-Caxias do Sul-5632144569-02654187490\n" +
                "Y-1152-3354-Contagiosidade\n" +
                "Z-William Peter Blatty-5532114587-Santa Maria-5102526547-01919647080\n" +
                "Y-666-1114-Demologia\n" +
                "Z-Suzanne Collins-4598562321-Florianopolis-6587878841-02587412369");
            escritor.Close();
            StreamReader leitor = new StreamReader("Informações Pessoais.txt");
            dadosColetivos = leitor.ReadToEnd();
            leitor.Close();
            dadosIndividuaisBrutos.AddRange(dadosColetivos.Split("\nZ-"));
            foreach (var fraseBruta in dadosIndividuaisBrutos)
            {
                List<string> dadosPessoais = new List<string>();
                List<string> dadosAcademicos = new List<string>();
                List<string> dadosIndividuaisEspecificos = new List<string>();
                if (!fraseBruta.Contains("X-"))
                {
                    dadosIndividuaisEspecificos.AddRange(fraseBruta.Split("\nY-"));
                    foreach (var informacao in dadosIndividuaisEspecificos)
                    {
                        if (dadosIndividuaisEspecificos.IndexOf(informacao) == 0)
                        {
                            dadosPessoais.AddRange(informacao.Split("-"));
                        }
                        else
                        {
                            dadosAcademicos.AddRange(informacao.Split("-"));
                        }
                    }
                    nome = null;
                    telefone = null;
                    cidade = null;
                    rg = null;
                    cpf = null;
                    foreach (var informacao in dadosPessoais)
                    {
                        if (dadosPessoais.IndexOf(informacao) == 0)
                        {
                            nome = informacao;
                        }
                        else if (dadosPessoais.IndexOf(informacao) == 1)
                        {
                            telefone = informacao;
                        }
                        else if (dadosPessoais.IndexOf(informacao) == 2)
                        {
                            cidade = informacao;
                        }
                        else if (dadosPessoais.IndexOf(informacao) == 3)
                        {
                            rg = informacao;
                        }
                        else
                        {
                            cpf = informacao;
                        }
                    }
                    matricula = null;
                    codigoCurso = null;
                    nomeCurso = null;
                    if (dadosIndividuaisEspecificos.Count > 1)
                    {
                        foreach (var informacao in dadosAcademicos)
                        {
                            if (dadosAcademicos.IndexOf(informacao) == 0)
                            {
                                matricula = informacao;
                            }
                            else if (dadosAcademicos.IndexOf(informacao) == 1)
                            {
                                codigoCurso = informacao;
                            }
                            else
                            {
                                nomeCurso = informacao;
                            }
                        }
                        new Aluno(nome, telefone, cidade, rg, cpf, matricula, codigoCurso, nomeCurso);
                        //Toda vez que registramos um(a) aluno(a), registramos uma pessoa...
                    }
                    else
                    {
                        //Se não era um(a) aluno(a)... Garantimos o registro da pessoa!
                        new Pessoa(nome, telefone, cidade, rg, cpf);
                    }
                }
            }
            Console.WriteLine("Com base no arquivo \"Informações Pessoais.txt\", veja os dados:\n");
            Console.Write($"{Pessoa.VerificarQuantidadePessoas()} pessoas cadastradas com sucesso!\n" +
                $"Além disso, {Aluno.VerificarQuantidadeAlunos()} dessas também são alunos(as)!");
            Pessoa.MostrarPessoas();
            Aluno.MostrarAlunos();
        }
    }
}
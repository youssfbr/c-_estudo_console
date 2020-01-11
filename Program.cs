using System;

namespace estudo_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");      

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)) 
                        {
                            aluno.Nota = nota; 
                        }
                        else 
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal.");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        
                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }                            
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        foreach (var b in alunos) 
                        {
                            if (!string.IsNullOrEmpty(b.Nome)) {                              

                                notaTotal += b.Nota;
                                nrAlunos++;
                            }
                        }

                        if (nrAlunos != 0) 
                        {
                            var media = notaTotal / nrAlunos;
                            Console.WriteLine($"MÉDIA GERAL: {media}");
                        }
                        else
                        {
                            Console.WriteLine("Não há notas de alunos");
                        }                        
                                                
                        break;                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
              
                opcaoUsuario = ObterOpcaoUsuario();
            }            
        }

        private static string ObterOpcaoUsuario() 
            {   
                Console.WriteLine();         
                Console.WriteLine("Informe a opção desejada!");
                Console.WriteLine("1 - Inserir novo aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Calcular média geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                Console.WriteLine();
                return opcaoUsuario;
            }
    }
}

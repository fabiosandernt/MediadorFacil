using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LerArquivosExcel
{
    public class ConvencoesColetivas
    {
        public Guid Id { get; set; }
        public string NumeroRegistro { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroSolicitacao { get; set; }
        public string NomeSindicatoTrabalhador { get; set; }
        public string NomeSindicatoPatronal { get; set; }
        public string TipoInstrumentoColetivo { get; set; }
        public ICollection<Vigencias> Vigencias { get; set; } 
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
    public class Vigencias
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid ConvencaoColetivaId { get; set; } // Adicione essa propriedade
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ConvencaoColetivaId")] // Configure a chave estrangeira
        public ConvencoesColetivas ConvencoesColetivas { get; set; }
    }


    public class DbContexto : DbContext
    {
        public DbSet<ConvencoesColetivas> ConvencoesColetivas { get; set; }
        public DbSet<Vigencias> Vigencias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3JVQO4L\\SQLEXPRESS;Initial Catalog=MediadorFacilApi;Integrated Security=True") // Substitua pelos dados corretos da Connection String
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pastaArquivos = @"C:Teste/Excel"; // Substitua pelo caminho da pasta que contém os arquivos Excel

            string[] arquivos = Directory.GetFiles(pastaArquivos, "*.xlsx"); // Filtra apenas arquivos Excel com extensão .xlsx

            using (var db = new DbContexto())
            {
                foreach (var arquivo in arquivos)
                {
                    LerArquivoExcel(arquivo, db);
                }
            }

            Console.WriteLine("Processamento concluído. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }

        static void LerArquivoExcel(string caminhoArquivo, DbContexto db)
        {
            using (var workbook = new XLWorkbook(caminhoArquivo))
            {
                var worksheet = workbook.Worksheet(1); // Assume que os dados estão na primeira planilha

                int linhaAtual = 2; // Começa a leitura a partir da segunda linha, assumindo que a primeira linha contém os cabeçalhos

                while (!string.IsNullOrEmpty(worksheet.Cell(linhaAtual, 1).GetString()))
                {
                    var convencaoColetiva = new ConvencoesColetivas
                    {
                        Id = Guid.NewGuid(),
                        NumeroRegistro = worksheet.Cell(linhaAtual, 1).GetString(),
                        NumeroProcesso = worksheet.Cell(linhaAtual, 2).GetString(),
                        NumeroSolicitacao = worksheet.Cell(linhaAtual, 3).GetString(),
                        TipoInstrumentoColetivo = worksheet.Cell(linhaAtual, 4).GetString(),
                        NomeSindicatoTrabalhador = worksheet.Cell(linhaAtual, 6).GetString(),
                        NomeSindicatoPatronal = worksheet.Cell(linhaAtual, 7).GetString(),
                        DataInclusao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                    };

                    var vigenciaTexto = worksheet.Cell(linhaAtual, 5).GetString();
                    var datasVigencia = vigenciaTexto.Split('-');
                    var dataInicio = DateTime.Parse(datasVigencia[0].Trim());
                    var dataFim = DateTime.Parse(datasVigencia[1].Trim());

                    var vigencia = new Vigencias
                    {
                        DataInicio = dataInicio,
                        DataFim = dataFim,
                        ConvencaoColetivaId = convencaoColetiva.Id,
                        DataInclusao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                    };

                   
                    Console.WriteLine($"Lendo registro: {convencaoColetiva.NumeroRegistro} - {convencaoColetiva.NomeSindicatoTrabalhador} ");
                    Console.WriteLine(); // Linha em branco
                    Console.WriteLine("Vigência:");
                    Console.WriteLine($"Data de Início: {vigencia.DataInicio.ToShortDateString()}");
                    Console.WriteLine($"Data de Fim: {vigencia.DataFim.ToShortDateString()}");
                    SalvarNoBanco(convencaoColetiva, vigencia, db);

                    linhaAtual++;
                }
            }
        }

        static void SalvarNoBanco(ConvencoesColetivas convencaoColetiva, Vigencias vigencia, DbContexto db)
        {

            db.ConvencoesColetivas.Add(convencaoColetiva);
            db.Vigencias.Add(vigencia);
            db.SaveChanges();
        }
    }
}

using System;

using System.Globalization;
using System.IO;

namespace Files.Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo idiomaptBR = new CultureInfo("pt-BR");

            //windows C:\Users\<YourUserName>
            //string sourcePath = "c:\\Users\\Administrator\\Projects\\Exercicio\\Files\\csv\\Estoque.csv";
            //ou simplesmente usar o @ na frente antes das pastas... daí nao precisa duas barras \\
            //string sourcePath = @"c:\Users\Administrator\Projects\Exercicio\Files\csv\Estoque.csv";

            //mac
            //diretorio padrao '/Users/nxgames/Exercicio/Files/bin/Debug/netcoreapp3.1
            //Console.WriteLine(Directory.GetCurrentDirectory());
 
            //https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/learn/lecture/11443358#overview
            Console.WriteLine("EXERCÍCIO DE FIXAÇÃ0");
            Console.WriteLine("====================");
            Console.WriteLine();

            //Diretorio que coloquei o arquivo
            string pathSeparator  = Path.DirectorySeparatorChar.ToString();

            string path           = "/Users/nxgames/Projects/Exercicio/Files";
            string sourceFile     = "csv" + pathSeparator + "Estoque.csv";

            string sourceFilePath = path + pathSeparator + sourceFile;
            
            Console.Write("Confirme o path: " + sourceFilePath);
            Console.WriteLine();
           
            Console.ReadLine();
          
            
            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);

                //sistema windows
                //string targetFolderPath = sourceFolderPath + @"\out";
                //string targetFilePath = targetFolderPath + @"\summary.csv";

                //macOS
                string targetFolderPath = sourceFolderPath + pathSeparator + "out";
                string targetFilePath = targetFolderPath + pathSeparator + "summario.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);

            }

        }
    }
}

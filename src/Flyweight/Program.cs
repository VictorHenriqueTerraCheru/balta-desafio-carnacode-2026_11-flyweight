using Models;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Flyweight Pattern - Editor de Texto ===\n");

        TestSmallDocument();
        Console.WriteLine("\n" + new string('=', 60) + "\n");

        TestLargeDocument();
        Console.WriteLine("\n" + new string('=', 60) + "\n");

        TestRealisticDocument();
        Console.WriteLine("\n" + new string('=', 60) + "\n");

        ShowBenefits();
    }

    static void TestSmallDocument()
    {
        Console.WriteLine("TESTE 1: Documento Pequeno\n");

        var document = new Document();

        string text = "Hello World";
        for (int i = 0; i < text.Length; i++)
            document.AddCharacter(text[i], "Arial", 12, "Black", false, false, false, 1, i + 1);

        Console.WriteLine("\nRenderizando primeiros 5 caracteres:\n");

        var doc2 = new Document();
        for (int i = 0; i < 5; i++)
            doc2.AddCharacter(text[i], "Arial", 12, "Black", false, false, false, 1, i + 1);
        doc2.Render();

        document.PrintMemoryStats();
    }

    static void TestLargeDocument()
    {
        Console.WriteLine("TESTE 2: Documento Grande (1000 caracteres)\n");

        var document = new Document();

        string text = "Lorem ipsum dolor sit amet consectetur adipiscing elit ";

        for (int line = 1; line <= 20; line++)
            for (int i = 0; i < text.Length; i++)
            {
                document.AddCharacter(
                    text[i],
                    "Arial",
                    12,
                    "Black",
                    false,
                    false,
                    false,
                    line,
                    i + 1
                );
        }

        document.PrintMemoryStats();

        Console.WriteLine("\nSem Flyweight:");
        Console.WriteLine($"   1000 caracteres × 80 bytes = 80,000 bytes (~80 KB)");
        Console.WriteLine("Com Flyweight:");
        Console.WriteLine($"   ~30 estilos × 80 bytes = 2,400 bytes (~2.4 KB)");
        Console.WriteLine($"   1000 posições × 16 bytes = 16,000 bytes (~16 KB)");
        Console.WriteLine($"   TOTAL: ~18.4 KB");
        Console.WriteLine($"   ECONOMIA: ~77% de memória! 🎉");
    }

    static void TestRealisticDocument()
    {
        Console.WriteLine("TESTE 3: Documento Realista (Múltiplas Formatações)\n");

        var document = new Document();

        int col = 1;

        string normal = "Este é um texto normal. ";
        foreach (char c in normal)
            document.AddCharacter(c, "Arial", 12, "Black", false, false, false, 1, col++);

        col = 1;
        string bold = "Este texto está em negrito. ";
        foreach (char c in bold)
            document.AddCharacter(c, "Arial", 12, "Black", true, false, false, 2, col++);

        col = 1;
        string italic = "Este texto está em itálico. ";
        foreach (char c in italic)
            document.AddCharacter(c, "Arial", 12, "Black", false, true, false, 3, col++);

        col = 1;
        string colored = "Este texto é vermelho. ";
        foreach (char c in colored)
            document.AddCharacter(c, "Arial", 12, "Red", false, false, false, 4, col++);

        document.PrintMemoryStats();
    }

    static void ShowBenefits()
    {
        Console.WriteLine("BENEFÍCIOS DO FLYWEIGHT PATTERN\n");

        Console.WriteLine("Redução drástica de uso de memória");
        Console.WriteLine("Melhor performance (menos objetos = menos GC)");
        Console.WriteLine("Compartilhamento transparente de estado");
        Console.WriteLine("Escalável para milhões de objetos similares");
        Console.WriteLine();

        Console.WriteLine("QUANDO USAR:");
        Console.WriteLine("   - Aplicação usa MUITOS objetos similares");
        Console.WriteLine("   - Maior parte do estado pode ser compartilhado");
        Console.WriteLine("   - Identidade de objetos não é importante");
        Console.WriteLine();

        Console.WriteLine("EXEMPLOS REAIS:");
        Console.WriteLine("   - Editores de texto (caracteres)");
        Console.WriteLine("   - Engines de jogos (sprites, partículas)");
        Console.WriteLine("   - Processadores de texto (formatação)");
        Console.WriteLine("   - Sistemas gráficos (fontes, cores)");
    }
}
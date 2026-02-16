using Factory;

namespace Models
{
    public class Document
    {
        private List<CharacterPosition> _characters = new List<CharacterPosition>();
        private CharacterStyleFactory _factory = new CharacterStyleFactory();

        public void AddCharacter(
            char symbol
            , string fontFamily
            , int fontSize
            , string color
            , bool isBold
            , bool isItalic
            , bool isUnderline
            , int row
            , int column)
        {
            var style = _factory.GetStyle(
                symbol
                , fontFamily
                , fontSize
                , color
                , isBold
                , isItalic
                , isUnderline);

            var position = new CharacterPosition(style, row, column);
            _characters.Add(position);
        }

        public void Render()
        {
            foreach (var character in _characters)
                character.Render();
        }

        public void PrintMemoryStats()
        {
            Console.WriteLine($"\n=== Estatísticas Flyweight ===");
            Console.WriteLine($"Total de caracteres: {_characters.Count}");
            Console.WriteLine($"Estilos únicos (flyweights): {_factory.GetPoolSize()}");
            Console.WriteLine($"Taxa de compartilhamento: {(double)_characters.Count / _factory.GetPoolSize():F2}x");
        }
    }
}
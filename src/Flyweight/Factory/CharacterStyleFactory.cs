using Models;

namespace Factory
{
    public class CharacterStyleFactory
    {
        private Dictionary<string, CharacterStyle> _styles = new Dictionary<string, CharacterStyle>();

        public CharacterStyle GetStyle(
            char symbol
            , string fontFamily
            , int fontSize
            , string color
            , bool isBold
            , bool isItalic
            , bool isUnderline)
        {
            string key = $"{symbol}-{fontFamily}-{fontSize}-{color}-{isBold}-{isItalic}-{isUnderline}";

            if (!_styles.ContainsKey(key))
            {
                Console.WriteLine($"[Factory] Criando novo estilo: {key}");
                _styles[key] = new CharacterStyle(symbol, fontFamily, fontSize, color,
                                                 isBold, isItalic, isUnderline);
            }

            return _styles[key];
        }

        public int GetPoolSize() => _styles.Count;
    }
}

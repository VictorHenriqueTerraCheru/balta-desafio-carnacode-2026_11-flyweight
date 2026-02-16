namespace Models
{
    public class CharacterPosition
    {
        public CharacterStyle Style { get; }
        public int Row { get; }
        public int Column { get; }

        public CharacterPosition(CharacterStyle style, int row, int column)
        {
            Style = style;
            Row = row;
            Column = column;
        }
        public void Render() => Style.Render(Row, Column);

    }
}
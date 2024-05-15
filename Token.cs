using static coursework.MainForm;

namespace coursework {
    public class Token {
        public TokenType Type;
        public string Value;
        public Token(string value, TokenType type) {
            Value = value;
            Type = type;
        }
        public override string ToString() {
            return string.Format("<{0} : {1}>", Value, Type);
        }
    }
}

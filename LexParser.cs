namespace coursework {
	public class LexParser {
		List<Token> Tokens = new List<Token>();

		public enum TokenType {
			DIM, AS, AND, OR, NOT, SHORT, INTEGER, LONG, DO, WHILE, LOOP, PLUS, MINUS, MULTIP, DIVISION, EQUAL, LBRACKET, RBRACKET, GRTHANSIGN, LSTHANSIGN, GRTHANEQUALSIGN, LSTHANEQUALSIGN, NEWSTRING, NUMBER, IDENTIFIER, COMMA, EMPTY, NONTERM
		}
		Dictionary<string, TokenType> KeyWords = new Dictionary<string, TokenType>() {
			{ "dim", TokenType.DIM },
			{ "as", TokenType.AS },
			{ "short", TokenType.SHORT },
			{ "integer", TokenType.INTEGER },
			{ "long", TokenType.LONG },
			{ "do", TokenType.DO },
			{ "while", TokenType.WHILE },
			{ "loop", TokenType.LOOP },
			{ "and", TokenType.AND },
			{ "or", TokenType.OR },
		};
		Dictionary<string, TokenType> SpecialSigns = new Dictionary<string, TokenType>() {
			{ "+", TokenType.PLUS },
			{ "-", TokenType.MINUS },
			{ "*", TokenType.MULTIP },
			{ "/", TokenType.DIVISION },
			{ "=", TokenType.EQUAL },
			{ "(", TokenType.LBRACKET },
			{ ")", TokenType.RBRACKET },
			{ "<", TokenType.LSTHANSIGN },
			{ ">", TokenType.GRTHANSIGN },
			{ "<=", TokenType.LSTHANEQUALSIGN },
			{ ">=", TokenType.GRTHANEQUALSIGN },
			{ ",", TokenType.COMMA },
		};

		public List<Token> Start(string CodeText) {
			string Buffer = "";
			char Current;

			try {
				for (int i = 0; i < CodeText.Length; i++) {
					Current = CodeText[i];

					if (Buffer.Length > 8) throw new Exception("Превышено количество символов в литерале или идентификаторе");

					switch (true) {
						case true when Current == ' ':
							CheckBuffer(Buffer);
							Buffer = "";
							break;
						case true when Current == '\r':
							CheckBuffer(Buffer);
							Tokens.Add(new Token(null, TokenType.NEWSTRING));
							i++;
							Buffer = "";
							break;
						case true when IsKeyWord(Buffer + Current):
							string tmp = Buffer + Current;
							if (tmp == "and" || tmp == "or") {
								Tokens.Add(new Token(Buffer + Current, KeyWords[Buffer + Current]));
							} else {
								Tokens.Add(new Token(null, KeyWords[Buffer + Current]));
							}
							Buffer = "";
							break;
						case true when IsSpecialSign(Current.ToString()):
							CheckBuffer(Buffer);
							Tokens.Add(new Token(Current.ToString(), SpecialSigns[Current.ToString()]));
							Buffer = "";
							if (Tokens[Tokens.Count - 1].Type == TokenType.EQUAL) {
								if (Tokens[Tokens.Count - 2].Type == TokenType.GRTHANSIGN) {
									Tokens.RemoveRange(Tokens.Count - 2, 2);
									Tokens.Add(new Token(">=", TokenType.GRTHANEQUALSIGN));
								}
								if (Tokens[Tokens.Count - 2].Type == TokenType.LSTHANSIGN) {
									Tokens.RemoveRange(Tokens.Count - 2, 2);
									Tokens.Add(new Token("<=", TokenType.LSTHANEQUALSIGN));
								}
							}
							break;
						default:
							if (Char.IsLetter(Current) || Char.IsDigit(Current)) Buffer += Current;
							else throw new Exception("Обнаружен недопустимый символ");
							break;
					}
				}
				if (Tokens[Tokens.Count - 1].Type != TokenType.NEWSTRING) Tokens.Add(new Token(null, TokenType.NEWSTRING));

				return Tokens;
			}
			catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		void CheckBuffer(string Buffer) {
			if (Buffer != "") {
				if (IsNumeric(Buffer)) Tokens.Add(new Token(Buffer, TokenType.NUMBER));
				else Tokens.Add(new Token(Buffer, TokenType.IDENTIFIER));
			}
		}

		bool IsKeyWord(string word) {
			if (string.IsNullOrEmpty(word)) {
				return false;
			}
			return KeyWords.ContainsKey(word);
		}

		bool IsSpecialSign(string str) {
			return SpecialSigns.ContainsKey(str);
		}

		bool IsNumeric(object Expression) {
			double retNum;
			bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
			return isNum;
		}
	}
}

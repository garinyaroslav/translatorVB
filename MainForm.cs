using static coursework.Utils;

namespace coursework {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		static public List<Token> Tokens = new List<Token>();

		public enum TokenType {
			DIM, AS, AND, OR, NOT, SHORT, INTEGER, LONG, DO, WHILE, LOOP, PLUS, MINUS, MULTIP, DIVISION, EQUAL, LBRACKET, RBRACKET, GRTHANSIGN, LSTHANSIGN, GRTHANEQUALSIGN, LSTHANEQUALSIGN, NEWSTRING, NUMBER, IDENTIFIER, COMMA, EMPTY, NONTERM
		}
		static public Dictionary<string, TokenType> KeyWords = new Dictionary<string, TokenType>() {
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
		static public Dictionary<string, TokenType> SpecialSigns = new Dictionary<string, TokenType>() {
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
		private void ResBut_Click(object sender, EventArgs e) {
			CodeBox.Text = "Dim a as integer\r\nb=1\r\ndo while (a < 10 and a > 5)\r\n b = b + a\r\nloop";
			ResultBox.Clear();
			ExprBox.Clear();
			Tokens.Clear();
		}
		private void RunBut_Click(object sender, EventArgs e) {
			ResultBox.Clear();
			ExprBox.Clear();
			Tokens.Clear();
			if (CodeBox.Text == "") return;

			string CodeText = CodeBox.Text.ToLower();

			string Buffer = "";
			char Current;

			try {
				for (int i = 0; i < CodeText.Length; i++) {
					Current = CodeText[i];

					if (Buffer.Length > 8) throw new Exception("Превышено колличество символов в переменной");

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
							Tokens.Add(new Token(null, KeyWords[Buffer + Current]));
							Buffer = "";
							break;
						case true when IsSpecialSign(Current.ToString()):
							CheckBuffer(Buffer);
							Tokens.Add(new Token(null, SpecialSigns[Current.ToString()]));
							Buffer = "";
							if (Tokens[Tokens.Count - 1].Type == TokenType.EQUAL) {
								if (Tokens[Tokens.Count - 2].Type == TokenType.GRTHANSIGN) {
									Tokens.RemoveRange(Tokens.Count - 2, 2);
									Tokens.Add(new Token(null, TokenType.GRTHANEQUALSIGN));
								}
								if (Tokens[Tokens.Count - 2].Type == TokenType.LSTHANSIGN) {
									Tokens.RemoveRange(Tokens.Count - 2, 2);
									Tokens.Add(new Token(null, TokenType.LSTHANEQUALSIGN));
								}
							}
							break;
						default:
							if (Char.IsLetter(Current) || Char.IsDigit(Current)) Buffer += Current;
							else throw new Exception("Обнаружен недопустимый символ");
							break;
					}
					/*if (i == CodeText.Length - 1) Tokens.Add(new Token(null, KeyWords[Buffer]));*/
				}
				if (Tokens[Tokens.Count - 1].Type != TokenType.NEWSTRING) Tokens.Add(new Token(null, TokenType.NEWSTRING));

				for (int i = 0; i < Tokens.Count; i++) {
					ResultBox.Text += $"{Tokens[i]}\r\n";
				}

				TopDownResolver parserDown = new TopDownResolver(Tokens);
				ExprBox.Text += parserDown.Start();

				/*DownTopResolver parserTop = new DownTopResolver(Tokens);
				parserTop.Start();*/
			}
			catch (Exception ex) {
				MessageBox.Show($"Произошла ошибка: {ex.Message}");
			}
		}

	}
}

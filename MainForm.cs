
namespace coursework {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		List<Token> Tokens = new List<Token>();

		private void ResBut_Click(object sender, EventArgs e) {
			CrearAll();
			CodeBox.Text = "Dim a as integer\r\nb=1\r\ndo while (a < 10 and a > 5)\r\n b = b + a\r\nloop";
		}
		private void RunBut_Click(object sender, EventArgs e) {
			CrearAll();
			if (CodeBox.Text == "") return;

			try {
				LexParser lexer = new LexParser();
				Tokens = lexer.Start(CodeBox.Text.ToLower());

				for (int i = 0; i < Tokens.Count; i++) {
					ResultBox.Text += $"{Tokens[i]}\r\n";
				}

				TopDownResolver parser = new TopDownResolver(Tokens);
				ExprBox.Text += parser.Start();

				ResultBox.Text = $"Разбор прошёл успешно \r\n\r\n{ResultBox.Text}";
			} catch (Exception ex) {
				ResultBox.Text = ex.Message;
			}
		}
		void CrearAll() {
			ResultBox.Clear();
			ExprBox.Clear();
			Tokens.Clear();
		}
	}
}

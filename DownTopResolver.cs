using static coursework.MainForm;

namespace coursework {
	public class DownTopResolver {
		List<Token> Tokens;
		int state = 0;
		int NextLex = 0;
		Stack<int> StateStack = new Stack<int>();
		Stack<Token> LexStack = new Stack<Token>();
		public DownTopResolver(List<Token> tokens) {
			Tokens = tokens;
			StateStack.Push(0);
			Tokens.Add(new Token(null, TokenType.EMPTY));
		}

		public void Start() {
			while (NextLex != Tokens.Count) {
				try {
					switch (state) {
					case 0:
						State0();
						break;
					case 1:
						State1();
						break;
					case 2:
						State2();
						break;
					case 3:
						State3();
						break;
					case 4:
						State4();
						break;
					case 5:
						State5();
						break;
					case 6:
						State6();
						break;
					case 7:
						State7();
						break;
					case 8:
						State8();
						break;
					case 9:
						State9();
						break;
					case 10:
						State10();
						break;
					case 11:
						State11();
						break;
					case 12:
						State12();
						break;
					case 13:
						State13();
						break;
					case 14:
						State14();
						break;
					case 15:
						State15();
						break;
					case 16:
						State16();
						break;
					case 17:
						State17();
						break;
					case 18:
						State18();
						break;
					case 19:
						State19();
						break;
					case 20:
						State20();
						break;
					case 21:
						State21();
						break;
					case 22:
						State22();
						break;
					case 23:
						State23();
						break;
					case 24:
						State24();
						break;
					case 25:
						State25();
						break;
					case 26:
						State26();
						break;
					case 27:
						State27();
						break;
					case 28:
						State28();
						break;
					case 29:
						State29();
						break;
					case 30:
						State30();
						break;
					case 31:
						State31();
						break;
					case 32:
						State32();
						break;
					case 33:
						State33();
						break;
					case 34:
						State34();
						break;
					case 35:
						State35();
						break;
					case 36:
						State36();
						break;
					case 37:
						State37();
						break;
					case 38:
						State38();
						break;
					default:
						return;
					}
				}
				catch (TokenException e) {
					MessageBox.Show($"{e.Message}: {e.StackTrace}", "Syntax Error");
					break;
				}
			}
		}

		public void GoToState(int s) {
			StateStack.Push(s);
			state = s;
		}
		public void Shift() {
			LexStack.Push(Tokens[NextLex]);
			NextLex++;
		}
		public void Reduce(int n, string NonTerm) {
			for (int i = 0; i < n; i++) {
				LexStack.Pop();
				StateStack.Pop();
			}
			LexStack.Push(new Token(NonTerm, TokenType.NONTERM));
			state = StateStack.Peek();
		}

		void State0() {
			if (LexStack.Count == 0) Shift();
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "program") state = -1;
					if (LexStack.Peek().Value == "init_list") GoToState(1);
					if (LexStack.Peek().Value == "init") GoToState(2);
					break;
				case TokenType.DIM:
					GoToState(3);
					break;
				default:
					throw new TokenException($"Ожидалось DIM, а не {LexStack.Peek()}");
			}
		}
		void State1() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "init_list") Shift();
					if (LexStack.Peek().Value == "operator_list") GoToState(4);
					if (LexStack.Peek().Value == "init") GoToState(5);
					if (LexStack.Peek().Value == "operator") GoToState(6);
					if (LexStack.Peek().Value == "cycle") GoToState(8);
					break;
				case TokenType.DIM:
					GoToState(3);
					break;
				case TokenType.IDENTIFIER:
					GoToState(7);
					break;
				case TokenType.DO:
					GoToState(9);
					break;
				default:
					throw new TokenException($"Ожидалось <init_list>, <operator_list>, <init>, <operator>, <cycle>, DIM, ID, DO, а не {LexStack.Peek()}");
			}
		}
		void State2() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "init") Reduce(1, "init_list");
					break;
				default:
					throw new TokenException($"Ожидалось <init>, а не {LexStack.Peek()}");
			}
		}
		void State3() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "id_list") GoToState(10);
					break;
				case TokenType.DIM:
					Shift();
					break;
				case TokenType.IDENTIFIER:
					GoToState(11);
					break;
				default:
					throw new TokenException($"Ожидалось <id_list>, DIM, ID, а не {LexStack.Peek()}");
			}
		}
		void State4() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					/*MessageBox.Show(state.ToString());*/
					if (LexStack.Peek().Value == "operator_list") {
						switch (Tokens[NextLex].Type) {
							case TokenType.IDENTIFIER:
							case TokenType.DO:
								Shift();
								break;
							case TokenType.EMPTY:
								Reduce(2, "program");
								break;
						}
					};
					if (LexStack.Peek().Value == "operator") GoToState(12);
					if (LexStack.Peek().Value == "cycle") GoToState(8);
					break;
				case TokenType.DO:
					GoToState(9);
					break;
				case TokenType.IDENTIFIER:
					GoToState(7);
					break;
				default:	
					throw new TokenException($"Ожидалось <operator_list>, <operator>, <cycle>, ID, DO, а не {LexStack.Peek()}");
			}
		}
		void State5() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "init") Reduce(2, "init_list");
					break;
				default:
					throw new TokenException($"Ожидалось <init_list>, а не {LexStack.Peek()}");
			}
		}
		void State6() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operator") Reduce(1, "operator_list");
					break;
				default:
					throw new TokenException($"Ожидалось <operator_list>, а не {LexStack.Peek()}");
			}
		}
		void State7() {
			switch (LexStack.Peek().Type) {
				case TokenType.IDENTIFIER:
					Shift();
					break;
				case TokenType.EQUAL:
					GoToState(13);
					break;
				default:
					throw new TokenException($"Ожидалось ID, =, а не {LexStack.Peek()}");
			}
		}
		void State8() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "cycle") Reduce(1, "operator");
					break;
				default:
					throw new TokenException($"Ожидалось <CYCLE>, а не {LexStack.Peek()}");
			}
		}
		void State9() {
			switch (LexStack.Peek().Type) {
				case TokenType.DO:
					Shift();
					break;
				case TokenType.WHILE:
					GoToState(14);
					break;
				default:
					throw new TokenException($"Ожидалось DO, WHILE, а не {LexStack.Peek()}");
			}
		}
		void State10() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "id_list") Shift();
					break;
				case TokenType.AS:
					GoToState(15);
					break;
				case TokenType.COMMA:
					GoToState(16);
					break;
				default:
					throw new TokenException($"Ожидалось <id_list>, AS, COMMA, а не {LexStack.Peek()}");
			}
		}
		void State11() {
			switch (LexStack.Peek().Type) {
				case TokenType.IDENTIFIER:
					Reduce(1, "id_list");
					break;
				default:
					throw new TokenException($"Ожидалось ID, а не {LexStack.Peek()}");
			}
		}
		void State12() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operator") Reduce(2, "operator_list");
					break;
				default:
					throw new TokenException($"Ожидалось <operator>, а не {LexStack.Peek()}");
			}
		}
		void State13() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operand") GoToState(17);
					break;
				case TokenType.IDENTIFIER:
					GoToState(18);
					break;
				case TokenType.NUMBER:
					GoToState(19);
					break;
				case TokenType.EQUAL:
					Shift();
					break;
				default:
					throw new TokenException($"Ожидалось <operand>, LIT, EQUAL, ID, а не {LexStack.Peek()}");
			}
		}
		void State14() {
			switch (LexStack.Peek().Type) {
				case TokenType.WHILE:
					Shift();
					break;
				case TokenType.LBRACKET:
					NextLex++;
					NextLex++;
					NextLex++;
					NextLex++;
					NextLex++;
					NextLex++;
					NextLex++;
					NextLex++;
					GoToState(20);
					break;
				default:
					throw new TokenException($"Ожидалось WHILE, EXPR, а не {LexStack.Peek()}");
			}
		}
		void State15() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "type") GoToState(21);
					break;
				case TokenType.AS:
					Shift();
					break;
				case TokenType.INTEGER:
					GoToState(22);
					break;
				case TokenType.SHORT:
					GoToState(23);
					break;
				case TokenType.LONG:
					GoToState(24);
					break;
				default:
					throw new TokenException($"Ожидалось <type>, AS, INTEGER, SHORT, LONG, а не {LexStack.Peek()}");
			}
		}
		void State16() {
			switch (LexStack.Peek().Type) {
				case TokenType.COMMA:
					Shift();
					break;case TokenType.IDENTIFIER:
					GoToState(25);
					break;
				default:
					throw new TokenException($"Ожидалось COMMA, ID, а не {LexStack.Peek()}");
			}
		}
		void State17() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operand") Shift();
					if (LexStack.Peek().Value == "sign") GoToState(26);
					break;
				case TokenType.NEWSTRING:
					GoToState(27);
					break;
				case TokenType.PLUS:
					GoToState(28);
					break;
				case TokenType.MINUS:
					GoToState(29);
					break;
				case TokenType.MULTIP:
					GoToState(30);
					break;
				case TokenType.DIVISION:
					GoToState(31);
					break;
				default:
					throw new TokenException($"Ожидалось <operand>, <sign>, NEWSTRING, PLUS, MINUS, MULTIP, DIVISION, а не {LexStack.Peek()}");
			}
		}
		void State18() {
			switch (LexStack.Peek().Type) {
				case TokenType.IDENTIFIER:
					Reduce(1, "operand");
					break;
				default:
					throw new TokenException($"Ожидалось ID, а не {LexStack.Peek()}");
			}
		}
		void State19() {
			switch (LexStack.Peek().Type) {
				case TokenType.NUMBER:
					Reduce(1, "operand");
					break;
				default:
					throw new TokenException($"Ожидалось LIT, а не {LexStack.Peek()}");
			}
		}
		void State20() {
			switch (LexStack.Peek().Type) {
				case TokenType.NEWSTRING:
					GoToState(32);
					break;
				case TokenType.LBRACKET:
					Shift();
					break;
				default:
					throw new TokenException($"Ожидалось EXPR, NEWSTRING, а не {LexStack.Peek()}");
			}
		}
		void State21() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "type") Shift();
					break;
				case TokenType.NEWSTRING:
					GoToState(33);
					break;
				default:
					throw new TokenException($"Ожидалось <type>, NEWSTRING, а не {LexStack.Peek()}");
			}
		}
		void State22() {
			switch (LexStack.Peek().Type) {
				case TokenType.INTEGER:
					Reduce(1, "type");
					break;
				default:
					throw new TokenException($"Ожидалось INTEGER, а не {LexStack.Peek()}");
			}
		}
		void State23() {
			switch (LexStack.Peek().Type) {
				case TokenType.SHORT:
					Reduce(1, "type");
					break;
				default:
					throw new TokenException($"Ожидалось SHORT, а не {LexStack.Peek()}");
			}
		}
		void State24() {
			switch (LexStack.Peek().Type) {
				case TokenType.LONG:
					Reduce(1, "type");
					break;
				default:
					throw new TokenException($"Ожидалось LONG, а не {LexStack.Peek()}");
			}
		}
		void State25() {
			switch (LexStack.Peek().Type) {
				case TokenType.IDENTIFIER:
					Reduce(3, "id_list");
					break;
				default:
					throw new TokenException($"Ожидалось ID, а не {LexStack.Peek()}");
			}
		}
		void State26() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operand") GoToState(34);
					if (LexStack.Peek().Value == "sign") Shift();
					break;
				case TokenType.IDENTIFIER:
					GoToState(18);
					break;
				case TokenType.NUMBER:
					GoToState(19);
					break;
				default:
					throw new TokenException($"Ожидалось <operand>, <sign>, ID, LIT а не {LexStack.Peek()}");
			}
		}
		void State27() {
			switch (LexStack.Peek().Type) {
				case TokenType.NEWSTRING:
					Reduce(4, "operator");
					break;
				default:
					throw new TokenException($"Ожидалось NEWSTRING а не {LexStack.Peek()}");
			}
		}
		void State28() {
			switch (LexStack.Peek().Type) {
				case TokenType.PLUS:
					Reduce(1, "sign");
					break;
				default:
					throw new TokenException($"Ожидалось PLUS а не {LexStack.Peek()}");
			}
		}
		void State29() {
			switch (LexStack.Peek().Type) {
				case TokenType.MINUS:
					Reduce(1, "sign");
					break;
				default:
					throw new TokenException($"Ожидалось MINUS а не {LexStack.Peek()}");
			}
		}
		void State30() {
			switch (LexStack.Peek().Type) {
				case TokenType.MULTIP:
					Reduce(1, "sign");
					break;
				default:
					throw new TokenException($"Ожидалось MULTIP а не {LexStack.Peek()}");
			}
		}
		void State31() {
			switch (LexStack.Peek().Type) {
				case TokenType.DIVISION:
					Reduce(1, "sign");
					break;
				default:
					throw new TokenException($"Ожидалось DIVISION а не {LexStack.Peek()}");
			}
		}
		void State32() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operator_list") GoToState(35);
					if (LexStack.Peek().Value == "operator") GoToState(6);
					if (LexStack.Peek().Value == "cycle") GoToState(8);
					break;
				case TokenType.NEWSTRING:
					Shift();
					break;
				case TokenType.IDENTIFIER:
					GoToState(7);
					break;
				case TokenType.DO:
					GoToState(9);
					break;
				default:
					throw new TokenException($"Ожидалось <operator_list>, <operator>, <cycle>, NEWSTRING, ID, DO, а не {LexStack.Peek()}");
			}
		}
		void State33() {
			switch (LexStack.Peek().Type) {
				case TokenType.NEWSTRING:
					Reduce(5, "init");
					break;
				default:
					throw new TokenException($"Ожидалось NEWSTRING, а не {LexStack.Peek()}");
			}
		}
		void State34() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operand") Shift();
					break;
				case TokenType.NEWSTRING:
					GoToState(36);
					break;
				default:
					throw new TokenException($"Ожидалось <operand>, NEWSTRING, а не {LexStack.Peek()}");
			}
		}
		void State35() {
			switch (LexStack.Peek().Type) {
				case TokenType.NONTERM:
					if (LexStack.Peek().Value == "operator_list") Shift();
					if (LexStack.Peek().Value == "operator") GoToState(12);
					if (LexStack.Peek().Value == "cycle") GoToState(8);
					break;
				case TokenType.LOOP:
					GoToState(37);
					break;
				case TokenType.IDENTIFIER:
					GoToState(7);
					break;
				case TokenType.DO:
					GoToState(9);
					break;
				default:
					throw new TokenException($"Ожидалось <operator_list>, <operator>, <cycle>, LOOP, ID, DO, а не {LexStack.Peek()}");
			}
		}
		void State36() {
			switch (LexStack.Peek().Type) {
				case TokenType.NEWSTRING:
					Reduce(6, "operator");
					break;
				default:
					throw new TokenException($"Ожидалось <operator>, а не {LexStack.Peek()}");
			}
		}
		void State37() {
			switch (LexStack.Peek().Type) {
				case TokenType.LOOP:
					Shift();
					break;
				case TokenType.NEWSTRING:
					GoToState(38);
					break;
				default:
					throw new TokenException($"Ожидалось LOOP, NEWSTRING, а не {LexStack.Peek()}");
			}
		}
		void State38() {
			switch (LexStack.Peek().Type) {
				case TokenType.NEWSTRING:
					Reduce(7, "cycle");
					break;
				default:
					throw new TokenException($"Ожидалось NEWSTRING, а не {LexStack.Peek()}");
			}
		}
	}
}

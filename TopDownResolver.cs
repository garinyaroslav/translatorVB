using static coursework.MainForm;

namespace coursework {
	public class TopDownResolver {
		List<Token> Tokens;
		string ExprStr = "";
		
		public TopDownResolver(List<Token> tokens) {
			Tokens = tokens;
			Tokens.Add(new Token(null, TokenType.EMPTY));
		}

		public string Start() {
			int i = 0;
			Token CurrTok = Tokens[i];

			Stack<Token> EN = new Stack<Token>();
			Stack<Token> TR = new Stack<Token>();

			Program();

			void Next() {
				i++;
				CurrTok = Tokens[i];
			}

			void Program() {
				try {
					InitList();
					OperatorList();
				}
				catch (TokenException e) {
					MessageBox.Show($"{e.Message}: {e.StackTrace}", "Syntax Error");
				}
			}
			return ExprStr;

			void InitList() {
				Init();
				X();
			}
			void U() {
				Init();
				X();
			}
			void X() {
				switch (CurrTok.Type) {
					case TokenType.IDENTIFIER:
					case TokenType.DO:
						break;
					case TokenType.DIM:
						U();
						break;
					default:
						throw new TokenException($"Ожидалось NEWSTRING или DIM, а не {CurrTok}");
				}
			}
			void Init() {
				if (CurrTok.Type != TokenType.DIM) throw new TokenException($"Ожидалось DIM, а не {CurrTok}");
				Next();
				IdList();
				if (CurrTok.Type != TokenType.AS) throw new TokenException($"Ожидалось AS, а не {CurrTok}");
				Next();
				Type();
				if (CurrTok.Type != TokenType.NEWSTRING) throw new TokenException($"Ожидалось NEWSTRING, а не {CurrTok}");
				Next();
			}
			void IdList() {
				if (CurrTok.Type != TokenType.IDENTIFIER) throw new TokenException($"Ожидалось ID, а не {CurrTok}");
				Next();
				Z();
			}
			void Y() {
				if (CurrTok.Type != TokenType.COMMA) throw new TokenException($"Ожидалось ',', а не {CurrTok}");
				Next();
				if (CurrTok.Type != TokenType.IDENTIFIER) throw new TokenException($"Ожидалось ID, а не {CurrTok}");
				Next();
				Z();
			}
			void Z() {
				switch (CurrTok.Type) {
				case TokenType.AS:
						break;
					case TokenType.COMMA:
						Y();
						break;
					default:
						throw new TokenException($"Ожидалось ',' или AS, а не {CurrTok}");
				}
			}
			void Type() {
				if (CurrTok.Type != TokenType.INTEGER && CurrTok.Type != TokenType.SHORT && CurrTok.Type != TokenType.LONG) {
					throw new TokenException($"Ожидалось INTEGER или SHORT или LONG, а не {CurrTok}");
				}
				Next();
			}
			void OperatorList() {
				Operator();
				D();
			}
			void T() {
				Operator();
				D();
			}
			void D() {
				switch (CurrTok.Type) {
					case TokenType.LOOP:
					case TokenType.EMPTY:
						break;
					case TokenType.IDENTIFIER:
					case TokenType.DO:
						T();
						break;
					default:
						throw new TokenException($"Ожидалось LOOP или ID или DO или EMPTY, а не {CurrTok}");
				}
			}
			void Operator() {
				switch (CurrTok.Type) {
					case TokenType.IDENTIFIER:
						if (CurrTok.Type != TokenType.IDENTIFIER) throw new TokenException($"Ожидалось ID, а не {CurrTok}");
						Next();
						if (CurrTok.Type != TokenType.EQUAL) throw new TokenException($"Ожидалось EQUAL, а не {CurrTok}");
						Next();
						Operand();
						G();
						break;
					case TokenType.DO:
						Cycle();
						break;
					default:
						throw new TokenException($"Ожидалось ID или DO, а не {CurrTok}");
				}
			}
			void G() {
				switch (CurrTok.Type) {
					case TokenType.PLUS:
					case TokenType.MINUS:
					case TokenType.MULTIP:
					case TokenType.DIVISION:
						Sign();
						Operand();
						if (CurrTok.Type != TokenType.NEWSTRING) throw new TokenException($"Ожидалось NEWSTRING, а не {CurrTok}");
						Next();
						break;
					case TokenType.NEWSTRING:
						if (CurrTok.Type != TokenType.NEWSTRING) throw new TokenException($"Ожидалось NEWSTRING, а не {CurrTok}");
						Next();
						break;
					default:
						throw new TokenException($"Ожидалось +, -, *, / или NEWSTRING а не {CurrTok}");
				}
			}
			void Operand() {
				if (CurrTok.Type != TokenType.IDENTIFIER && CurrTok.Type != TokenType.NUMBER) {
					throw new TokenException($"Ожидалось ID или LIT, а не {CurrTok}");
				}
				Next();
			}
			void Sign() {
				if (CurrTok.Type == TokenType.PLUS &&
					CurrTok.Type == TokenType.MINUS &&
					CurrTok.Type == TokenType.MULTIP &&
					CurrTok.Type == TokenType.DIVISION) {
					throw new TokenException($"Ожидалось +, -, *, /, а не {CurrTok}");
				}
				Next();
			}
			void Cycle() {
				if (CurrTok.Type != TokenType.DO) throw new TokenException($"Ожидалось DO, а не {CurrTok}");
				Next();
				if (CurrTok.Type != TokenType.WHILE) throw new TokenException($"Ожидалось WHILE, а не {CurrTok}");
				Next();
				Expr();
				if (CurrTok.Type != TokenType.NEWSTRING) throw new TokenException($"Ожидалось NEWSTRING, а не {CurrTok}");
				Next();
				OperatorList();
				if (CurrTok.Type != TokenType.LOOP) throw new TokenException($"Ожидалось LOOP, а не {CurrTok}");
				Next();
				if (CurrTok.Type != TokenType.NEWSTRING) throw new TokenException($"Ожидалось NEWSTRING, а не {CurrTok}");
				Next();
			}
			void Expr() {
				while (true) {
					switch (CurrTok.Type) {
						case TokenType.IDENTIFIER:
						case TokenType.NUMBER:
							KID(CurrTok);
							break;
						case TokenType.NEWSTRING:
						case TokenType.LBRACKET:
						case TokenType.RBRACKET:
						case TokenType.LSTHANEQUALSIGN:
						case TokenType.GRTHANEQUALSIGN:
						case TokenType.GRTHANSIGN:
						case TokenType.LSTHANSIGN:
						case TokenType.OR:
						case TokenType.AND:
							if (TR.Count == 0) {
								switch (CurrTok.Type) {
									case TokenType.NEWSTRING:
										D6();
										return;
									case TokenType.LBRACKET:
									case TokenType.LSTHANEQUALSIGN:
									case TokenType.GRTHANEQUALSIGN:
									case TokenType.GRTHANSIGN:
									case TokenType.LSTHANSIGN:
									case TokenType.OR:
									case TokenType.AND:
										D1();
										break;
									case TokenType.RBRACKET:
										D5();
										break;
								}
							}
							switch (TR.Peek().Type) {
								case TokenType.LBRACKET:
									switch (CurrTok.Type) {
										case TokenType.NEWSTRING:
											D5();
											break;
										case TokenType.LBRACKET:
										case TokenType.LSTHANEQUALSIGN:
										case TokenType.GRTHANEQUALSIGN:
										case TokenType.GRTHANSIGN:
										case TokenType.LSTHANSIGN:
										case TokenType.OR:
										case TokenType.AND:
											D1();
											break;
										case TokenType.RBRACKET:
											D3();
											break;
									}
									break;
								case TokenType.LSTHANEQUALSIGN:
								case TokenType.GRTHANEQUALSIGN:
								case TokenType.GRTHANSIGN:
								case TokenType.LSTHANSIGN:
									switch (CurrTok.Type) {
										case TokenType.NEWSTRING:
											D4();
											break;
										case TokenType.LBRACKET:
											D1();
											break;
										case TokenType.LSTHANEQUALSIGN:
										case TokenType.GRTHANEQUALSIGN:
										case TokenType.GRTHANSIGN:
										case TokenType.LSTHANSIGN:
											D2();
											break;
										case TokenType.OR:
										case TokenType.AND:
											D1();
											break;
										case TokenType.RBRACKET:
											D4();
											break;
									}
									break;
								case TokenType.OR:
									switch (CurrTok.Type) {
										case TokenType.NEWSTRING:
											D4();
											break;
										case TokenType.LBRACKET:
											D1();
											break;
										case TokenType.LSTHANEQUALSIGN:
										case TokenType.GRTHANEQUALSIGN:
										case TokenType.GRTHANSIGN:
										case TokenType.LSTHANSIGN:
											D4();
											break;
										case TokenType.OR:
											D2();
											break;
										case TokenType.AND:
											D1();
											break;
										case TokenType.RBRACKET:
											D4();
											break;
									}
									break;
								case TokenType.AND:
									switch (CurrTok.Type) {
										case TokenType.NEWSTRING:
											D4();
											break;
										case TokenType.LBRACKET:
											D1();
											break;
										case TokenType.LSTHANEQUALSIGN:
										case TokenType.GRTHANEQUALSIGN:
										case TokenType.GRTHANSIGN:
										case TokenType.LSTHANSIGN:
											D4();
											break;
										case TokenType.OR:
											D4();
											break;
										case TokenType.AND:
											D2();
											break;
										case TokenType.RBRACKET:
											D4();
											break;
									}
									break;
							}
							break;
						default:
							throw new TokenException($"Ошибка в выражении, конец разбора");
					}
				}

				void KID (Token T) {
					EN.Push(T);
					Next();
				}
				void KOP (Token OP) {
					Token op1 = EN.Pop();
					Token op2 = EN.Pop();

					ExprStr += $"{op1} - {OP} - {op2}\r\n";
					EN.Push(op2);
				}

				void D1 () {
					TR.Push(CurrTok);
					Next();
				}
				void D2 () {
					KOP(TR.Pop());
					TR.Push(CurrTok);
					Next();
				}
				void D3 () {
					TR.Pop();
					Next();
				}
				void D4 () {
					KOP(TR.Pop());
				}
				void D5 () {
					throw new TokenException($"Ошибка в выражении, конец разбора");
				}
				void D6 () {
					return;
				}
			}
		}
	}
	public class TokenException : Exception {
		public TokenException(string message) : base(message) {}
	}
}

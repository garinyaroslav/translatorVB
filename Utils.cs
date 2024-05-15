using static coursework.MainForm;

namespace coursework {
  static public class Utils {
    static public void CheckBuffer(string Buffer) {
      if (Buffer != "") {
        if (IsNumeric(Buffer)) Tokens.Add(new Token(Buffer, TokenType.NUMBER));
        else Tokens.Add(new Token(Buffer, TokenType.IDENTIFIER));
      }
    }

    static public bool IsKeyWord(string word) {
      if (string.IsNullOrEmpty(word)) {
        return false;
      }
      return KeyWords.ContainsKey(word);
    }

    static public bool IsSpecialSign(string str) {
      return SpecialSigns.ContainsKey(str);
    }

    static public bool IsNumeric(object Expression) {
      double retNum;
      bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
      return isNum;
    }
  }
}
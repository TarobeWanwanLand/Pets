using System;
using System.Text;

namespace Pets.Editor.CodeBuilders
{
    public class CodeBuilder
    {
        private readonly StringBuilder _stringBuilder = new();
        private int _currentIndent;
        
        public void Append(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (code.Contains('\0')) throw new ArgumentException("空文字は追加できません", nameof(code));
            if (code.Contains('\n')) throw new ArgumentException("改行文字は追加できません", nameof(code));
            
            _stringBuilder.Append(code);
        }
        
        public void Append(char code)
        {
            if (code == '\0') throw new ArgumentException("空文字は追加できません", nameof(code));
            if (code == '\n') throw new ArgumentException("改行文字は追加できません", nameof(code));
                
            _stringBuilder.Append(code);
        }

        public void NewLine()
        {
            _stringBuilder.Append('\n');
            
            for (var i = 0; i < _currentIndent; i++)
            {
                _stringBuilder.Append('\t');
            }
        }

        internal void Indent()
        {
            _currentIndent++;
            _stringBuilder.Append('\t');
        }
        
        internal void Unindent()
        {
            if (_currentIndent == 0) throw new InvalidOperationException("インデントのレベルが0未満になりました");
            _currentIndent--;
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}

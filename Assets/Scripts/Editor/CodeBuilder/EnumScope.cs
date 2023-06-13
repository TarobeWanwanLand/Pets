using System;

namespace Pets.Editor.CodeBuilders
{
    public static partial class CodeBuilderExtensions
    {
        public static EnumScope CreateEnumScope(this CodeBuilder self, AccessModifier modifiers, string name)
        {
            return new(self, modifiers, name);
        }

        public class EnumScope : IDisposable
        {
            private readonly CodeBuilder _codeBuilder;
            private readonly Scope _scope;
            
            private bool _isFirstField = true;
            
            internal EnumScope(CodeBuilder codeBuilder, AccessModifier accessModifier, string name)
            {
                _codeBuilder = codeBuilder;
                
                _codeBuilder.Append(accessModifier.ToAccessString());
                _codeBuilder.Append("enum ");
                _codeBuilder.Append(name);
                
                _scope = _codeBuilder.CreateScope();
            }

            public void AppendField(string name, int value = int.MaxValue)
            {
                if (!_isFirstField)
                {
                    _codeBuilder.Append(',');
                    _codeBuilder.NewLine();   
                }
                _isFirstField = false;
                
                _codeBuilder.Append(name);
                
                if(value != int.MaxValue)
                {
                    _codeBuilder.Append(" = ");
                    _codeBuilder.Append(value.ToString());
                }
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}
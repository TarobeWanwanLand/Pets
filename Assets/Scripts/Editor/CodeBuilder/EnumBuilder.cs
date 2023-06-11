using System;
using System.Collections.Generic;

namespace Pets.Editor.CodeBuilders
{
    public static partial class CodeBuilderExtensions
    {
        public static EnumBuilder CreateEnumBuilder(this CodeBuilder self, AccessModifier accessModifier, string name)
        {
            return new(self, accessModifier, name);
        }

        public class EnumBuilder : IDisposable
        {
            private readonly CodeBuilder _codeBuilder;
            private readonly Scope _scope;
            
            internal EnumBuilder(CodeBuilder codeBuilder, AccessModifier accessModifier, string name)
            {
                _codeBuilder = codeBuilder;
                
                _codeBuilder.Append(accessModifier.ToString());
                _codeBuilder.Append("enum ");
                _codeBuilder.Append(name);
                
                _scope = _codeBuilder.CreateScope();
            }

            public void AppendField(string name, int value = int.MaxValue)
            {
                _codeBuilder.NewLine();
                _codeBuilder.Append(name);
                
                if(value != int.MaxValue)
                {
                    _codeBuilder.Append(" = ");
                    _codeBuilder.Append(value.ToString());
                }
                
                _codeBuilder.Append(',');
            }

            public void Dispose()
            {
                _codeBuilder.BackSpace();
                
                _scope.Dispose();
            }
        }
    }
}
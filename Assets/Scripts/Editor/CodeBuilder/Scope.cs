using System;

namespace Pets.Editor.CodeBuilders
{
    public static partial class CodeBuilderExtensions
    {
        public static Scope CreateScope(this CodeBuilder self)
        {
            return new(self);
        }
        
        public sealed class Scope : IDisposable
        {
            private readonly CodeBuilder _codeBuilder;
        
            internal Scope(CodeBuilder codeBuilder)
            {
                _codeBuilder = codeBuilder;
                
                _codeBuilder.NewLine();
                _codeBuilder.Append('{');
                _codeBuilder.NewLine();
                _codeBuilder.Indent();
            }

            public void Dispose()
            {
                _codeBuilder.Unindent();
                _codeBuilder.NewLine();
                _codeBuilder.Append('}');
            }
        }
    }
}
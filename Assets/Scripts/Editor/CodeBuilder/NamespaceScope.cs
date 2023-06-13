using System;

namespace Pets.Editor.CodeBuilders
{
    public static partial class CodeBuilderExtensions
    {
        public static NamespaceScope CreateNamespaceScope(this CodeBuilder self, string name)
        {
            return new(self, name);
        }

        public class NamespaceScope : IDisposable
        {
            private readonly Scope _scope;
            
            internal NamespaceScope(CodeBuilder codeBuilder, string name)
            {
                codeBuilder.Append("namespace ");
                codeBuilder.Append(name);
                
                _scope = codeBuilder.CreateScope();
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}
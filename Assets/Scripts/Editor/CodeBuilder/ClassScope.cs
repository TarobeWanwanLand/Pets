using System;

namespace Pets.Editor.CodeBuilders
{
    public static partial class CodeBuilderExtensions
    {
        public class ClassScope : IDisposable
        {
            private readonly CodeBuilder _codeBuilder;
            private readonly Scope _scope;
            private readonly bool _isStatic;

            internal ClassScope(CodeBuilder codeBuilder, string name,
                AccessModifier accessModifier = AccessModifier.Private, bool isStatic = false)
            {
                _codeBuilder = codeBuilder;
                _isStatic = isStatic;

                _codeBuilder.Append(accessModifier.ToAccessString());
                if (isStatic)
                {
                    _codeBuilder.Append("static ");
                }
                _codeBuilder.Append("class ");
                _codeBuilder.Append(name);

                _scope = _codeBuilder.CreateScope();
            }
            
            public void AppendField(string type, string name, AccessModifier accessModifier = AccessModifier.Private,
                bool isStatic = false)
            {
                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentException("型名が空です。", nameof(type));
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("フィールド名が空です。", nameof(name));
                if (_isStatic && !isStatic)
                    throw new ArgumentException("staticクラスのフィールドにはstaticを付ける必要があります。");

                _codeBuilder.Append(accessModifier.ToAccessString());
                if (isStatic)
                {
                    _codeBuilder.Append("static ");
                }
                _codeBuilder.Append(type);
                _codeBuilder.Append(' ');
                _codeBuilder.Append(name);
                _codeBuilder.Append(';');
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}
using System.Collections.Generic;

namespace Pets.Editor.CodeBuilders
{
    public enum AccessModifier
    {
        Public,
        Private,
        Protected,
        Internal,
        ProtectedInternal,
        PrivateProtected
    }

    public static class AccessModifierExtensions
    {
        private static readonly Dictionary<AccessModifier, string> AccessModifierMap = new()
        {
            { AccessModifier.Public, "public" },
            { AccessModifier.Private, "private" },
            { AccessModifier.Protected, "protected" },
            { AccessModifier.Internal, "internal" },
            { AccessModifier.ProtectedInternal, "protected internal" },
            { AccessModifier.PrivateProtected, "private protected" }
        };

        public static string ToString(this AccessModifier self)
        {
            return AccessModifierMap[self];
        }
    }
}
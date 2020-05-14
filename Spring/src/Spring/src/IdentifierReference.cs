using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Impl.CodeStyle.MemberReordering;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Resolve;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;
using Microsoft.CodeAnalysis.Operations;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class IdentifierReference : TreeReferenceBase<Spring_Identifier>
    {
        private Spring_Identifier _identifier;
        
        public IdentifierReference([NotNull] Spring_Identifier owner) : base(owner)
        {
            _identifier = owner;
        }

        public override ResolveResultWithInfo ResolveWithoutCache()
        {
            foreach (var parent in _identifier.PathToRoot())
            {
                if (parent is IDeclaringVariables declaring)
                {
                    foreach (var declaration in declaring.DeclaredVariables())
                    {
                        if (declaration.DeclaredName == this.GetName())
                        {
                            return new ResolveResultWithInfo(new SimpleResolveResult(declaration.DeclaredElement),
                                ResolveErrorType.OK);
                        }
                    }
                }
            }
            
            return ResolveResultWithInfo.Unresolved;
        }

        public override string GetName() => _identifier.GetText();

        public override ISymbolTable GetReferenceSymbolTable(bool useReferenceName)
        {
            throw new System.NotImplementedException();
        }

        public override TreeTextRange GetTreeTextRange() => _identifier.GetTreeTextRange();

        public override IReference BindTo(IDeclaredElement element) => null;

        public override IReference BindTo(IDeclaredElement element, ISubstitution substitution) => null;

        public override IAccessContext GetAccessContext() => null;

        public override bool IsValid() => _identifier.IsValid();
    }
}
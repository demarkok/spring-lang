using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Resolve;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class FunctionIdentifierReference : TreeReferenceBase<Spring_FunctionIdentifier>
    {
        
        private Spring_FunctionIdentifier _identifier;
        
        public FunctionIdentifierReference([NotNull] Spring_FunctionIdentifier owner) : base(owner)
        {
            _identifier = owner;
        }

        public override ResolveResultWithInfo ResolveWithoutCache()
        {
            var file = (SpringFile)(_identifier.Root());

            Spring_FunctionIdentifierDecl decl = null;
            
            foreach (var declaration in file.DeclaredFunctions())
            {
                if (declaration.DeclaredName == this.GetName())
                {
                    decl = declaration;
                }
            }
            
            var declElem = decl?.DeclaredElement;
            
            if (declElem == null)
            {
                return ResolveResultWithInfo.Unresolved;
            }
            
            return  new ResolveResultWithInfo(new SimpleResolveResult(declElem), ResolveErrorType.OK);
            
            
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
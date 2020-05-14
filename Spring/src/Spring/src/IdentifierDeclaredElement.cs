using System.Collections.Generic;
using System.Xml;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util.DataStructures;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class IdentifierDeclaredElement : IDeclaredElement
    {
        private readonly SpringDeclaration _identifierDecl;
        public IdentifierDeclaredElement(SpringDeclaration identifierDecl)
        {
            _identifierDecl = identifierDecl;
        }

        public IPsiServices GetPsiServices() => _identifierDecl.GetPsiServices();

        public IList<IDeclaration> GetDeclarations() => new List<IDeclaration>{_identifierDecl};

        public IList<IDeclaration> GetDeclarationsIn(IPsiSourceFile sourceFile) => new List<IDeclaration>{_identifierDecl};

        // TODO: fix
        public DeclaredElementType GetElementType() => CLRDeclaredElementType.LOCAL_VARIABLE;

        public XmlNode GetXMLDoc(bool inherit) => null;

        public XmlNode GetXMLDescriptionSummary(bool inherit) => null;

        public bool IsValid() => _identifierDecl.IsValid();

        public bool IsSynthetic() => false;

        public HybridCollection<IPsiSourceFile> GetSourceFiles() =>
            new HybridCollection<IPsiSourceFile>(_identifierDecl.GetSourceFile());

        public bool HasDeclarationsIn(IPsiSourceFile sourceFile) => sourceFile.Equals(_identifierDecl.GetSourceFile());

        public string ShortName => _identifierDecl.DeclaredName;

        public bool CaseSensitiveName => true;

        public PsiLanguageType PresentationLanguage => SpringLanguage.Instance;

    }
}
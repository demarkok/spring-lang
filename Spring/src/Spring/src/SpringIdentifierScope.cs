using System;
using System.Collections.Generic;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class SpringIdentifierScope
    {
        private Dictionary<String, Spring_IdentifierDecl> _dict;

        public SpringIdentifierScope(Dictionary<string, Spring_IdentifierDecl> dict)
        {
            _dict = dict;
        }

        public SpringIdentifierScope()
        {
        }

        public void Update(String name, Spring_IdentifierDecl node)
        {
            _dict[name] = node;
        }

        public void UpdateOver(SpringIdentifierScope scope)
        {
            foreach (var entry in scope._dict)
            {
                _dict[entry.Key] = entry.Value;
            }
        }

        public Spring_IdentifierDecl Resolve(String name)
        {
            return _dict.GetValueSafe(name);
        }
    }
}
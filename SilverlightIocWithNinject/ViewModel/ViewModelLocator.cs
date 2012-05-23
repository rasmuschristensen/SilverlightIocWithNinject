using System.Dynamic;

namespace SilverlightIocWithNinject.ViewModel
{
    public class ViewModelLocator : DynamicObject
    {
        private static ViewModelResolver _resolver;

        public static ViewModelResolver Resolver
        {
            get
            {
                if (_resolver == null)
                {
                    _resolver = new ViewModelResolver();
                }

                return _resolver;
            }
        }

        public object this[string viewModelName]
        {
            get
            {               
                return Resolver.Resolve(viewModelName);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
    }
}
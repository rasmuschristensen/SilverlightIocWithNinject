using System.Linq;
using Ninject;

namespace SilverlightIocWithNinject.ViewModel
{
    public class ViewModelResolver
    {
        private IKernel container = null;

        public object Resolve(string viewModelName)
        {
            if (container == null)
            {
                //This could be placed somewhere like application_start
                //Could use Ninject conventions to bind all that inherits
                //from ViewModelBase
                container = new StandardKernel();                                
                container.Bind<MainViewModel>().To<MainViewModel>();
            }
 
            var viewModelType =
                this.GetType()
                    .Assembly
                    .GetTypes().FirstOrDefault(t => t.Name.Equals(viewModelName));
            
            return container.Get(viewModelType);
        }
    }
}
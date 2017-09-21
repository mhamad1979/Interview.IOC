using My.IOC.Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.IOC.Library.Interfaces
{
    public interface IIocContainer
    {
        void Register<MappedEntityType, ConcreteType>(LifeCycleType lifeCycleType = LifeCycleType.Transiet);
        MappedType Resolve<MappedType>();
        object Resolve(Type typeToResolve);
    }
}

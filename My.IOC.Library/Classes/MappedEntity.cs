using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.IOC.Library.Classes
{
    public class MappedEntity
    {
        public MappedEntity(Type mappedType, Type concreteType, LifeCycleType lifeCycle)
        {
            MappedType = mappedType;
            ConcreteType = concreteType;
            LifeCycle = lifeCycle;
        }

        public Type MappedType { get; set; }
        public Type ConcreteType { get; set; }
        public Object Instance { get; set; }
        public LifeCycleType LifeCycle { get; set; }

        public void CreateInstance(params Object[] args)
        {
            Instance = Activator.CreateInstance(ConcreteType, args);
        }
    }
}

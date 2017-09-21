using My.IOC.Library.Classes;
using My.IOC.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.IOC.Library.Implementations
{
    public class IocContainer : IIocContainer
    {
        private readonly Dictionary<Type, MappedEntity> mappedEntities = new Dictionary<Type, MappedEntity>();

        public void Register<MappedEntityType, ConcreteType>(LifeCycleType lifeCycleType = LifeCycleType.Transiet)
        {
            mappedEntities.Add(typeof(MappedEntityType), new MappedEntity(typeof(MappedEntityType), typeof(ConcreteType), lifeCycleType));
        }
        

        public MappedType Resolve<MappedType>()
        {
            return (MappedType)ResolveEntity(typeof(MappedType));
        }

        public object Resolve(Type typeToResolve)
        {
            return ResolveEntity(typeToResolve);
        }

        private object ResolveEntity(Type mappedType)
        {
            var mappedEntity = mappedEntities[mappedType];
            if (mappedEntity == null)
            {
                throw new  KeyNotFoundException(string.Format(
                    "{0} can not be resolved. Please register the type using IOC container", mappedType.Name));
            }
            return GetInstance(mappedEntity);
        }

        private object GetInstance(MappedEntity mappedEntity)
        {
            if (mappedEntity.Instance == null ||
                mappedEntity.LifeCycle == LifeCycleType.Transiet)
            {
                var dependancies = GetConstructorDependancy(mappedEntity);
                mappedEntity.CreateInstance(dependancies.ToArray());
            }
            return mappedEntity.Instance;
        }

        private IEnumerable<object> GetConstructorDependancy(MappedEntity mappedEntity)
        {
            var entityConstructor = mappedEntity.ConcreteType.GetConstructors().First();
            foreach (var parameter in entityConstructor.GetParameters())
            {
                yield return ResolveEntity(parameter.ParameterType);
            }
        }
    }
}

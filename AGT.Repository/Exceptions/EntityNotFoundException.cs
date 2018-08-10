using AGT.Contracts.Repository;
using System;

namespace AGT.Repository.Exceptions
{
    public class EntityNotFoundException : RepositoryException
    {
        public EntityNotFoundException() : base("Entity not found")
        {
        }

        public EntityNotFoundException(Exception inner) : base("Entity not found", inner)
        {
        }
    }
}

using AGT.Contracts.Repository;
using System;

namespace AGT.Repository.Exceptions
{
    public class EntityNotFoundException : RepositoryException
    {
        private const string MESSAGE = "Entity not found";
        public EntityNotFoundException() : base(MESSAGE)
        {
        }

        public EntityNotFoundException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}

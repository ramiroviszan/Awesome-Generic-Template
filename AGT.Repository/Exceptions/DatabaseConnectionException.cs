using System;
using System.Runtime.Serialization;
using AGT.Contracts.Repository;

namespace AGT.Repository.Exceptions
{
    public class DatabaseConnectionException : RepositoryException
    {
        private const string MESSAGE = "Error to connect to database";
        public DatabaseConnectionException() : base(MESSAGE)
        {
        }

        public DatabaseConnectionException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}
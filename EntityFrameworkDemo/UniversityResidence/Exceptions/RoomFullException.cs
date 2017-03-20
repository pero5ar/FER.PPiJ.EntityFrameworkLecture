using System;

namespace UniversityResidence.Exceptions
{
    public class RoomFullException : Exception
    {
        public RoomFullException(string message) : base(message)
        {
        }
    }
}

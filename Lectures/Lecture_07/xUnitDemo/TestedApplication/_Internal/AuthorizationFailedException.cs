using System;

namespace TestedApplication._Internal
{
    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException() : base("Provided passCode is not correct!")
        {
        }
    }
}
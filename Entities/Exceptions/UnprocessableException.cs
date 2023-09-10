namespace GraphNet.Entities.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class UnprocessableException : Exception
{
    public UnprocessableException(string message) : base(message)
    {
    }

    protected UnprocessableException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }

        base.GetObjectData(info, context);
    }
}
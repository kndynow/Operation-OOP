using OperationOOP.Core.Models.Enums;

namespace OperationOOP.Core.Validation;

public interface IValidator
{
    // void ValidateCreate(Request request);
    // void ValidateUpdate(Request request);
}

public class Validator : IValidator
{
    public void ValidateCreate()
    {
        throw new NotImplementedException();
    }

    public void ValidateUpdate()
    {
        throw new NotImplementedException();
    }
}

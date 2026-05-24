namespace SistemaLaboratorioAcademico.Application.Results;

public class OperationResult
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; }

    protected OperationResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static OperationResult Success(string message) => new(true, message);

    public static OperationResult Failure(string message) => new(false, message);
}

public class OperationResult<T> : OperationResult
{
    public T? Value { get; init; }

    private OperationResult(bool isSuccess, T? value, string message)
        : base(isSuccess, message)
    {
        Value = value;
    }

    public static OperationResult<T> Success(T value, string message) => new(true, value, message);

    public static new OperationResult<T> Failure(string message) => new(false, default, message);
}

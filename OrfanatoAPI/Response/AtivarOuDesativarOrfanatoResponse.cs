namespace OrfanatoAPI.Response;

public class AtivarOuDesativarOrfanatoResponse<T>
{
    public bool Success { get; }
    public int ResourceId { get; }
    public IReadOnlyList<string> Errors { get; }

    private AtivarOuDesativarOrfanatoResponse(int resourceId, List<string> errors)
    {
        Success = errors.Count == 0;
        ResourceId = resourceId;
        Errors = errors.AsReadOnly();
    }

    public static AtivarOuDesativarOrfanatoResponse<T> Valid(int resourceId) =>
       new AtivarOuDesativarOrfanatoResponse<T>(resourceId, new List<string>());

    public static AtivarOuDesativarOrfanatoResponse<T> Invalid(List<string> errors) =>
        errors.Count != 0
            ? new AtivarOuDesativarOrfanatoResponse<T>(0, errors)
            : throw new ArgumentException($"{nameof(errors)} não deveria estar vazio");
}



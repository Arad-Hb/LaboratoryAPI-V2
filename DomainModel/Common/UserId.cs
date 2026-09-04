namespace DomainModel.Common;

public sealed record UserId
{
    public string Value { get; }

    public UserId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("UserId cannot be empty.", nameof(value));

        Value = value;
    }

    public static UserId From(string value) => new(value);

    public override string ToString() => Value;
}

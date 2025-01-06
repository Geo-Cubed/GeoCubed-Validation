using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MaximumTestModels;

public class MaximumAll
{
    [Maximum("0", "Test")]
    public int? ValueError { get; set; }

    [Maximum("0")]
    public sbyte? ValueSByte { get; set; }

    [Maximum("0")]
    public byte? ValueByte { get; set; }

    [Maximum("0")]
    public short? ValueShort { get; set; }

    [Maximum("10")]
    public ushort? ValueUShort { get; set; }

    [Maximum("0")]
    public int? ValueInt { get; set; }

    [Maximum("100")]
    public uint? ValueUInt { get; set; }

    [Maximum("0")]
    public long? ValueLong { get; set; }

    [Maximum("100")]
    public ulong? ValueULong { get; set; }

    [Maximum("0")]
    public float? ValueFloat { get; set; }

    [Maximum("2.2")]
    public float? ValueFloatDecimal { get; set; }

    [Maximum("0")]
    public double? ValueDouble { get; set; }

    [Maximum("0")]
    public decimal? ValueDecimal { get; set; }
}

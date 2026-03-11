namespace DataCommon.Models.Abstractions;

internal interface ICloneable<T> where T : ICloneable<T>
{
	T Clone();
}

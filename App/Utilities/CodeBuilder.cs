using System.Text;

namespace MOM.Utilities;

internal class CodeBuilder
{
	private const string INDENT = "    ";

	private readonly StringBuilder _builder = new();

	public void AppendLine() => _builder.AppendLine();

	public void AppendLine(int indent, string value)
	{
		for (int index = 0; index < indent; index++)
		{
			_builder.Append(INDENT);
		}
		_builder.AppendLine(value);
	}

	public override string ToString() => _builder.ToString();
}

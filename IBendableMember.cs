using System;
using System.Linq;

namespace Temp_MirrorExpolrer
{
	public interface IBendableMember : IComparable<IBendableMember>
	{
		bool Equals(object? obj);
		int GetHashCode();
		object? TryGetValue(object? parent);
		object? TrySetValue(object? parent, object? value);
		object? GetValue(object? parent);
		void SetValue(object? parent, object? value);

		string Name { get; }
		bool Readable { get; }
		bool Writeable { get; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Temp_MirrorExpolrer
{
	public static class MemberBender<ParentType>
	{
		private static SortedSet<BendableMember<ParentType>> Explore()
		{
			SortedSet<BendableMember<ParentType>> members = new();

			foreach (var field in typeof(ParentType).GetFields())
				members.Add(
					new BendableMember<ParentType>(
						field.FieldType,
						field.Name, 
						field.GetValue,
						field.SetValue
					)
				);

			foreach (var property in typeof(ParentType).GetProperties())
				members.Add(
					new BendableMember<ParentType>(
						property.PropertyType,
						property.Name,
						property.CanRead ? property.GetValue : null,
						property.CanWrite ?	property.SetValue : null
					)
				);

			return members;
		}

		public static BendableMember<ParentType>? Member(string name)
		{
			return members.FirstOrDefault( (bendable) => bendable.Name == name );
		}

		public static IEnumerable<BendableMember<ParentType>> Members() => members.AsEnumerable();

		private static readonly SortedSet<BendableMember<ParentType>> members = Explore();
	}
}

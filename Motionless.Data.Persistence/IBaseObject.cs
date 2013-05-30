using System;

namespace Motionless.Data.Persistence
{
	public interface IBaseObject
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		long Id { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is deleted.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is deleted; otherwise, <c>false</c>.
		/// </value>
		bool IsDeleted { get; set; }

		/// <summary>
		/// Gets or sets the created at timestamp.
		/// </summary>
		/// <value>
		/// The created at.
		/// </value>
		DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the updated at timestamp.
		/// </summary>
		/// <value>
		/// The updated at.
		/// </value>
		DateTime UpdatedAt { get; set; }
	}
}
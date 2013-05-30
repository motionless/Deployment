using System;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace Motionless.Data.Persistence
{
	public class CreateAndUpdateEventListener : IPreUpdateEventListener, IPreInsertEventListener
	{
		public bool OnPreUpdate(PreUpdateEvent @event)
		{
			var audit = @event.Entity as IBaseObject;
			if (audit == null)
			{
				return false;
			}

			var time = DateTime.UtcNow;
			Set(@event.Persister, @event.State, "UpdatedAt", time);
			
			audit.UpdatedAt = time;
			
			return false;
		}

		public bool OnPreInsert(PreInsertEvent @event)
		{
			var audit = @event.Entity as IBaseObject;
			if (audit == null)
			{
				return false;
			}


			var time = DateTime.UtcNow;
			

			Set(@event.Persister, @event.State, "CreatedAt", time);
			Set(@event.Persister, @event.State, "UpdatedAt", time);
			
			audit.CreatedAt = time;
			audit.UpdatedAt = time;
			
			return false;
		}

		private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
		{
			var index = Array.IndexOf(persister.PropertyNames, propertyName);
			if (index == -1)
			{
				return;
			}
			state[index] = value;
		}
	}
}

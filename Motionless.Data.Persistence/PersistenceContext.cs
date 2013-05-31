using System;
using System.Collections.Generic;
using System.Transactions;
using NHibernate;
using NHibernate.Context;

namespace Motionless.Data.Persistence
{
	public class PersistenceContext : IDisposable
	{
		private TransactionScope TransactionScope { get; set; }

		private ISession Session { get; set; }
		private ITransaction Transaction { get; set; }

		private List<bool> Commits { get; set; }
		private int RegisteredVotes { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PersistenceContext"/> class.
		/// </summary>
		internal PersistenceContext() : this(false)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PersistenceContext"/> class.
		/// </summary>
		/// <param name="createNewScope">if set to <c>true</c> [create new scope].</param>
		internal PersistenceContext(bool createNewScope)
		{
			if (!CurrentSessionContext.HasBind(PersistenceHelper.SessionFactory))
			{
				var session = PersistenceHelper.SessionFactory.OpenSession();

				CurrentSessionContext.Bind(session);
				Transaction = session.BeginTransaction();
				//TransactionScope = new TransactionScope();
			}

			Session = PersistenceHelper.SessionFactory.GetCurrentSession();
			//Session.FlushMode = FlushMode.Auto;
			Commits = new List<bool>();
		}
		
		internal void Register()
		{
			RegisteredVotes++;
		}
		internal void Unregister()
		{
			RegisteredVotes--;
		}

		public void Flush()
		{
			if (Session != null)
			{
				Session.Flush();
			}
		}

		/// <summary>
		/// Votes the commit.
		/// </summary>
		public void VoteCommit()
		{
			if (Transaction != null)
			{
				Commits.Add(true);
			}
		}

		/// <summary>
		/// Votes the roll back.
		/// </summary>
		public void VoteRollBack()
		{
			if (Transaction!= null)
			{
				Commits.Add(false);
			}
		}

		
		public void Dispose()
		{
			Unregister();
			if (RegisteredVotes == 0)
			{
				InternalDispose();
			}
		}

		internal void ForceDispose()
		{
			Commits.Add(false);
			this.InternalDispose();
		}

		private void InternalDispose()
		{
			PersistenceHelper.RemoveFromStack(this);

			var session = CurrentSessionContext.Unbind(PersistenceHelper.SessionFactory);

			if (Transaction != null)
			{
				if (!Commits.Contains(false))
				{
					session.Transaction.Commit();
				}
				else
				{
					Transaction.Rollback();
				}
				
				Transaction.Dispose();
			}

			if (session != null)
			{
				session.Close();
				session.Dispose();
			}
			if (TransactionScope!= null)
			{
				TransactionScope.Complete();
			}

		}
	}
}

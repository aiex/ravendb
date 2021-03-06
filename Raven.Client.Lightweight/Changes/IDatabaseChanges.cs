using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Raven.Abstractions.Data;

namespace Raven.Client.Changes
{
	public interface IDatabaseChanges
	{
		bool Connected { get; }
		event EventHandler ConnectionStatusChanged;

		Task Task { get; }
		IObservableWithTask<IndexChangeNotification> ForIndex(string indexName);
		IObservableWithTask<DocumentChangeNotification> ForDocument(string docId);
		IObservableWithTask<DocumentChangeNotification> ForAllDocuments();
		IObservableWithTask<IndexChangeNotification> ForAllIndexes();
		IObservableWithTask<DocumentChangeNotification> ForDocumentsStartingWith(string docIdPrefix);
	}
}
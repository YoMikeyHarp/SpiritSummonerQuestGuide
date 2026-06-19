using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class _003C_003Ez__ReadOnlySingleElementList<T> : global::System.Collections.IEnumerable, global::System.Collections.ICollection, global::System.Collections.IList, global::System.Collections.Generic.IEnumerable<T>, global::System.Collections.Generic.IReadOnlyCollection<T>, global::System.Collections.Generic.IReadOnlyList<T>, global::System.Collections.Generic.ICollection<T>, global::System.Collections.Generic.IList<T>
{
	private sealed class Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<T>
	{
		object global::System.Collections.IEnumerator.Current => _item;

		T global::System.Collections.Generic.IEnumerator<T>.Current => _item;

		public Enumerator(T item)
		{
			_item = item;
		}

		bool global::System.Collections.IEnumerator.MoveNext()
		{
			return !_moveNextCalled && (_moveNextCalled = true);
		}

		void global::System.Collections.IEnumerator.Reset()
		{
			_moveNextCalled = false;
		}

		void global::System.IDisposable.Dispose()
		{
		}
	}

	int global::System.Collections.ICollection.Count => 1;

	bool global::System.Collections.ICollection.IsSynchronized => false;

	object global::System.Collections.ICollection.SyncRoot => this;

	object? global::System.Collections.IList.this[int index]
	{
		get
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
		set
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	bool global::System.Collections.IList.IsFixedSize => true;

	bool global::System.Collections.IList.IsReadOnly => true;

	int global::System.Collections.Generic.IReadOnlyCollection<T>.Count => 1;

	T global::System.Collections.Generic.IReadOnlyList<T>.this[int index]
	{
		get
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
	}

	int global::System.Collections.Generic.ICollection<T>.Count => 1;

	bool global::System.Collections.Generic.ICollection<T>.IsReadOnly => true;

	T global::System.Collections.Generic.IList<T>.this[int index]
	{
		get
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
		set
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	public _003C_003Ez__ReadOnlySingleElementList(T item)
	{
		_item = item;
	}

	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return new Enumerator(_item);
	}

	void global::System.Collections.ICollection.CopyTo(global::System.Array array, int index)
	{
		array.SetValue((object)_item, index);
	}

	int global::System.Collections.IList.Add(object? value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	void global::System.Collections.IList.Clear()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	bool global::System.Collections.IList.Contains(object? value)
	{
		return EqualityComparer<T>.Default.Equals(_item, (T)value);
	}

	int global::System.Collections.IList.IndexOf(object? value)
	{
		return (!EqualityComparer<T>.Default.Equals(_item, (T)value)) ? (-1) : 0;
	}

	void global::System.Collections.IList.Insert(int index, object? value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	void global::System.Collections.IList.Remove(object? value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	void global::System.Collections.IList.RemoveAt(int index)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
	{
		return new Enumerator(_item);
	}

	void global::System.Collections.Generic.ICollection<T>.Add(T item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	void global::System.Collections.Generic.ICollection<T>.Clear()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	bool global::System.Collections.Generic.ICollection<T>.Contains(T item)
	{
		return EqualityComparer<T>.Default.Equals(_item, item);
	}

	void global::System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		array[arrayIndex] = _item;
	}

	bool global::System.Collections.Generic.ICollection<T>.Remove(T item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	int global::System.Collections.Generic.IList<T>.IndexOf(T item)
	{
		return (!EqualityComparer<T>.Default.Equals(_item, item)) ? (-1) : 0;
	}

	void global::System.Collections.Generic.IList<T>.Insert(int index, T item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	void global::System.Collections.Generic.IList<T>.RemoveAt(int index)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}
}

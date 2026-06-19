using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class _003C_003Ez__ReadOnlyArray<T> : global::System.Collections.IEnumerable, global::System.Collections.ICollection, global::System.Collections.IList, global::System.Collections.Generic.IEnumerable<T>, global::System.Collections.Generic.IReadOnlyCollection<T>, global::System.Collections.Generic.IReadOnlyList<T>, global::System.Collections.Generic.ICollection<T>, global::System.Collections.Generic.IList<T>
{
	int global::System.Collections.ICollection.Count => _items.Length;

	bool global::System.Collections.ICollection.IsSynchronized => false;

	object global::System.Collections.ICollection.SyncRoot => this;

	object? global::System.Collections.IList.this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	bool global::System.Collections.IList.IsFixedSize => true;

	bool global::System.Collections.IList.IsReadOnly => true;

	int global::System.Collections.Generic.IReadOnlyCollection<T>.Count => _items.Length;

	T global::System.Collections.Generic.IReadOnlyList<T>.this[int index] => _items[index];

	int global::System.Collections.Generic.ICollection<T>.Count => _items.Length;

	bool global::System.Collections.Generic.ICollection<T>.IsReadOnly => true;

	T global::System.Collections.Generic.IList<T>.this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	public _003C_003Ez__ReadOnlyArray(T[] items)
	{
		_items = items;
	}

	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return ((global::System.Collections.IEnumerable)(object)_items).GetEnumerator();
	}

	void global::System.Collections.ICollection.CopyTo(global::System.Array array, int index)
	{
		((global::System.Collections.ICollection)(object)_items).CopyTo(array, index);
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
		return ((global::System.Collections.IList)(object)_items).Contains(value);
	}

	int global::System.Collections.IList.IndexOf(object? value)
	{
		return ((global::System.Collections.IList)(object)_items).IndexOf(value);
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
		return ((global::System.Collections.Generic.IEnumerable<T>)_items).GetEnumerator();
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
		return ((global::System.Collections.Generic.ICollection<T>)_items).Contains(item);
	}

	void global::System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		((global::System.Collections.Generic.ICollection<T>)_items).CopyTo(array, arrayIndex);
	}

	bool global::System.Collections.Generic.ICollection<T>.Remove(T item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	int global::System.Collections.Generic.IList<T>.IndexOf(T item)
	{
		return ((global::System.Collections.Generic.IList<T>)_items).IndexOf(item);
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

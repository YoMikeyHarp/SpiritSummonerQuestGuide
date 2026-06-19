namespace SpiritSummoner.Application.Services;

public interface IPreferencesService
{
	T? Get<T>(string key, T? defaultValue = default(T?));

	void Set<T>(string key, T value);

	void Remove(string key);

	void Clear();

	bool ContainsKey(string key);
}

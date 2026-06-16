using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Client.Services
{
	public class AppSettingsService
	{
		private readonly ISystemSettingsRepository _repo;

		private SystemSetting _cache;
		private bool _loaded;
		private readonly SemaphoreSlim _lock = new(1, 1);

		public AppSettingsService(ISystemSettingsRepository repo)
		{
			_repo = repo;
		}

		public async Task<SystemSetting> GetAsync()
		{
			if (_loaded)
				return _cache;

			await _lock.WaitAsync();

			try
			{
				if (_loaded)
					return _cache;

				_cache = await _repo.GetAsync();
				_loaded = true;

				return _cache;
			}
			finally
			{
				_lock.Release();
			}
		}

		public void ClearCache()
		{
			_loaded = false;
			_cache = null;
		}
	}
}

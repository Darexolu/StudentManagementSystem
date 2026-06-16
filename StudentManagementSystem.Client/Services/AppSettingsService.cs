using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Client.Services
{
	public class AppSettingsService
	{
		private readonly SemaphoreSlim _lock = new(1, 1);

		public SystemSetting? Settings { get; private set; }

		public event Action? OnChange;

		public async Task InitializeAsync(Func<Task<SystemSetting>> factory)
		{
			if (Settings != null)
				return;

			await _lock.WaitAsync();

			try
			{
				if (Settings == null)
				{
					Settings = await factory();
					OnChange?.Invoke();
				}
			}
			finally
			{
				_lock.Release();
			}
		}

		public void Update(SystemSetting settings)
		{
			Settings = settings;
			OnChange?.Invoke();
		}
	}
}

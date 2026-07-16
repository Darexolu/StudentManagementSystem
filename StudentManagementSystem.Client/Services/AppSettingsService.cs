using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Client.Services
{
	public class AppSettingsService
	{
		private readonly IServiceScopeFactory _scopeFactory;
		private readonly SemaphoreSlim _lock = new(1, 1);

		public SystemSetting? Settings { get; private set; }

		public event Action? OnChange;

		public AppSettingsService(IServiceScopeFactory scopeFactory)
		{
			_scopeFactory = scopeFactory;
		}

		public async Task InitializeAsync()
		{
			if (Settings != null)
				return;

			await _lock.WaitAsync();

			try
			{
				if (Settings != null)
					return;

				using var scope = _scopeFactory.CreateScope();

				var repository =
					scope.ServiceProvider.GetRequiredService<ISystemSettingsRepository>();

				Settings = await repository.GetAsync();

				OnChange?.Invoke();
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
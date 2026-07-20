namespace StudentManagementSystem.Client.Services
{
	public class SidebarService
	{
		public bool IsOpen { get; private set; }

		public event Action? OnChange;

		public void Toggle()
		{
			IsOpen = !IsOpen;
			OnChange?.Invoke();
		}

		public void Close()
		{
			IsOpen = false;
			OnChange?.Invoke();
		}

		public void Open()
		{
			IsOpen = true;
			OnChange?.Invoke();
		}
	}
}
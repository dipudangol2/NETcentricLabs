namespace DependencyInjection.Services
{
	public interface ILog
	{
		void Info(string message);
	}
	public class Temp:ILog
	{
		public void Info(string message)
		{
			Console.WriteLine(message);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Interface
{
	public interface INotifyMessageWhenShutdown
	{
		event Action<string, string> ShutdownShowMessage;
	}
}

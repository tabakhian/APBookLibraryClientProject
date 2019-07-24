using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;

namespace LibraryManagmentConnectSDK
{
	public static class ConnectionSetting
	{
		public static bool ConnectedToServer { get; set; }
		public static Channel ConnectionChannel { get; set; }
		public static LibraryManager.LibraryManagerClient LibraryManagerClient{ get; set; }

		public static void SetupConnectionChannel(string url)
		{
			Grpc.Core.GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

			ConnectionChannel = new Channel(url,
									 ChannelCredentials.Insecure);
			try
			{
				//ConnectionChannel.ConnectAsync(System.DateTime.UtcNow.AddSeconds(3)).GetAwaiter().GetResult();
				ConnectionChannel.ConnectAsync().GetAwaiter().GetResult();
				LibraryManagerClient = new LibraryManager.LibraryManagerClient(ConnectionChannel);

				ServerConnection oServerConnection = new ServerConnection();
				ConnectedToServer = oServerConnection.CheckServerAvailability(true);
			}
			catch (Exception ex)
			{
				ConnectedToServer = false;
			}
			
		}
	}
}
